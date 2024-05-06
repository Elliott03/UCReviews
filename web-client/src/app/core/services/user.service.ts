import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { AuthenticationRequestBody, IAuthenticationResponse, IUser, RegisterRequestBody } from "src/app/Models/User";
import { Observable, map, catchError } from "rxjs";
 
@Injectable({
    providedIn: 'root'
})

export class UserService {

    constructor(private _http: HttpClient) {}
    
    getUserById(id: number): Observable<IUser> {
        return this._http.get<IUser>(`/api/User/${id}`);
    }

}