import { Component } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Router } from '@angular/router';
import { NgForm } from '@angular/forms';
import { AuthService } from '../auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  invalidLogin: boolean = false;

  constructor(private http: HttpClient, private router: Router, private authService : AuthService) {}

  login(form: NgForm) {
    const credentials = JSON.stringify(form.value);
    this.http.post("https://localhost:7154/login", credentials, {
      headers: new HttpHeaders({
        "Content-Type": "application/json"
      })
    }).subscribe(response => {
      const token = (response as any).token;
      localStorage.setItem("jwt", token);
      this.invalidLogin = false;
    }, err => {
      this.invalidLogin = true;
    });
  }
  
  IsUserAuthenticated(): boolean {
    return this.authService.IsUserAuthenticated();
  }
  
}
