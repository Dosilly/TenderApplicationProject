import { Component } from '@angular/core';
import { AuthenticationService } from './services/login.service';
import { Router } from '@angular/router';
import { LoginResponse } from './_models/loginResponse';
import { AuthGuard } from './guards/auth.guard';
import { environment } from '../environments/environment';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  constructor(public authenticationService: AuthenticationService, private router: Router, private guard: AuthGuard) { }
  production = environment.production;

  logout() {
      this.authenticationService.logout();
      window.location.reload();
      // this.router.navigateByUrl('/login');
  }
}
