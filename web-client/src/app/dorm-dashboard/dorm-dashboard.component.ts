import { Component, OnInit } from '@angular/core';
import { DormService } from '../core/services/dorm.service';
import { ISmallDorm } from '../Models/Dorm';
import { ActivatedRoute, NavigationEnd, Router } from '@angular/router';
import { AuthService } from '../core/services/auth.service';

@Component({
  selector: 'dorm-dashboard',
  templateUrl: './dorm-dashboard.component.html',
  styleUrls: ['./dorm-dashboard.component.scss'],
})
export class DormDashboardComponent implements OnInit {
  hasChildRoute = false;
  dorms: ISmallDorm[] = [];
  prev = 0;
  perPage = 6;
  constructor(
    private _dormService: DormService,
    private _router: Router,
    public _authService: AuthService,
    private _route: ActivatedRoute
  ) {}
  ngOnInit(): void {
    if (this._authService.isLoggedIn()) {
      this.loadDorms();
    } else {
      this._router.navigate(['/signup']);
    }
    this._router.events.subscribe((event) => {
      if (event instanceof NavigationEnd) {
        this.hasChildRoute = this._route.children.length > 0;
      }
    });
  }
  loadDorms() {
    this._dormService
      .getDorms({
        perPage: this.perPage,
        prev: this.prev,
      })
      .subscribe((dorms) => {
        this.dorms.push(...dorms);
      });
  }
  getDormRatingTitle(dorm: ISmallDorm) {
    if (!dorm.reviewSummary?.averageRating) {
      return 'Not yet rated';
    }
    return `${dorm.reviewSummary.averageRating} stars`;
  }
  onScroll(): void {
    this.prev += this.perPage;
    this.loadDorms();
  }
}
