import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IDiningHall } from 'src/app/Models/DiningHall';
import { QueryParams } from '../types/QueryParams';
import { buildQueryParams } from '../helpers/buildQueryParams';

@Injectable({
  providedIn: 'root',
})
export class DiningService {
  constructor(private _http: HttpClient) {}

  getDiningHalls({ perPage, prev }: QueryParams): Observable<IDiningHall[]> {
    const queryParams = buildQueryParams<QueryParams>({
      perPage: perPage,
      prev: prev,
    });
    return this._http.get<IDiningHall[]>(`/api/DiningHall?${queryParams}`);
  }

  getDiningHall(slug: string): Observable<IDiningHall> {
    return this._http.get<IDiningHall>(`/api/DiningHall/${slug}`);
  }
}
