import {
  ChangeDetectionStrategy,
  Component,
  inject,
  OnInit,
} from '@angular/core';
import { MatIconModule } from '@angular/material/icon';
import { CarContextService } from '../../rental-car/services/car-context.service';

@Component({
  selector: 'app-order-confirmation',
  standalone: true,
  imports: [MatIconModule],
  templateUrl: './order-confirmation.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class OrderConfirmationComponent implements OnInit {
  private _carContextService = inject(CarContextService);

  car = this._carContextService.getCarValue();

  ngOnInit(): void {
    this._carContextService.clearReservationForm();
    this._carContextService.clearCar();
  }
}
