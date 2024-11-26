import { Injectable } from "@angular/core";
import { AuthenticationRequestBody, IAuthenticationResponse, IDecodedJwt, IUser, RegisterRequestBody } from "src/app/Models/User";
import { Observable, shareReplay, tap } from "rxjs";
import { HttpClient } from "@angular/common/http";
import * as jwt_decode from 'jwt-decode';
@Injectable({
    providedIn: 'root'
})

export class AuthService  {
    constructor(private _http: HttpClient) {}

    register(email: string): Observable<void> {
        return this._http.post<void>('/api/Authentication/register', new RegisterRequestBody(email));
    }

    login(email: string, password: string): Observable<IAuthenticationResponse> {
        return this._http.post<IAuthenticationResponse>('/api/Authentication/authenticate', new AuthenticationRequestBody(email, password))
        .pipe(
            tap(res => this.setSession(res)),
            shareReplay()
        );
    }
    private setSession(authResult: IAuthenticationResponse) {
        const token = authResult.jwt
        const decodedToken = this.getDecodedJwt(token);
        if (decodedToken) {
            localStorage.setItem('expires_at', decodedToken?.exp.toString());
            localStorage.setItem('sub', decodedToken?.sub);
            localStorage.setItem('id_token', token);
        }
    }
    getUserId() {
        const id = localStorage.getItem('sub');
        if (id) {
            return parseInt(id);
        }
        return -1;
    }
    logout() {
        localStorage.removeItem('id_token');
        localStorage.removeItem('expires_at');
    }
    public isLoggedIn() {
        return localStorage.getItem('id_token') ? true : false;
    }

    getDecodedJwt(token: string): IDecodedJwt | null {
        try {
          return jwt_decode.jwtDecode<IDecodedJwt>(token);
        } catch(Error) {
          return null;
        }
      }


}
