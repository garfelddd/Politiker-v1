import { Injectable } from '@angular/core';
import { UserRegistration } from '../models/user';
import { Observable } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { HttpClient } from '@angular/common/http';
import { BaseService } from './base.service';
import { UserAuth } from '../models/user-auth';

@Injectable({
  providedIn: 'root'
})
export class UserService extends BaseService{

  apiUrl = this.apiUrl + "user/";
  private isLogged: boolean = false;

  constructor(private http: HttpClient) {
    super();
    if (localStorage.getItem('jwtToken'))
      this.isLogged = true;
  }

  register(user: UserRegistration): Observable<any> {
    return this.http.post<UserRegistration>(this.apiUrl + 'register', user)
      .pipe(
        catchError(this.handleError)
      );
  }

  login(credentials: UserAuth): Observable<any> {
    return this.http.post<any>(this.apiUrl + 'login', credentials)
      .pipe(
      map(user => {
        if (user && user.Token) {
          this.saveToken(user.Token);
          this.isLogged = true;
          return true;
        }

      }),
      catchError(this.handleError)
      )
  }
  logout() {
    localStorage.removeItem('jwtToken');
    this.isLogged = false;
  }

  private saveToken(token: string) {
    localStorage.setItem('jwtToken', token);
  }
}
