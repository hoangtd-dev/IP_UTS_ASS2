import { Routes } from '@angular/router';

export const routes: Routes = [
  {
    path: '',
    pathMatch: 'full',
    redirectTo: 'rental-car',
  },
  {
    path: 'rental-car',
    loadComponent: () =>
      import('./components/rental-car/rental-car.component').then(
        (m) => m.RentalCarComponent
      ),
  },
  {
    path: 'reservation',
    loadComponent: () =>
      import('./components/reservation/reservation.component').then(
        (m) => m.ReservationComponent
      ),
  },
  {
    path: 'order-confirmation',
    loadComponent: () =>
      import(
        './components/reservation/order-confirmation/order-confirmation.component'
      ).then((m) => m.OrderConfirmationComponent),
  },
];
