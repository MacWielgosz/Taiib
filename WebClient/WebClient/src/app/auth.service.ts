import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { jwtDecode } from 'jwt-decode';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private jwtHelper:JwtHelperService,private router:Router){}
  IsUserAuthenticated(){
    const token = localStorage.getItem("jwt");
    if(token && !this.jwtHelper.isTokenExpired(token)){
      return true;
    } 
    else {
      return false;
    }
  }
  private getDecodedToken(): any {
    const token = localStorage.getItem('jwt');
    if (token) {
      try {
        return jwtDecode(token);
      } catch (error) {
        console.error('Invalid token:', error);
        return null;
      }
    }
    return null;
  }

  private getUserRoles(): string[] {
    const decodedToken = this.getDecodedToken();
    if (decodedToken && decodedToken.role) {
      return Array.isArray(decodedToken.role) ? decodedToken.role : [decodedToken.role];
    }
    return [];
  }
  isAdmin(): boolean {
    const roles = this.getUserRoles();
    return roles.includes("admin");
  }

  logOut(){
    localStorage.removeItem("jwt");
  }
}
