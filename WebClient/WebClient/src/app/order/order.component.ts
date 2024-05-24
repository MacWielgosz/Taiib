import { Component } from '@angular/core';
import { OrdersService } from '../orders.service';
import { Router } from '@angular/router';
import { OrderDTO } from '../model/OrderDTO.interface';

@Component({
  selector: 'app-order',
  templateUrl: './order.component.html',
  styleUrl: './order.component.css'
})
export class OrderComponent {
  public data:OrderDTO[]=[];
  displayedColumns: string[] = ['id', 'userID', 'date'];
  constructor(private service:OrdersService, private router : Router){
    this.getOrders();
  }
  private getOrders():void{
    this.service.getOne( (window as any).globalUserId
      ).subscribe({
      next: (res) =>{
        this.data=res;
      },
      error: (err) => console.error(err),
      complete:()=> console.log('complete')
    });
  }

  public route(event : number):void{
    this.router.navigate(['/orders/'+ event]); // Przekierowanie do listy produktów
  }
}
