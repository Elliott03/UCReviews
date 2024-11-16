import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import {
  ILargeDorm,
  ILargeDormWithRating,
  ISmallDorm,
  ISmallDormWithRating,
} from 'src/app/Models/Dorm';
import { getAvgRating } from '../helpers/getAvgRating';
import { QueryParams, ReviewableQueryParam } from '../types/QueryParams';
import { buildQueryParams } from '../helpers/buildQueryParams';

@Injectable({
  providedIn: 'root',
})
export class DormService {
  constructor(private _http: HttpClient) {}

  getDorms({
    includeReviews,
    perPage,
    prev,
  }: QueryParams): Observable<ISmallDormWithRating[]> {
    const queryParams = buildQueryParams<QueryParams>({
      includeReviews: includeReviews,
      perPage: perPage,
      prev: prev,
    });
    const dorms = this._http.get<ISmallDorm[]>(`/api/Dorm?${queryParams}`);
    return dorms.pipe(
      map((dorms) =>
        dorms.map((dorm) => {
          return {
            ...dorm,
            averageRating: getAvgRating(dorm.reviews),
          };
        })
      )
    );
  }

  getDorm(slug: string): Observable<ILargeDormWithRating> {
    const queryParams = buildQueryParams<ReviewableQueryParam>({
      includeReviews: true,
    });
    const dorm = this._http.get<ILargeDorm>(`/api/Dorm/${slug}?${queryParams}`);
    return dorm.pipe(
      map((dorm) => {
        return {
          ...dorm,
          averageRating: getAvgRating(dorm.reviews),
        };
      })
    );
  }
}
