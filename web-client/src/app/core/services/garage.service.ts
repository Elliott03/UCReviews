import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import {
  IParkingGarage,
  IParkingGarageWithRating,
} from 'src/app/Models/ParkingGarage';
import { getAvgRating } from '../helpers/getAvgRating';
import { QueryParams } from '../types/QueryParams';

@Injectable({
  providedIn: 'root',
})
export class GarageService {
  constructor(private _http: HttpClient) {}

  getParkingGarage(
    slug_or_id: string,
    { includeReviews, perPage, prev }: QueryParams
  ): Observable<IParkingGarageWithRating> {
    const garage = this._http.get<IParkingGarage>(
      `/api/ParkingGarage/${slug_or_id}?includeReviews=${includeReviews}&perPage=${perPage}&prev=${prev}`
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

  getParkingGarages({
    includeReviews,
    perPage,
    prev,
  }: QueryParams): Observable<IParkingGarageWithRating[]> {
    const garages = this._http.get<IParkingGarage[]>(
      `/api/ParkingGarage?includeReviews=${includeReviews}&perPage=${perPage}&prev=${prev}`
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
}
