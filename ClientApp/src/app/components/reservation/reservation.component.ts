import { ChangeDetectionStrategy, Component, inject } from '@angular/core';
import { CarDetailsComponent } from './car-details/car-details.component';
import { ReservationFormComponent } from './reservation-form/reservation-form.component';
import { CarContextService } from '../rental-car/services/car-context.service';
import { AsyncPipe } from '@angular/common';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-reservation',
  imports: [
    CarDetailsComponent,
    ReservationFormComponent,
    AsyncPipe,
    MatIconModule,
    MatButtonModule,
    RouterModule,
  ],
  templateUrl: './reservation.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class ReservationComponent {
  private _carContextService = inject(CarContextService);

  car$ = this._carContextService.getCar();
}
