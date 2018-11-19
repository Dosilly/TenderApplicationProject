import { Component, OnInit } from '@angular/core';
import { LoginRequest } from '../_models/loginRequest';
import { Router } from '@angular/router';
import { AuthenticationService } from '../services/login.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  userInput = new LoginRequest();

  constructor(private router: Router, private authenticationService: AuthenticationService) {}

  ngOnInit() {
  }

  login() {
    this.authenticationService.login(this.userInput.username, this.userInput.password)
      .subscribe(
        data => {
          switch (data.role) {
            case 'ADM':
            this.router.navigateByUrl('/users');
              break;
            case 'ANAL':
            this.router.navigateByUrl('/requirements');
             break;
            case 'MAN':
            this.router.navigateByUrl('/tenders');
             break;
            case 'OFF':
            this.router.navigateByUrl('/tenders');
            break;
            default:
              break;
          }
        },
        error => {
        });
  }
}
