import { Component, signal } from '@angular/core';
import { UserService } from '../core/services/user.service';
import { Router } from '@angular/router';
import { AuthService } from '../core/services/auth.service';
import { FormControl, Validators } from '@angular/forms';
import { merge } from 'rxjs';
import {takeUntilDestroyed} from '@angular/core/rxjs-interop';
import { checkValidUcEmail } from '../core/validators/mail-uc-edu.validator';

@Component({
  selector: 'signup-page',
  templateUrl: './signup-page.component.html',
  styleUrls: ['./signup-page.component.scss']
})
export class SignupPageComponent {
  readonly email = new FormControl('', [Validators.required, Validators.email, checkValidUcEmail()]);
  errorMessage = signal('');

constructor(
  private _authService: AuthService,
  private _router: Router
  ) {
    merge(this.email.statusChanges, this.email.valueChanges)
    .pipe(takeUntilDestroyed())
    .subscribe(() => this.updateErrorMessage());
  }

  signup() {
    if (this.email.valid) {
      this._authService.register(this.email.value!).subscribe();
      this._router.navigate(['/login'], {state: { email: this.email.value}});
    }
  }

  updateErrorMessage() {
    if (this.email.hasError('required')) {
      this.errorMessage.set("Email is required");
    } else  if (this.email.hasError('email')){
      this.errorMessage.set("Invalid Email");
    } else if (this.email.hasError("invalidUcEmail")) {
      this.errorMessage.set("Not a UC Email");
    }
  }
}
