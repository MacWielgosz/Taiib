import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {

  constructor(private authService: AuthService, private router: Router) {}

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
    if (this.authService.IsUserAuthenticated()) {
      if (route.data && route.data['expectedRole']) {
        const isAdmin = this.authService.isAdmin();
        if (isAdmin && route.data['expectedRole'] === 'admin') {
          return true;
        } else {
          console.log('User is not authorized to access this route.');
          this.router.navigate(['/']); // Przekieruj użytkownika na stronę główną lub inną stronę błędu
          return false;
        }
      }
      return true; // Zwróć true, jeśli użytkownik jest zalogowany i nie ma określonej roli
    } else {
      console.log('User is not authenticated.');
      this.router.navigate(['/']); // Przekieruj użytkownika na stronę logowania
      return false;
    }
  }
}
