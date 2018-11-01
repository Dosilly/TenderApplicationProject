import { Component, OnInit } from '@angular/core';
import { LoginRequest } from '../_models/loginRequest';
import { Router } from '@angular/router';
import { LoginService } from '../services/login.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  userInput = new LoginRequest();

  constructor(private router: Router, private loginService: LoginService) {}

  ngOnInit() {
  }

  login() {
    this.router.navigateByUrl('/users');
  }

}
