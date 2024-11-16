import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import {
  IParkingGarage,
  IParkingGarageWithRating,
} from 'src/app/Models/ParkingGarage';
import { getAvgRating } from '../helpers/getAvgRating';
import { QueryParams, ReviewableQueryParam } from '../types/QueryParams';
import { buildQueryParams } from '../helpers/buildQueryParams';

@Injectable({
  providedIn: 'root',
})
export class GarageService {
  constructor(private _http: HttpClient) {}

  getParkingGarages({
    includeReviews,
    perPage,
    prev,
  }: QueryParams): Observable<IParkingGarageWithRating[]> {
    const queryParams = buildQueryParams({
      includeReviews: includeReviews,
      perPage: perPage,
      prev: prev,
    });
    const garages = this._http.get<IParkingGarage[]>(
      `/api/ParkingGarage?${queryParams}`
    );
    return garages.pipe(
      map((garages) =>
        garages.map((garage) => {
          return {
            ...garage,
            averageRating: getAvgRating(garage.reviews),
          };
        })
      )
    );
  }

  getParkingGarage(
    slug_or_id: string,
    { includeReviews }: ReviewableQueryParam
  ): Observable<IParkingGarageWithRating> {
    const queryParams = buildQueryParams({
      includeReviews: includeReviews,
    });
    const garage = this._http.get<IParkingGarage>(
      `/api/ParkingGarage/${slug_or_id}?${queryParams}`
    );
    return garage.pipe(
      map((garage) => {
        return {
          ...garage,
          averageRating: getAvgRating(garage.reviews),
        };
      })
    );
  }
}
