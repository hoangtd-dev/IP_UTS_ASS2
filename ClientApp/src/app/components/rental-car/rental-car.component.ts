import { ChangeDetectionStrategy, Component } from '@angular/core';
import { FilterSidebarComponent } from './filter-sidebar/filter-sidebar.component';
import { CarComponent } from './car/car.component';

@Component({
  selector: 'app-rental-car',
  imports: [FilterSidebarComponent, CarComponent],
  templateUrl: './rental-car.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class RentalCarComponent {}
