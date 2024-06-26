import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProductComponent } from './product/product.component';
import { OrderComponent } from './order/order.component';
import { BasketComponent } from './basket/basket.component';
import { DetailProductComponent } from './detail-product/detail-product.component';
import { OrdersallComponent } from './ordersall/ordersall.component';
import { OrdersaDetailsComponent } from './ordersa-details/ordersa-details.component';
import { ProductAddComponent } from './product-add/product-add.component';
import { LoginComponent } from './login/login.component';
import { AuthGuard } from './auth.guard';

const routes: Routes = [
  { path : 'login', component: LoginComponent },
  { path: 'products', component: ProductComponent, canActivate: [AuthGuard] },
  { path: 'orders', component: OrderComponent, canActivate: [AuthGuard] },
  { path: 'orders/all', component: OrdersallComponent, canActivate: [AuthGuard], data: { expectedRole: 'admin' } },
  { path : 'basket', component: BasketComponent, canActivate: [AuthGuard] },
  { path : 'products/add', component: ProductAddComponent, canActivate: [AuthGuard], data: { expectedRole: 'admin' }  },
  { path: 'products/:productId', component: DetailProductComponent, canActivate: [AuthGuard] },
  { path : 'orders/all/:orderId', component: OrdersaDetailsComponent, canActivate: [AuthGuard] },
  { path : 'orders/:orderId', component: OrdersaDetailsComponent, canActivate: [AuthGuard] },
  { path:'', redirectTo:'/', pathMatch:'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
