import { Component } from '@angular/core';
import { IParkingGarage } from '../Models/ParkingGarage';
import { GarageService } from '../core/services/garage.service';
import { NavigationEnd, Router } from '@angular/router';
import { AuthService } from '../core/services/auth.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'garage-dashboard',
  templateUrl: './garage-dashboard.component.html',
  styleUrl: './garage-dashboard.component.scss',
})
export class GarageDashboardComponent {
  hasChildRoute = false;
  garages: IParkingGarage[] = [];
  prev = 0;
  perPage = 6;
  constructor(
    private _garageService: GarageService,
    private _router: Router,
    public _authService: AuthService,
    private _route: ActivatedRoute
  ) {}
  ngOnInit(): void {
    if (this._authService.isLoggedIn()) {
      this.loadGarages();
    } else {
      this._router.navigate(['/signup']);
    }
    this._router.events.subscribe((event) => {
      if (event instanceof NavigationEnd) {
        this.hasChildRoute = this._route.children.length > 0;
      }
    });
  }
  loadGarages() {
    this._garageService
      .getParkingGarages({
        perPage: this.perPage,
        prev: this.prev,
      })
      .subscribe((garages) => {
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
