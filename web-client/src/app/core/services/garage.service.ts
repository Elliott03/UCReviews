import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IParkingGarage } from 'src/app/Models/ParkingGarage';

@Injectable({
  providedIn: 'root',
})
export class GarageService {
  constructor(private _http: HttpClient) {}

  getParkingGarage(
    slug_or_id: string,
    includeReviews: boolean = false
  ): Observable<IParkingGarage> {
    return this._http.get<IParkingGarage>(
      `/api/ParkingGarage/${slug_or_id}?includeReviews=${includeReviews}`
    );
  }

  getParkingGarages(): Observable<IParkingGarage[]> {
    return this._http.get<IParkingGarage[]>(`/api/ParkingGarage`);
  }
}
