import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProductComponent } from './product/product.component';
import { OrderComponent } from './order/order.component';
import { BasketComponent } from './basket/basket.component';
import { DetailProductComponent } from './detail-product/detail-product.component';
import { OrdersallComponent } from './ordersall/ordersall.component';
import { OrdersaDetailsComponent } from './ordersa-details/ordersa-details.component';
import { ProductAddComponent } from './product-add/product-add.component';

const routes: Routes = [
  {path: 'products', component:ProductComponent},
  {path: 'orders' , component:OrderComponent},
  { path: 'orders/all',component:OrdersallComponent},
  {path : 'basket',component:BasketComponent},
  {path : 'products/add' , component:ProductAddComponent},
  {path: 'products/:productId', component:DetailProductComponent},
  {path : 'orders/all/:orderId', component:OrdersaDetailsComponent},
  {path : 'orders/:orderId', component:OrdersaDetailsComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
