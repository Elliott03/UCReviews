import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../core/services/auth.service';
import { Category } from '../Models/category.model';

@Component({
  selector: 'overall-dashboard',
  templateUrl: './overall-dashboard.component.html',
  styleUrls: ['./overall-dashboard.component.scss'],
})
export class OverallDashboardComponent implements OnInit {
  categories: Category[] = [
    {
      name: 'Residence Halls',
      description: 'View and review residence halls on campus.',
      image: 'housing.jpg',
      id: 1,
      path: '/dashboard/housing',
    },
    {
      name: 'Parking Garages',
      description: 'View and review parking garages on campus.',
      image: 'parking.jpg',
      id: 2,
      path: '/dashboard/garages',
    },
    {
      name: 'Dining Halls',
      description: 'Rate and review all dining locations.',
      image: 'dining-halls.jpg',
      id: 3,
      path: '/dashboard/dining',
    },
  ];

  constructor(private _router: Router, public _authService: AuthService) {}

  ngOnInit(): void {
    if (!this._authService.isLoggedIn()) {
      this._router.navigate(['/signup']);
    }
  }

  trackByCategoryId(index: number, category: Category): number {
    return category.id;
  }
}
