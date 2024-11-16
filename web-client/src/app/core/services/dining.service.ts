import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { IDiningHall, IDiningHallWithRating } from 'src/app/Models/DiningHall';
import { getAvgRating } from '../helpers/getAvgRating';
import { QueryParams, ReviewableQueryParam } from '../types/QueryParams';
import { buildQueryParams } from '../helpers/buildQueryParams';

@Injectable({
  providedIn: 'root',
})
export class DiningService {
  constructor(private _http: HttpClient) {}

  getDiningHalls({
    includeReviews,
    perPage,
    prev,
  }: QueryParams): Observable<IDiningHallWithRating[]> {
    const queryParams = buildQueryParams<QueryParams>({
      includeReviews: includeReviews,
      perPage: perPage,
      prev: prev,
    });
    const diningHalls = this._http.get<IDiningHall[]>(
      `/api/DiningHall?${queryParams}`
    );
    return diningHalls.pipe(
      map((diningHalls) =>
        diningHalls.map((diningHall) => {
          return {
            ...diningHall,
            averageRating: getAvgRating(diningHall.reviews),
          };
        })
      )
    );
  }

  getDiningHall(slug: string): Observable<IDiningHallWithRating> {
    const queryParams = buildQueryParams<ReviewableQueryParam>({
      includeReviews: true,
    });
    const diningHall = this._http.get<IDiningHall>(
      `/api/DiningHall/${slug}?${queryParams}`
    );
    return diningHall.pipe(
      map((diningHall) => {
        return {
          ...diningHall,
          averageRating: getAvgRating(diningHall.reviews),
        };
      })
    );
  }
}
