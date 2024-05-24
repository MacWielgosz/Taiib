import { Component } from '@angular/core';
import { ProductDTO } from '../model/ProductDTO.interface';
import { ProductService } from '../product.service';
import { Sort } from '../model/Sort.interface';
import { Router } from '@angular/router';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrl: './product.component.css'
})
export class ProductComponent {

  public data:ProductDTO[]=[];
  public from:number=0;
  public size:number=10;
  public acs:boolean=true;
  public name:string="";  
  public isActive:number= 0;
  constructor(private service:ProductService, private router : Router){
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
}
