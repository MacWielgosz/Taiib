import { Component } from '@angular/core';
import { BasketService } from '../basket.service';
import { Router } from '@angular/router';
import { BasketPositionDTO } from '../model/BasketPositionDTO.interface';

@Component({
  selector: 'app-basket',
  templateUrl: './basket.component.html',
  styleUrl: './basket.component.css'
})
export class BasketComponent {
  public data:BasketPositionDTO[]=[];

  constructor(private service:BasketService, private router : Router){
    this.getOrders();
  }
  private getOrders():void{
    this.service.getBasketsByUserId( (window as any).globalUserId
      ).subscribe({
      next: (res) =>{
        this.data=res;
      },
      error: (err) => console.error(err),
      complete:()=> console.log('complete')
    });
  }
}
