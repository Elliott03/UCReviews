import { Component, OnInit } from '@angular/core';
import { DormService } from '../core/services/dorm.service';
import { ISmallDorm } from '../Models/Dorm';
import { Router } from '@angular/router';
import { AuthService } from '../core/services/auth.service';

@Component({
  selector: 'dorm-dashboard',
  templateUrl: './dorm-dashboard.component.html',
  styleUrls: ['./dorm-dashboard.component.scss']
})
export class DormDashboardComponent implements OnInit{
  dorms: ISmallDorm[] = [];
  constructor(
    private _dormService: DormService,
    private _router: Router,
    public _authService: AuthService
    )
  {}
  ngOnInit(): void {
    if (this._authService.isLoggedIn()) {
      this._dormService.getDorms().subscribe(dorms => {
        this.dorms = dorms;
    });
    } else {
      this._router.navigate(['/signup']);
    }
  }

  dormClick(dorm: ISmallDorm) {
    this._router.navigate(['/dashboard/housing', dorm.nameQueryParameter]);
  }
}
