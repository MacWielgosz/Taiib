import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { jwtDecode } from 'jwt-decode';
export interface DecodeToken{
  'http://schemas.microsoft.com/ws/2008/06/identity/claims/role'?: string;
  'http://schemas.microsoft.com/ws/2008/06/identity/claims/primarysid'?: string;
}


@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private jwtHelper: JwtHelperService) { }

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
        return jwtDecode<DecodeToken>(token);
      } catch (error) {
        console.error('Invalid token:', error);
        return null;
      }
    }
    return null;
  }

  getUserRoles(): string[] {
    const decodedToken = this.getDecodedToken();
    if (decodedToken && decodedToken['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'] || '') {
      return Array.isArray(decodedToken['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'] || '') ? decodedToken['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'] || '' : [decodedToken['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'] || ''];
    }
    return [];
  }
  
  getUserID(): string[] {
    const decodedToken = this.getDecodedToken();
    if (decodedToken && decodedToken['http://schemas.microsoft.com/ws/2008/06/identity/claims/primarysid'] || '' ) {
      return Array.isArray(decodedToken['http://schemas.microsoft.com/ws/2008/06/identity/claims/primarysid'] || '') ? decodedToken['http://schemas.microsoft.com/ws/2008/06/identity/claims/primarysid'] || '' : [decodedToken['http://schemas.microsoft.com/ws/2008/06/identity/claims/primarysid'] || ''];
    }
    return [];
  }

  isAdmin(): boolean {
    const roles = this.getUserRoles();
    return roles.includes("admin");
  }

  logOut() {
    localStorage.removeItem("jwt");
  }
}
