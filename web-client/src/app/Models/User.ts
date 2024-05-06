import { IReview } from "./Review";

export interface IUser {
    id: number,
    email: string,
    timeCreated: Date,
    reviews: IReview[]
}

export class User {
    
}

export class RegisterRequestBody {
    private email: string;
    constructor(_email: string) {
        this.email = _email;
    }
}

export class AuthenticationRequestBody {
    private email: string;
    private password: string;
    constructor(_email: string, _password: string) {
        this.email = _email;
        this.password = _password;
    }
}

export interface IAuthenticationResponse {
    jwt: string;
}

export interface IDecodedJwt {
    aud: string,
    email: string,
    exp: number,
    iss: string,
    nbf: number,
    sub: string
}