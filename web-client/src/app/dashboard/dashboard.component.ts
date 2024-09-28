import { Component, OnInit } from '@angular/core';
import { BuildingService } from '../core/services/building.service';
import { ISmallBuilding } from '../Models/Building';
import { Router } from '@angular/router';
import { AuthService } from '../core/services/auth.service';

@Component({
  selector: 'dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit{
  buildings: ISmallBuilding[] = [];
  constructor(
    private _buildingService: BuildingService,
    private _router: Router,
    public _authService: AuthService
    )
  {}
  ngOnInit(): void {
    if (this._authService.isLoggedIn()) {
      this._buildingService.getBuildings().subscribe(buildings => {
        this.buildings = buildings;
    });
    } else {
      this._router.navigate(['/signup']);
    }
  }

  dormClick(building: ISmallBuilding) {
    this._router.navigate(['/dorm', building.nameQueryParameter]);
  }
}
