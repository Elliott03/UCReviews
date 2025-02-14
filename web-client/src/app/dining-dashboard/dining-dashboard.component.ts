import { Component } from '@angular/core';
import { IDiningHall } from '../Models/DiningHall';
import { DiningService } from '../core/services/dining.service';
import { ActivatedRoute, NavigationEnd, Router } from '@angular/router';
import { AuthService } from '../core/services/auth.service';
import { BreadcrumbService } from 'xng-breadcrumb';

@Component({
  selector: 'dining-dashboard',
  templateUrl: './dining-dashboard.component.html',
  styleUrl: './dining-dashboard.component.scss',
})
export class DiningDashboardComponent {
  hasChildRoute = false;
  diningHalls: IDiningHall[] = [];
  searchTerm: string = ''; // New property for search
  prev = 0;
  perPage = 6;

  constructor(
    private _diningService: DiningService,
    private _router: Router,
    private _authService: AuthService,
    private _route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    if (this._authService.isLoggedIn()) {
      this.loadDiningHalls();
    } else {
      this._router.navigate(['/signup']);
    }

    // Subscribe to router events to reset or clear the search term on navigation
    this._router.events.subscribe((event) => {
      if (event instanceof NavigationEnd) {
        this.hasChildRoute = this._route.children.length > 0;

        // Only clear search term if navigating to a specific card or page
        if (this._router.url.includes('/dashboard/dining/')) {
          this.searchTerm = '';  // Clear the search term
        }
      }
    });
  }

  loadDiningHalls() {
    this._diningService
      .getDiningHalls({
        perPage: this.perPage,
        prev: this.prev,
      })
      .subscribe((diningHalls) => {
        diningHalls.sort((a, b) => a.id - b.id);
        this.diningHalls.push(...diningHalls);
      });
  }

  getDiningRatingTitle(diningHall: IDiningHall) {
    if (!diningHall.reviewSummary?.averageRating) {
      return 'Not yet rated';
    }
    return `${diningHall.reviewSummary.averageRating} stars`;
  }

  onScroll(): void {
    this.prev += this.perPage;
    this.loadDiningHalls();
  }

  filteredDiningHalls(): IDiningHall[] {
    return this.diningHalls.filter(diningHall =>
      diningHall.name.toLowerCase().includes(this.searchTerm.toLowerCase())
    );
  }
}