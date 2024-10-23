import { Component } from '@angular/core';
import {
  IParkingGarage,
  IParkingGarageWithRating,
} from '../Models/ParkingGarage';
import { GarageService } from '../core/services/garage.service';
import { Router } from '@angular/router';
import { AuthService } from '../core/services/auth.service';

@Component({
  selector: 'garage-dashboard',
  templateUrl: './garage-dashboard.component.html',
  styleUrl: './garage-dashboard.component.scss',
})
export class GarageDashboardComponent {
  garages: IParkingGarageWithRating[] = [];
  constructor(
    private _garageService: GarageService,
    private _router: Router,
    public _authService: AuthService
  ) {}
  ngOnInit(): void {
    if (this._authService.isLoggedIn()) {
      this._garageService.getParkingGarages(true).subscribe((garages) => {
        this.garages = garages;
      });
    } else {
      this._router.navigate(['/signup']);
    }
  }
  getGarageRatingTitle(garage: IParkingGarageWithRating) {
    if(!garage.averageRating) {
      return "Not yet rated";
    }
    return `${garage.averageRating} stars`;
  }
}
