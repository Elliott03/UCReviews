import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import {
  IDiningHall,
  IDiningHallWithRating,
} from 'src/app/Models/DiningHall';
import { IReview } from 'src/app/Models/Review';
import { getAvgRating } from '../helpers/getAvgRating';

@Injectable({
  providedIn: 'root',
})
export class DiningService {
  constructor(private _http: HttpClient) {}

  getDiningHalls(): Observable<IDiningHallWithRating[]> {
    const diningHalls = this._http.get<IDiningHall[]>('/api/DiningHall');
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

  getDiningHall(queryParam: string): Observable<IDiningHallWithRating> {
    const diningHall = this._http.get<IDiningHall>(`/api/DiningHall/${queryParam}`);
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
