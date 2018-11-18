import { Component } from '@angular/core';
import { AuthenticationService } from './services/login.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  /**
   *
   */
  constructor(private authenticationService: AuthenticationService, private router: Router) {}

  logout() {
      this.authenticationService.logout();
      this.router.navigateByUrl('/login');
  }

}
