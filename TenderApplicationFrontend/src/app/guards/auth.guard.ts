import { Injectable, Output, EventEmitter } from '@angular/core';
import { Router, CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { LoginResponse } from '../_models/loginResponse';
import { AuthenticationService } from '../services/login.service';

const helper = new JwtHelperService();

@Injectable()
export class AuthGuard implements CanActivate {

    constructor(private authService: AuthenticationService, private router: Router) { }

    isUserLogged() {
        const currnetUser: LoginResponse = JSON.parse(localStorage.getItem('currentUser'));
        if (currnetUser != null) {
            if (!helper.isTokenExpired(currnetUser.token)) {
                return true;
            } else {
                this.authService.logout();
            }
        }
        return false;
    }

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
        const result = this.isUserLogged();

        if (result) {
          return true;
        }
        this.router.navigate(['/login'], { queryParams: { returnUrl: state.url }});
        return false;
    }
}
