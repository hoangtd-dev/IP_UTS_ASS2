import { AsyncPipe } from '@angular/common';
import {
  ChangeDetectionStrategy,
  ChangeDetectorRef,
  Component,
  DestroyRef,
  EventEmitter,
  inject,
  OnInit,
} from '@angular/core';
import { BehaviorSubject, combineLatest, Observable } from 'rxjs';
import { Car } from '../../../models/car.model';
import { CarService } from '../services/car.service';
import { CarContextService } from '../services/car-context.service';
import { FormControl, ReactiveFormsModule } from '@angular/forms';
import { MatAutocompleteModule } from '@angular/material/autocomplete';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import {
  debounceTime,
  distinctUntilChanged,
  filter,
  finalize,
  startWith,
} from 'rxjs/operators';
import { SearchSuggestion } from '../../../models/search-suggestion.model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-car',
  standalone: true,
  imports: [
    AsyncPipe,
    ReactiveFormsModule,
    MatAutocompleteModule,
    MatInputModule,
    MatFormFieldModule,
    MatIconModule,
  ],
  templateUrl: './car.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class CarComponent implements OnInit {
  private _carService = inject(CarService);
  private _carContextService = inject(CarContextService);
  private _destroyRef = inject(DestroyRef);
  private _cd = inject(ChangeDetectorRef);
  private _router = inject(Router);

  searchEvent = new EventEmitter<string>();
  cars$!: Observable<Car[]>;
  searchControl = new FormControl('');
  filteredOptions$!: Observable<SearchSuggestion[]>;
  filterLoading$ = new BehaviorSubject<boolean>(false);

  ngOnInit(): void {
    combineLatest([
      this._carContextService.getSearchParams(),
      this.searchEvent.pipe(startWith('')),
    ]).subscribe(([searchParams, searchValue]) => {
      const params =
        searchParams?.filter((x) => x.SuggestionType !== 'carName') || [];

      if (searchValue) {
        params.push({
          SuggestionType: 'carName',
          SearchTerm: searchValue,
        });
      }

      this.cars$ = this._carService.getCars(params);
      this._cd.markForCheck();
    });

    const searchSubscription = this.searchControl.valueChanges
      .pipe(
        debounceTime(300),
        distinctUntilChanged(),
        filter((x) => x!.length > 2)
      )
      .subscribe((value) => {
        this.filterLoading$.next(true);
        this.filteredOptions$ = this._carService
          .getSearchSuggestions(value || '')
          .pipe(
            finalize(() => {
              this.filterLoading$.next(false);
            })
          );
      });

    this._destroyRef.onDestroy(() => {
      searchSubscription.unsubscribe();
    });
  }

  displayFn(suggestion: string): string {
    return suggestion;
  }

  search() {
    this.searchEvent.emit(this.searchControl.value || '');
  }

  setCar(car: Car) {
    if (!car.isAvailable) return;

    this._carContextService.setCar(car);
    this._router.navigate(['/reservation']);
  }

  isCarSelected(VIN: string): boolean {
    return this._carContextService.isCarSelected(VIN);
  }
}
