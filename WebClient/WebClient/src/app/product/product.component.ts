import { Component } from '@angular/core';
import { ProductDTO } from '../model/ProductDTO.interface';
import { ProductService } from '../product.service';
import { Router } from '@angular/router';
import { BasketService } from '../basket.service';
import {MatButtonModule} from '@angular/material/button';
import { AuthService } from '../auth.service';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrl: './product.component.css',
})
export class ProductComponent {
addToBasket(productId: number):void {
  this.serviceBasket.addBasketPosition({
    productID:productId,
    userID:(window as any).globalUserId,
    amount : 1
  }).subscribe();
}

  public data:ProductDTO[]=[];
  public from:number=0;
  public size:number=10;
  public acs:boolean=false;
  public name:string="";  
  public isActive:boolean= true;
  constructor(private service:ProductService, private router : Router, private serviceBasket:BasketService, private authService : AuthService){
    this.getProducts();
  }
  
  private getProducts():void{
    this.service.get(
      {
        from:this.from,
        size:this.size,
        asc:this.acs,
        name:this.name,
        isActive:this.isActive
      }
      ).subscribe({
      next: (res) =>{
        this.data=res;
      },
      error: (err) => console.error(err),
      complete:()=> console.log('complete')
    });
  }
  public getSort():void{
    this.getProducts();
  }
  public route(event : number):void{
    this.router.navigate(['/products/'+ event]); // Przekierowanie do listy produktów
  }
  public add() :void{
    this.router.navigate(['products/add']); // Przekierowanie do listy produktów
  }
  
  IsUserAuthenticated(): boolean {
    return this.authService.IsUserAuthenticated();
  }
  isAdmin(){
    return this.authService.isAdmin();
  }

}
