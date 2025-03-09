import { Component, OnInit } from '@angular/core';
import { IParkingGarage } from '../Models/ParkingGarage';
import { GarageService } from '../core/services/garage.service';
import { NavigationEnd, Router } from '@angular/router';
import { AuthService } from '../core/services/auth.service';
import { ActivatedRoute } from '@angular/router';

@Component({
    selector: 'garage-dashboard',
    templateUrl: './garage-dashboard.component.html',
    styleUrls: ['./garage-dashboard.component.scss'],
    standalone: false
})
export class GarageDashboardComponent implements OnInit {
  hasChildRoute = false;
  garages: IParkingGarage[] = [];
  searchTerm: string = '';
  prev = 0;
  perPage = 6;

  constructor(
    private _garageService: GarageService,
    private _router: Router,
    public _authService: AuthService,
    private _route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.loadGarages();
    this._router.events.subscribe((event) => {
      this.hasChildRoute = this._route.children.length > 0;
      if (
        event instanceof NavigationEnd &&
        this._router.url.includes('/dashboard/garages/')
      ) {
        this.searchTerm = '';
      }
    });
  }

  loadGarages() {
    this._garageService
      .getParkingGarages({
        perPage: this.perPage,
        prev: this.prev,
        searchTerm: this.searchTerm,
      })
      .subscribe((garages) => {
        garages.sort((a, b) => a.id - b.id);
        this.garages.push(...garages);
      });
  }

  onSearchChange(searchTerm: string) {
    this.searchTerm = searchTerm;
    this.garages = [];
    this.prev = 0;
    this.loadGarages();
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

  filteredGarages(): IParkingGarage[] {
    return this.garages.filter((garage) =>
      garage.name.toLowerCase().includes(this.searchTerm.toLowerCase())
    );
  }

  trackById(index: number, item: IParkingGarage) {
    return item.id;
  }
}
