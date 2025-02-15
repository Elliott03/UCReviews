import { Component } from '@angular/core';
import { IParkingGarage } from '../Models/ParkingGarage';
import { GarageService } from '../core/services/garage.service';
import { NavigationEnd, Router } from '@angular/router';
import { AuthService } from '../core/services/auth.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'garage-dashboard',
  templateUrl: './garage-dashboard.component.html',
  styleUrls: ['./garage-dashboard.component.scss'],
})
export class GarageDashboardComponent {
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
    if (this._authService.isLoggedIn()) {
      this.loadGarages();
    } else {
      this._router.navigate(['/signup']);
    }

    this._router.events.subscribe((event) => {
      if (event instanceof NavigationEnd) {
        this.hasChildRoute = this._route.children.length > 0;
        
        if (this._router.url.includes('/dashboard/garages/')) {
          this.searchTerm = '';  // Reset search term when navigating to a specific garage page
        }
      }
    });
  }

  loadGarages() {
    this._garageService
      .getParkingGarages({
        perPage: this.perPage,
        prev: this.prev,
        searchTerm: this.searchTerm,  // Pass search term here
      })
      .subscribe((garages) => {
        garages.sort((a, b) => a.id - b.id);
        this.garages.push(...garages);
      });
  }

  onSearchChange(searchTerm: string) {
    this.searchTerm = searchTerm;  // Update the search term
    this.garages = [];  // Reset the list of garages
    this.prev = 0;  // Reset pagination
    this.loadGarages();  // Reload the garages with the new search term
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
    return this.garages.filter(garage =>
      garage.name.toLowerCase().includes(this.searchTerm.toLowerCase())
    );
  }

  trackById(index: number, item: IParkingGarage) {
    return item.id;
  }
}