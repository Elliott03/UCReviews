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
  }: QueryParams): Observable<IParkingGarage[]> {
    const queryParams = buildQueryParams({
      perPage: perPage,
      prev: prev,
    });
    const garages = this._http.get<IParkingGarage[]>(
      `/api/ParkingGarage?${queryParams}`
    );
    return garages;
  }

  getParkingGarage(slug_or_id: string): Observable<IParkingGarage> {
    const garage = this._http.get<IParkingGarage>(
      `/api/ParkingGarage/${slug_or_id}`
    );
    return garage;
  }
}
