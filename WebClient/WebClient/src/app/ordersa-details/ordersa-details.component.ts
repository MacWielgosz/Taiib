import { Component, OnInit } from '@angular/core';
import { OrdersService } from '../orders.service';
import { ActivatedRoute, Router } from '@angular/router';
import { OrderPositionDTO } from '../model/OrderPositionDTO.interface';

@Component({
  selector: 'app-ordersa-details',
  templateUrl: './ordersa-details.component.html',
  styleUrl: './ordersa-details.component.css'
})
export class OrdersaDetailsComponent implements OnInit {
  data:OrderPositionDTO[]=[];
  constructor(
    private route: ActivatedRoute,
    private router: Router, // Dodano router
    private orderService: OrdersService
  ) {}

  ngOnInit() {
    const orderIdParam = this.route.snapshot.paramMap.get('orderId');
    if (orderIdParam !== null) {
      const orderId = +orderIdParam;
      this.orderService.getPositions(orderId).subscribe({
        next: (res) =>{
          this.data=res;
        },
        error: (err) => console.error(err),
        complete:()=> console.log('complete')
      });
    }
  }
}
