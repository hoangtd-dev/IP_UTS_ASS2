import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Car } from '../../models/car.model';

@Injectable({
  providedIn: 'root',
})
export class CarService {
  private _url = '/cars';
  private _http = inject(HttpClient);

  getCars(): Observable<Car[]> {
    return this._http.get<Car[]>(this._url);
  }
}
