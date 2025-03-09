import { Component, OnInit } from '@angular/core';
import { IDiningHall } from '../Models/DiningHall';
import { DiningService } from '../core/services/dining.service';
import { ActivatedRoute, NavigationEnd, Router } from '@angular/router';
import { AuthService } from '../core/services/auth.service';
import { BreadcrumbService } from 'xng-breadcrumb';

@Component({
    selector: 'dining-dashboard',
    templateUrl: './dining-dashboard.component.html',
    styleUrls: ['./dining-dashboard.component.scss'],
    standalone: false
})
export class DiningDashboardComponent implements OnInit {
  hasChildRoute = false;
  diningHalls: IDiningHall[] = [];
  searchTerm: string = '';
  prev = 0;
  perPage = 6;

  constructor(
    private _diningService: DiningService,
    private _router: Router,
    private _authService: AuthService,
    private _route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.loadDiningHalls();

    this._router.events.subscribe((event) => {
      this.hasChildRoute = this._route.children.length > 0;
      if (event instanceof NavigationEnd && this._router.url.includes('/dashboard/dining/')) {
          this.searchTerm = '';
      }
    });
  }

  loadDiningHalls() {
    this._diningService
      .getDiningHalls({
        perPage: this.perPage,
        prev: this.prev,
        searchTerm: this.searchTerm,
      })
      .subscribe((diningHalls) => {
        diningHalls.sort((a, b) => a.id - b.id);
        this.diningHalls.push(...diningHalls);
      });
  }

  onSearchChange(searchTerm: string) {
    this.searchTerm = searchTerm;
    this.diningHalls = [];
    this.prev = 0;
    this.loadDiningHalls();
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

  trackById(index: number, item: IDiningHall) {
    return item.id;
  }
}
