import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { IParkingGarage, IParkingGarageWithRating } from 'src/app/Models/ParkingGarage';
import { IReview } from 'src/app/Models/Review';
import { getAvgRating } from '../helpers/getAvgRating';

@Injectable({
  providedIn: 'root',
})
export class GarageService {
  constructor(private _http: HttpClient) {}

  getParkingGarage(
    slug_or_id: string,
    includeReviews: boolean = false
  ): Observable<IParkingGarageWithRating> {
    const garage = this._http.get<IParkingGarage>(
      `/api/ParkingGarage/${slug_or_id}?includeReviews=${includeReviews}`
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

  getParkingGarages(): Observable<IParkingGarageWithRating[]> {
    const garages = this._http.get<IParkingGarage[]>(`/api/ParkingGarage`);
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
