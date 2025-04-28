import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CarBrand } from '../../models/car-brand.model';

@Injectable({
  providedIn: 'root',
})
export class CarBrandService {
  private _url = '/carBrands';
  private _http = inject(HttpClient);

  getCarBrands(): Observable<CarBrand[]> {
    return this._http.get<CarBrand[]>(this._url);
  }
}
