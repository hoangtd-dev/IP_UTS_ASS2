import {
  ChangeDetectionStrategy,
  Component,
  inject,
  OnInit,
} from '@angular/core';
import { AsyncPipe, CommonModule } from '@angular/common';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { CarContextService } from '../../rental-car/services/car-context.service';

@Component({
  selector: 'app-car-details',
  standalone: true,
  imports: [CommonModule, MatIconModule, MatButtonModule, AsyncPipe],
  templateUrl: './car-details.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class CarDetailsComponent {
  private _carContextService = inject(CarContextService);

  car$ = this._carContextService.getCar();
  rentalPeriod$ = this._carContextService.getRentalPeriod();
}
