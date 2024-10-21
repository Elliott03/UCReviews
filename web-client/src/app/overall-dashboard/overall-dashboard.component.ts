import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../core/services/auth.service';

@Component({
  selector: 'overall-dashboard',
  templateUrl: './overall-dashboard.component.html',
  styleUrl: './overall-dashboard.component.scss'
})

export class OverallDashboardComponent implements OnInit{

  constructor(

    private _router: Router,
    public _authService: AuthService
    )
  {}
  ngOnInit(): void {
    if (!this._authService.isLoggedIn()) {
      this._router.navigate(['/signup']);
    }
  }

  categoryClick(category: any) {
    // Navigate to the corresponding dashboard
    console.log(`${category.name} clicked!`);

    switch (category.name) {
      case 'Residence Halls':
        this._router.navigate(['/dashboard/housing']);
        break;
      case 'Parking Garages':
        this._router.navigate(['/dashboard/parking']);
        break;
      case 'Dining Halls':
        this._router.navigate(['/dashboard/']);
        break;
      default:
        this._router.navigate(['/dashboard/']); // Fallback route
    }
  }

  categories = [
    {
      name: 'Residence Halls',
      description: 'View and review residence halls on campus.',
      image: 'housing.jpg'
    },
    {
      name: 'Parking Garages',
      description: 'View and review parking garages on campus.',
      image: 'parking.jpg'
    },
    {
      name: 'Dining Halls',
      description: 'Rate and review all dining locations.',
      image: 'dining-halls.jpg'
    }]
}