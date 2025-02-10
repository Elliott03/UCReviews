import { IReview } from './Review';

/**
 * User - safe to include in front end code (no passwords)
 */
export interface IReviewUser {
  id: number;
  email: string;
  username?: string;
}

export interface IUser extends IReviewUser {
  timeCreated: Date;
  reviews: IReview[];
}

export class User {}

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
  aud: string;
  email: string;
  exp: number;
  iss: string;
  nbf: number;
  sub: string;
}
