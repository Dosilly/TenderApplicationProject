import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { LoginResponse } from '../_models/loginResponse';
import { Subject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';

const address = 'http://localhost:3708';

@Injectable()
export class AuthenticationService {
    constructor(
        private http: HttpClient,
    ) { }

    private authenticationStateChangeSource = new Subject<boolean>();
    public authenticationStateChange = this.authenticationStateChangeSource.asObservable();
    public currentUser: Observable<LoginResponse> = JSON.parse(localStorage.getItem('currentUser'));

    login(username: string, password: string) {
        return this.http.post<LoginResponse>(address + '/api/login', { username: username, password: password })
            .pipe(map(user => {
                if (user && user.token) {
                    localStorage.setItem('currentUser', JSON.stringify(user));
                    this.authenticationStateChangeSource.next(true);
                    this.currentUser = JSON.parse(localStorage.getItem('currentUser'));
                }

                return user;
            }));
    }

    logout() {
        localStorage.removeItem('currentUser');
        this.authenticationStateChangeSource.next(false);
    }
}
