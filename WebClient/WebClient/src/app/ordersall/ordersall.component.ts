import { Component } from '@angular/core';
import { OrdersService } from '../orders.service';
import { Router } from '@angular/router';
import { OrderDTO } from '../model/OrderDTO.interface';

@Component({
  selector: 'app-ordersall',
  templateUrl: './ordersall.component.html',
  styleUrl: './ordersall.component.css'
})


export class OrdersallComponent {
  public data:OrderDTO[]=[];
  constructor(private service:OrdersService, private router : Router){
    this.getOrders();
  }
  displayedColumns: string[] = ['id', 'userID', 'date'];

  private getOrders():void{
    this.service.getAll(
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
