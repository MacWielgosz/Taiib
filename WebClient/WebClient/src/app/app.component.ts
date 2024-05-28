import { Component } from '@angular/core';
import { AuthService } from './auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {

  title = 'WebClient';
  constructor(private authService:AuthService){}
 
  logOut() {
    return this.authService.logOut()
  }
  IsUserAuthenticated(): boolean {
    return this.authService.IsUserAuthenticated();
  }
  isAdmin(){
    return this.authService.isAdmin();
  }

}
