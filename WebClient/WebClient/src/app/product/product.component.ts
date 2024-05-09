import { Component } from '@angular/core';
import { ProductDTO } from '../model/ProductDTO.interface';
import { ProductService } from '../product.service';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrl: './product.component.css'
})
export class ProductComponent {
  public data:ProductDTO[]=[];
  public from:number=0;
  public to:number=10;
  
  constructor(private service:ProductService){
    this.getProducts();
  }
  private getProducts():void{
    this.service.get(this.from, this.to).subscribe({
      next: (res) =>{
        this.data=res;
      },
      error: (err) => console.error(err),
      complete:()=> console.log('complete')
    });
  }

}
