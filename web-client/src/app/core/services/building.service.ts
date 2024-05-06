import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { ILargeBuilding, ISmallBuilding } from "src/app/Models/Building";

@Injectable({
    providedIn: 'root'
})

export class BuildingService {
    constructor(
        private _http: HttpClient
    ) {}

    getBuildings(): Observable<ISmallBuilding[]> {
        return this._http.get<ISmallBuilding[]>('/api/Building');
    }

    getBuilding(queryParam: string): Observable<ILargeBuilding> {
        return this._http.get<ILargeBuilding>(`/api/Building/${queryParam}`);
    }
}