import { Component } from '@angular/core';
import { AuthenticationService } from './services/login.service';
import { Router } from '@angular/router';
import { LoginResponse } from './_models/loginResponse';
import { AuthGuard } from './guards/auth.guard';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  constructor(private authenticationService: AuthenticationService, private router: Router, private guard: AuthGuard) { }

  logout() {
      this.authenticationService.logout();
      this.router.navigateByUrl('/login');
  }

}
