import { Component } from '@angular/core';
import { UserService } from '../core/services/user.service';
import { Router } from '@angular/router';
import { AuthService } from '../core/services/auth.service';
@Component({
  selector: 'signup-page',
  templateUrl: './signup-page.component.html',
  styleUrls: ['./signup-page.component.scss']
})
export class SignupPageComponent {
  email: string = "";
  isError: boolean = false;
  errorMessage: string = "";
  constructor(
    private _authService: AuthService,
    private _router: Router
    ) {}

    signupClick() {
      this.email = this.email.toLowerCase().trim();
      if (this.isValidEmail()) {
        this._authService.register(this.email).subscribe();
        this._router.navigate(['/login'], { state: { email: this.email }});
      }
    }

    isValidEmail(): boolean {
      const emailEnding = "@mail.uc.edu";
      if (!this.email.endsWith(emailEnding)) {
        this.isError = true;
        this.errorMessage = `Email must end with ${emailEnding}`;
        return false;
      }
      if (this.email.length <= emailEnding.length) {
        this.isError = true;
        this.errorMessage = "Email must be valid length";
        return false;
      }
      this.isError = false;
      this.errorMessage = "";
      return true;
    }
}
