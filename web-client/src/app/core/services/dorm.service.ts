import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { ILargeDorm, ISmallDorm } from "src/app/Models/Dorm";

@Injectable({
    providedIn: 'root'
})

export class DormService {
    constructor(
        private _http: HttpClient
    ) {}

    getDorms(): Observable<ISmallDorm[]> {
        return this._http.get<ISmallDorm[]>('/api/Dorm');
    }

    getDorm(queryParam: string): Observable<ILargeDorm> {
        return this._http.get<ILargeDorm>(`/api/Dorm/${queryParam}`);
    }
}