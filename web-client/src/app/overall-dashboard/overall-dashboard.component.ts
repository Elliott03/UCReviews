import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../core/services/auth.service';
import { Category } from '../Models/category.model';

@Component({
  selector: 'overall-dashboard',
  templateUrl: './overall-dashboard.component.html',
  styleUrls: ['./overall-dashboard.component.scss']
})

export class OverallDashboardComponent implements OnInit {

  categories: Category[] = [
    {
      name: 'Residence Halls',
      description: 'View and review residence halls on campus.',
      image: 'housing.jpg',
      id: 1
    },
    {
      name: 'Parking Garages',
      description: 'View and review parking garages on campus.',
      image: 'parking.jpg',
      id: 2
    },
    {
      name: 'Dining Halls',
      description: 'Rate and review all dining locations.',
      image: 'dining-halls.jpg',
      id: 3
    }
  ];

  constructor(
    private _router: Router,
    public _authService: AuthService
  ) {}

  ngOnInit(): void {
    if (!this._authService.isLoggedIn()) {
      this._router.navigate(['/signup']);
    }
  }

  categoryClick(category: Category) {
    switch (category.name) {
      case 'Residence Halls':
        this._router.navigate(['/dashboard/housing']);
        break;
      case 'Parking Garages':
        this._router.navigate(['/dashboard/garages']);
        break;
      case 'Dining Halls':
        this._router.navigate(['/dashboard/dining']);
        break;
      default:
        this._router.navigate(['/dashboard/']);
    }
  }

  trackByCategoryId(index: number, category: Category): number {
    return category.id;
  }
}
