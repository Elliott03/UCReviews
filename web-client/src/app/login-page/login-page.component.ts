import { Component, OnInit, Signal, signal } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from '../core/services/user.service';
import * as jwt_decode from 'jwt-decode';
import {takeUntilDestroyed} from '@angular/core/rxjs-interop';
import { secretKey } from '../secret';
import { Token } from '@angular/compiler';
import { AuthService } from '../core/services/auth.service';
import { IDecodedJwt } from '../Models/User';
import { FormControl, Validators } from '@angular/forms';
import { merge } from 'rxjs';
import { checkIsNumber } from '../core/validators/pin-password.validator';

@Component({
  selector: 'login-page',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.scss']
})
export class LoginPageComponent{
  email: string = "";
  password = new FormControl('', [Validators.required, checkIsNumber(), Validators.maxLength(6), Validators.minLength(6)]); // Second validator matches to a 6 digit number
  //password: string = "";
  isError: boolean = false;
  validationErrorMessage = signal('');
  authenticationError: boolean = false;
  authenticationErrorMessage: Signal<string> = signal("Incorrect Password");

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
    merge(this.password.statusChanges, this.password.valueChanges)
    .pipe(takeUntilDestroyed())
    .subscribe(() => this.updateErrorMessage());
  }

  async login() {
    if (this.password.valid) {
      try {
        console.log(this.email, this.password.value);
        const response = await this._authService.login(this.email, this.password.value!.toString()).toPromise();
        if (response) {
          const sub = localStorage.getItem('sub');
          const user = await this._userService.getUserById(Number(sub)).toPromise();
          if (user) {
            localStorage.setItem('user', JSON.stringify(user));
            this._router.navigate(['/dashboard']);
          }
        }
      } catch (error) {
        this.authenticationError = true;
        console.error(error);
      }
    }

    // this.password = this.password.toLowerCase().trim();
    // if (this.isValidPassword()) {
    //   try {
    //     const response = await this._authService.login(this.email, this.password).toPromise();
    //     if (response) {
    //       const sub = localStorage.getItem('sub');
    //       const user = await this._userService.getUserById(Number(sub)).toPromise();
    //       if (user) {
    //         localStorage.setItem('user', JSON.stringify(user));
    //         this._router.navigate(['/dashboard']);
    //       }
    //     }
    //   } catch (error) {
    //     this.isError = true;
    //     this.errorMessage = "Incorrect Password";
    //   }
    // }
  }
  
  // isValidPassword(): boolean {
  //   if (!this.isNumeric(this.password)) {
  //     this.isError = true;
  //     this.errorMessage = "Password must be numeric"
  //     return false;
  //   }
  //   if (this.password.length < 6) {
  //     this.isError = true;
  //     this.errorMessage = "Password must be 6 characters";
  //     return false;
  //   }

  //   this.isError = false;
  //   this.errorMessage = "";
  //   return true;
  // }

  // isNumeric(input: string): boolean {
  //   return /^[0-9]+$/.test(input);
  // }

  updateErrorMessage() {

    if (this.password.hasError("required")) {
      this.validationErrorMessage.set("Password is required");
    } else if (this.password.hasError("notANumber")) {
      this.validationErrorMessage.set("Password must be a number");
    } else if (this.password.hasError("minlength") || this.password.hasError("maxlength")) {
      this.validationErrorMessage.set("Password should be 6 digits");
    } 
  }
}
