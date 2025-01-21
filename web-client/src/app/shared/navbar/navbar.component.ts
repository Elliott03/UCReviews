import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/core/services/auth.service';

@Component({
  selector: 'navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss'],
})
export class NavbarComponent {
  constructor(private _authService: AuthService, private router: Router) {}

  isLoggedIn() {
    return this._authService.isLoggedIn();
  }

  logout() {
    this._authService.logout();
    this.router.navigate(['/signup']);
  }
}
