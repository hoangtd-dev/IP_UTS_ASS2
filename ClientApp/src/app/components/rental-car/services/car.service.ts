import { HttpClient, HttpParams } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { SearchParams } from '../models/search.model';
import { Car } from '../../../models/car.model';
import { Observable } from 'rxjs';
import { SearchSuggestion } from '../../../models/search-suggestion.model';

@Injectable({
  providedIn: 'root',
})
export class CarService {
  private _http = inject(HttpClient);
  private _url = '/cars';

  public getCars(searchParams: SearchParams[] | null): Observable<Car[]> {
    let params = new HttpParams();

    if (searchParams) {
      params = params.set('searchSuggestions', JSON.stringify(searchParams));
    }

    return this._http.get<Car[]>(this._url, { params });
  }

  public getSearchSuggestions(
    searchText: string
  ): Observable<SearchSuggestion[]> {
    let params = new HttpParams();

    if (searchText) {
      params = params.set('searchTerm', searchText);
    }

    return this._http.get<SearchSuggestion[]>(
      `${this._url}/search-suggestions`,
      {
        params,
      }
    );
  }
}
