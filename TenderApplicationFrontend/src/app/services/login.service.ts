import { Injectable } from '@angular/core';
import { LoginRequest } from '../_models/loginRequest';
import { Observable } from 'rxjs';
import {LoginResultModel} from '../_models/loginResult';
import { HttpClient, HttpHeaders } from '@angular/common/http';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
};

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  loginUrl = 'http://localhost:3708/api/login';

  constructor(private http: HttpClient) { }

  login(loginRequest: LoginRequest): Observable<LoginResultModel> {
    return this.http.post<LoginResultModel>(this.loginUrl, loginRequest, httpOptions);
  }
}
