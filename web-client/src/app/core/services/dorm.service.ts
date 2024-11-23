import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ILargeDorm, ISmallDorm } from 'src/app/Models/Dorm';
import { QueryParams } from '../types/QueryParams';
import { buildQueryParams } from '../helpers/buildQueryParams';

@Injectable({
  providedIn: 'root',
})
export class DormService {
  constructor(private _http: HttpClient) {}

  getDorms({ perPage, prev }: QueryParams): Observable<ISmallDorm[]> {
    const queryParams = buildQueryParams<QueryParams>({
      perPage: perPage,
      prev: prev,
    });
    return this._http.get<ISmallDorm[]>(`/api/Dorm?${queryParams}`);
  }

  getDorm(slug: string): Observable<ILargeDorm> {
    return this._http.get<ILargeDorm>(`/api/Dorm/${slug}`);
  }
}
