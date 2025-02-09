import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IReview, Review, SaveReview, SaveReviewResponse } from 'src/app/Models/Review';
import { PageableQueryParam } from '../types/QueryParams';
import { buildQueryParams } from '../helpers/buildQueryParams';

@Injectable({
  providedIn: 'root',
})
export class ReviewService {
  constructor(private _http: HttpClient) {}

  getReviewsByDormId({
    perPage,
    prev,
    dormId,
  }: PageableQueryParam & { dormId: string }): Observable<IReview[]> {
    const queryParams = buildQueryParams<PageableQueryParam>({
      perPage: perPage,
      prev: prev,
    });
    return this._http.get<IReview[]>(
      `/api/Review/Dorm/${dormId}?${queryParams}`
    );
  }
  getReviewsByParkingGarageId({
    perPage,
    prev,
    parkingGarageId,
  }: PageableQueryParam & { parkingGarageId: string }): Observable<IReview[]> {
    const queryParams = buildQueryParams<PageableQueryParam>({
      perPage: perPage,
      prev: prev,
    });
    return this._http.get<IReview[]>(
      `/api/Review/ParkingGarage/${parkingGarageId}?${queryParams}`
    );
  }
  getReviewsByDiningHallId({
    perPage,
    prev,
    diningHallId,
  }: PageableQueryParam & { diningHallId: string }): Observable<IReview[]> {
    const queryParams = buildQueryParams<PageableQueryParam>({
      perPage: perPage,
      prev: prev,
    });
    return this._http.get<IReview[]>(
      `/api/Review/DiningHall/${diningHallId}?${queryParams}`
    );
  }

  addReview(review: SaveReview): Observable<SaveReviewResponse> {
    return this._http.post<SaveReviewResponse>('/api/Review', review);
  }
  updateVote(review: IReview, vote: string) {
    const queryParams = buildQueryParams({
      voteType: vote
    });
    return this._http.get(`/api/Review/vote/${review.id}?${queryParams}`).subscribe();
  }
}
