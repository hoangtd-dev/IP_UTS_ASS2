import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { CarType } from '../../models/car-type.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class CarTypeService {
  private _url = '/carTypes';
  private _http = inject(HttpClient);

  getCarTypes(): Observable<CarType[]> {
    return this._http.get<CarType[]>(this._url);
  }
}
