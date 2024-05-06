import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from '../core/services/user.service';
import * as jwt_decode from 'jwt-decode';

import { secretKey } from '../secret';
import { Token } from '@angular/compiler';
import { AuthService } from '../core/services/auth.service';
import { IDecodedJwt } from '../Models/User';

@Component({
  selector: 'login-page',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.scss']
})
export class LoginPageComponent{
  email: string = "";
  password: string = "";
  isError: boolean = false;
  errorMessage: string = "";
  constructor(
    private _userService: UserService,
    private _router: Router,
    private _authService: AuthService
  )
  {
    const currentNavigation = this._router.getCurrentNavigation();
    if (currentNavigation && currentNavigation.extras && currentNavigation.extras.state) {
      this.email = currentNavigation.extras.state['email'];
    }
  }

  async loginClick() {
    this.password = this.password.toLowerCase().trim();
    if (this.isValidPassword()) {
      try {
        const response = await this._authService.login(this.email, this.password).toPromise();
        if (response) {
          const sub = localStorage.getItem('sub');
          const user = await this._userService.getUserById(Number(sub)).toPromise();
          if (user) {
            localStorage.setItem('user', JSON.stringify(user));
            this._router.navigate(['/dashboard']);
          }
        }
      } catch (error) {
        this.isError = true;
        this.errorMessage = "Incorrect Password";
      }
    }
  }
  
  isValidPassword(): boolean {
    if (!this.isNumeric(this.password)) {
      this.isError = true;
      this.errorMessage = "Password must be numeric"
      return false;
    }
    if (this.password.length < 6) {
      this.isError = true;
      this.errorMessage = "Password must be 6 characters";
      return false;
    }

    this.isError = false;
    this.errorMessage = "";
    return true;
  }

  isNumeric(input: string): boolean {
    return /^[0-9]+$/.test(input);
  }

}
