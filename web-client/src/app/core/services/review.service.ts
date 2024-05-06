import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { IReview, SaveReview } from "src/app/Models/Review";

@Injectable({
    providedIn: 'root'
})

export class ReviewService {
    constructor(private _http: HttpClient) 
    {}
    getReviewsByBuildingId(buildingId: number): Observable<IReview[]> {
        return this._http.get<IReview[]>(`/api/Review/${buildingId}`);
    }
    addReview(review: SaveReview): Observable<IReview[]> {
        return this._http.post<IReview[]>('/api/Review', review);
    }
}