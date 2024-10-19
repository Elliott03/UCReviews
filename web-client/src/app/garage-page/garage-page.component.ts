import { Component, OnInit } from '@angular/core';
import { AuthService } from '../core/services/auth.service';
import { ActivatedRoute, Router } from '@angular/router';
import { DormService } from '../core/services/dorm.service';
import { ReviewService } from '../core/services/review.service';
import { GarageService } from '../core/services/garage.service';
import { firstValueFrom } from 'rxjs';
import { IParkingGarage } from '../Models/ParkingGarage';

@Component({
  selector: 'garage-page',
  standalone: true,
  imports: [],
  templateUrl: './garage-page.component.html',
  styleUrl: './garage-page.component.scss',
})
export class GaragePageComponent implements OnInit {
  garage?: IParkingGarage;
  JSON: any;

  constructor(
    private route: ActivatedRoute,
    private _garageService: GarageService,
    private _authService: AuthService,
    private _router: Router
  ) {}

  async ngOnInit() {
    if (!this._authService.isLoggedIn()) {
      this._router.navigate(['/signup']);
      return;
    }
    const slug = this.route.snapshot.params['slug'];
    this.JSON = JSON;
    this.garage = await firstValueFrom(
      this._garageService.getParkingGarage(slug, true)
    );

    if (!this.garage) {
      this._router.navigate(['/dashboard', 'garages']);
    }
  }
}
