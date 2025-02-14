import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IParkingGarage } from 'src/app/Models/ParkingGarage';
import { QueryParams } from '../types/QueryParams';
import { buildQueryParams } from '../helpers/buildQueryParams';

@Injectable({
  providedIn: 'root',
})
export class GarageService {
  constructor(private _http: HttpClient) {}

  getParkingGarages({
    perPage,
    prev,
    searchTerm, // Include searchTerm here
  }: QueryParams & { searchTerm: string }): Observable<IParkingGarage[]> {
    const queryParams = buildQueryParams({
      perPage: perPage,
      prev: prev,
      searchTerm: searchTerm, // Add searchTerm to the query params
    });
    return this._http.get<IParkingGarage[]>(
      `/api/ParkingGarage?${queryParams}`
    );
  }

  getParkingGarage(slug_or_id: string): Observable<IParkingGarage> {
    return this._http.get<IParkingGarage>(
      `/api/ParkingGarage/${slug_or_id}`
    );
  }
}