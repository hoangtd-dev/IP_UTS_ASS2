import {
  ChangeDetectionStrategy,
  ChangeDetectorRef,
  Component,
  DestroyRef,
  inject,
  OnInit,
} from '@angular/core';
import {
  FormBuilder,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { CarContextService } from '../../rental-car/services/car-context.service';
import { Router } from '@angular/router';
import { CarReservationService } from '../../../services/services/car-reservation.service';
import { CreateReservationForm } from '../../../models/reservation-form.model';

@Component({
  selector: 'app-reservation-form',
  standalone: true,
  imports: [ReactiveFormsModule],
  templateUrl: './reservation-form.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class ReservationFormComponent implements OnInit {
  reservationForm: FormGroup;
  errorMessage: string | null = null;
  private _carContextService = inject(CarContextService);
  private _fb = inject(FormBuilder);
  private _destroyRef = inject(DestroyRef);
  private _router = inject(Router);
  private _isSubmitted = false;
  private _carReservationService = inject(CarReservationService);
  private _cd = inject(ChangeDetectorRef);

  constructor() {
    this.reservationForm = this._fb.group({
      username: ['', [Validators.required, Validators.minLength(2)]],
      phone: ['', [Validators.required, Validators.pattern('^[0-9]{10}$')]],
      email: ['', [Validators.required, Validators.email]],
      driverLicense: ['', [Validators.required, Validators.minLength(5)]],
      startDate: ['', Validators.required],
      rentalPeriod: [1, [Validators.required, Validators.min(1)]],
    });
  }

  ngOnInit(): void {
    const reservationSubscription = this._carContextService
      .getReservationForm()
      .subscribe((form) => {
        if (form) {
          this.reservationForm.patchValue(form);
          this._carContextService.setRentalPeriod(form.rentalPeriod);
        }
      });

    const rentalPeriodSubscription = this.reservationForm
      .get('rentalPeriod')
      ?.valueChanges.subscribe((value) => {
        this._carContextService.setRentalPeriod(value);
      });

    this._destroyRef.onDestroy(() => {
      reservationSubscription.unsubscribe();
      rentalPeriodSubscription?.unsubscribe();

      if (!this._isSubmitted) {
        this._carContextService.setReservationForm(this.reservationForm.value);
      }
    });
  }

  onCancel() {
    this._router.navigate(['/rental-car']);
  }

  onSubmit() {
    if (this.reservationForm.invalid || this.errorMessage) return;

    const reservation = {
      carId: this._carContextService.getCarValue()?.vin,
      username: this.reservationForm.value.username,
      phone: this.reservationForm.value.phone,
      email: this.reservationForm.value.email,
      driverLicense: this.reservationForm.value.driverLicense,
      startDate: this.reservationForm.value.startDate,
      rentalPeriod: this.reservationForm.value.rentalPeriod,
    } as CreateReservationForm;

    this._carReservationService.createReservation(reservation).subscribe({
      next: () => {
        this._isSubmitted = true;
        this._router.navigate(['/order-confirmation']);
      },
      error: (error) => {
        this.errorMessage = error.error;
        this._cd.markForCheck();
      },
    });
  }
}
