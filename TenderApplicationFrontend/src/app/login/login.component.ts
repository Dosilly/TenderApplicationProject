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
          this.router.navigateByUrl('/users');
        },
        error => {
        });
  }
}
