import { Component } from '@angular/core';
import {
  IDiningHall,
  IDiningHallWithRating,
} from '../Models/DiningHall';
import { DiningService } from '../core/services/dining.service';
import { Router } from '@angular/router';
import { AuthService } from '../core/services/auth.service';

@Component({
  selector: 'dining-dashboard',
  templateUrl: './dining-dashboard.component.html',
  styleUrl: './dining-dashboard.component.scss',
})
export class DiningDashboardComponent {
  diningHalls: IDiningHallWithRating[] = [];
  constructor(
    private _diningService: DiningService,
    private _router: Router,
    public _authService: AuthService
  ) {}
  ngOnInit(): void {
    if (this._authService.isLoggedIn()) {
      this._diningService.getDiningHalls().subscribe(diningHalls => {
        this.diningHalls = diningHalls;
    });
    } else {
      this._router.navigate(['/signup']);
    }
  }
  getDiningRatingTitle(diningHall: IDiningHallWithRating) {
    if(!diningHall.averageRating) {
      return "Not yet rated";
    }
    return `${diningHall.averageRating} stars`;
  }
  diningHallClick(diningHall: IDiningHall) {
    this._router.navigate(['/dashboard/dining', diningHall.nameQueryParameter]);
  }
}
