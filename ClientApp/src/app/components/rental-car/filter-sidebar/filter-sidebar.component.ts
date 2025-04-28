import {
  ChangeDetectionStrategy,
  Component,
  inject,
  OnInit,
} from '@angular/core';
import { forkJoin, map, share } from 'rxjs';
import { Filter } from '../models/filter.model';
import { FormArray, FormControl, ReactiveFormsModule } from '@angular/forms';
import { AsyncPipe } from '@angular/common';
import { CustomCheckboxComponent } from './custom-checkbox/custom-checkbox.component';
import { CarBrandService } from '../../../services/services/car-brand.service';
import { CarTypeService } from '../../../services/services/car-type.service';
import { CarContextService } from '../services/car-context.service';
import { SearchParams } from '../models/search.model';

@Component({
  selector: 'app-filter-sidebar',
  imports: [ReactiveFormsModule, AsyncPipe, CustomCheckboxComponent],
  templateUrl: './filter-sidebar.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class FilterSidebarComponent implements OnInit {
  private _carTypeService = inject(CarTypeService);
  private _carBrandService = inject(CarBrandService);

  private _carContextService = inject(CarContextService);

  formArray = new FormArray<FormControl>([]);

  carTypes$ = this._carTypeService.getCarTypes().pipe(
    map((carTypes) =>
      carTypes.map((carType) => {
        const filter = Filter.createFromProperty('carType', carType);
        this.formArray.push(filter.filterControl);
        return filter;
      })
    ),
    share()
  );

  carBrands$ = this._carBrandService.getCarBrands().pipe(
    map((carBrands) =>
      carBrands.map((carBrand) => {
        const filter = Filter.createFromProperty('carBrand', carBrand);
        this.formArray.push(filter.filterControl);
        return filter;
      })
    ),
    share()
  );

  ngOnInit(): void {
    forkJoin([this.carTypes$, this.carBrands$]).subscribe(() => {
      this._subscribeToFormArray();
    });
  }

  private _subscribeToFormArray() {
    this.formArray.valueChanges.subscribe((value) => {
      const newValues = value.filter((x) => x.value);
      const carTypes = newValues
        ?.filter((x) => x.filterProperty === 'carType')
        .map(
          (x) =>
            ({
              SuggestionType: 'carType',
              CarTypeId: x.id,
            } as SearchParams)
        );

      const carBrands = newValues
        ?.filter((x) => x.filterProperty === 'carBrand')
        .map(
          (x) =>
            ({
              SuggestionType: 'carBrand',
              CarBrandId: x.id,
            } as SearchParams)
        );

      this._carContextService.setSearchParams([...carTypes, ...carBrands]);
    });
  }
}
