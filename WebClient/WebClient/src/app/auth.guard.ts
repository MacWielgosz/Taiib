import { CanActivateFn } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';

export const authGuard: CanActivateFn = (route, state) => {
  const jwtHelper = new JwtHelperService(); // Utwórz instancję JwtHelperService
  const token = localStorage.getItem("jwt");
  if (token) {
    // Sprawdzanie czy token jest wygasły
    const tokenExpirationDate = jwtHelper.getTokenExpirationDate(token);
    const isTokenExpired = tokenExpirationDate && tokenExpirationDate < new Date();
    if (!isTokenExpired) {
      return true; // Zwraca true jeśli token istnieje i nie wygasł
    }
  }
  
  // Przekierowanie do strony logowania jeśli brak tokena lub token wygasł
  return false;
};
