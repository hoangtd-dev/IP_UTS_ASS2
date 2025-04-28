import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CarBrand } from '../../models/car-brand.model';
import { CreateReservationForm } from '../../models/reservation-form.model';

@Injectable({
  providedIn: 'root',
})
export class CarReservationService {
  private _url = '/carReservation';
  private _http = inject(HttpClient);

  createReservation(reservation: CreateReservationForm): Observable<void> {
    return this._http.post<void>(this._url, reservation);
  }
}
