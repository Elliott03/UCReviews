import { Component } from '@angular/core';
import { IParkingGarage } from '../Models/ParkingGarage';
import { GarageService } from '../core/services/garage.service';
import { Router } from '@angular/router';
import { AuthService } from '../core/services/auth.service';

@Component({
  selector: 'garage-dashboard',
  templateUrl: './garage-dashboard.component.html',
  styleUrl: './garage-dashboard.component.scss',
})
export class GarageDashboardComponent {
  garages: IParkingGarage[] = [];
  prev = 0;
  perPage = 6;
  constructor(
    private _garageService: GarageService,
    private _router: Router,
    public _authService: AuthService
  ) {}
  ngOnInit(): void {
    if (this._authService.isLoggedIn()) {
      this.loadGarages();
    } else {
      this._router.navigate(['/signup']);
    }
  }
  loadGarages() {
    this._garageService
      .getParkingGarages({
        perPage: this.perPage,
        prev: this.prev,
      })
      .subscribe((garages) => {
        garages.sort((a, b) => a.id - b.id);
        this.garages.push(...garages);
      });
  }
  getGarageRatingTitle(garage: IParkingGarage) {
    if (!garage.reviewSummary?.averageRating) {
      return 'Not yet rated';
    }
    return `${garage.reviewSummary.averageRating} stars`;
  }
  onScroll(): void {
    this.prev += this.perPage;
    this.loadGarages();
  }
}
