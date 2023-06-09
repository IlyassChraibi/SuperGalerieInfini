import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  HttpHeaders
} from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {

  constructor() {}

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    console.log("je suis dans l'intercepteur");
    request = request.clone({
      setHeaders: {
        'Authorization': 'Bearer ' + localStorage.getItem("token")
      }
    })

    return next.handle(request);
  }
}
