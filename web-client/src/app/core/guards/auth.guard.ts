import { Injectable } from "@angular/core";
import { CanActivate, Router, UrlTree } from "@angular/router";
import { Observable } from "rxjs";
import { AuthService } from "../services/auth.service";

@Injectable()

export class AuthGuard implements CanActivate {
    constructor(private _authService: AuthService, private router: Router) {}

    canActivate(): boolean | UrlTree | Observable<boolean | UrlTree> | Promise<boolean | UrlTree> {
        const isLoggedIn: boolean = this._authService.isLoggedIn();
        if(isLoggedIn) {
            return true;
        } else {
            this.router.navigate(['/signup'])
            return false;
        }
    }
    
}