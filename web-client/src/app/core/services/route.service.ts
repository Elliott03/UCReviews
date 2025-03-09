import { Injectable } from "@angular/core";
import { AuthService } from "./auth.service";


@Injectable({
    providedIn: 'root'
})

export class RouteService {

    constructor(private _authService: AuthService) {}

    getDefaultRoute(): string {
        if (this._authService.isLoggedIn()) {
            return '/dashboard'
        } else {
            return '/signup'
        }
    }
}
