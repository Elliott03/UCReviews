import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import {
  ILargeDorm,
  ILargeDormWithRating,
  ISmallDorm,
} from 'src/app/Models/Dorm';

@Injectable({
  providedIn: 'root',
})
export class DormService {
  constructor(private _http: HttpClient) {}

  getDorms(): Observable<ISmallDorm[]> {
    return this._http.get<ISmallDorm[]>('/api/Dorm');
  }

  getDorm(queryParam: string): Observable<ILargeDormWithRating> {
    const dorm = this._http.get<ILargeDorm>(`/api/Dorm/${queryParam}`);
    return dorm.pipe(
      map((dorm) => {
        const sum = dorm.reviews.reduce(
          (sum, review) => sum + review.starRating,
          0
        );
        const averageRating = sum / dorm.reviews.length;
        return {
          ...dorm,
          averageRating,
        };
      })
    );
  }
}
