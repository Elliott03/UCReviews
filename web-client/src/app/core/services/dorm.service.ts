import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import {
  ILargeDorm,
  ILargeDormWithRating,
  ISmallDorm,
  ISmallDormWithRating,
} from 'src/app/Models/Dorm';
import { IReview } from 'src/app/Models/Review';

@Injectable({
  providedIn: 'root',
})
export class DormService {
  constructor(private _http: HttpClient) {}

  getAvgRating(reviews: IReview[]): number {
    const sum = reviews.reduce((sum, review) => sum + review.starRating, 0);
    return sum / reviews.length;
  }

  getDorms(): Observable<ISmallDormWithRating[]> {
    const dorms = this._http.get<ISmallDorm[]>('/api/Dorm');
    return dorms.pipe(
      map((dorms) =>
        dorms.map((dorm) => {
          console.log({dorm})
          return {
            ...dorm,
            averageRating: this.getAvgRating(dorm.reviews),
          };
        })
      )
    );
  }

  getDorm(queryParam: string): Observable<ILargeDormWithRating> {
    const dorm = this._http.get<ILargeDorm>(`/api/Dorm/${queryParam}`);
    return dorm.pipe(
      map((dorm) => {
        return {
          ...dorm,
          averageRating: this.getAvgRating(dorm.reviews),
        };
      })
    );
  }
}
