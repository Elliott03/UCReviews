import {
  HttpErrorResponse,
  HttpEvent,
  HttpHandler,
  HttpInterceptor,
  HttpRequest,
} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable, throwError } from 'rxjs';
import { Router } from '@angular/router';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {
  constructor(private _router: Router) {}

  intercept(
    req: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {
    const idToken = localStorage.getItem('id_token');

    let reqWithBearer: HttpRequest<any> | null = null;

    if (idToken) {
      reqWithBearer = req.clone({
        headers: req.headers.set('Authorization', 'Bearer ' + idToken),
      });
    }

    return next.handle(reqWithBearer || req).pipe(
      catchError((err: HttpErrorResponse) => {
        if (err.status === 403) {
          this._router.navigate(['/signup']);
        }
        return throwError(() => err);
      })
    );
  }
}
