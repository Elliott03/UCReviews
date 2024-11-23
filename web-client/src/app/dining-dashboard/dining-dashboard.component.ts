import { Component } from '@angular/core';
import { IDiningHall } from '../Models/DiningHall';
import { DiningService } from '../core/services/dining.service';
import { Router } from '@angular/router';
import { AuthService } from '../core/services/auth.service';

@Component({
  selector: 'dining-dashboard',
  templateUrl: './dining-dashboard.component.html',
  styleUrl: './dining-dashboard.component.scss',
})
export class DiningDashboardComponent {
  diningHalls: IDiningHall[] = [];
  prev = 0;
  perPage = 6;
  constructor(
    private _diningService: DiningService,
    private _router: Router,
    public _authService: AuthService
  ) {}
  ngOnInit(): void {
    if (this._authService.isLoggedIn()) {
      this.loadDiningHalls();
    } else {
      this._router.navigate(['/signup']);
    }
  }
  loadDiningHalls() {
    this._diningService
      .getDiningHalls({
        perPage: this.perPage,
        prev: this.prev,
      })
      .subscribe((diningHalls) => {
        this.diningHalls.push(...diningHalls);
      });
  }

  getDiningRatingTitle(diningHall: IDiningHall) {
    if (!diningHall.reviewSummary?.averageRating) {
      return 'Not yet rated';
    }
    return `${diningHall.reviewSummary.averageRating} stars`;
  }
  diningHallClick(diningHall: IDiningHall) {
    this._router.navigate(['/dashboard/dining', diningHall.nameQueryParameter]);
  }

  onScroll(): void {
    this.prev += this.perPage;
    this.loadDiningHalls();
  }
}
