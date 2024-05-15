import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProductComponent } from './product/product.component';
import { OrderComponent } from './order/order.component';
import { BasketComponent } from './basket/basket.component';

const routes: Routes = [
  {path: 'products', component:ProductComponent},
  {path: 'orders' , component:OrderComponent},
  { path: 'orders/all',component:OrderComponent},
  {path : 'basket',component:BasketComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
