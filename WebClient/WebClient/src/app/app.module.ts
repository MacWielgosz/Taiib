import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ProductComponent } from './product/product.component';
import { OrderComponent } from './order/order.component';
import { BasketComponent } from './basket/basket.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { registerLocaleData } from '@angular/common';
import localeEn from '@angular/common/locales/en';
import { DetailProductComponent } from './detail-product/detail-product.component';
import { OrdersallComponent } from './ordersall/ordersall.component';
import { OrdersaDetailsComponent } from './ordersa-details/ordersa-details.component';
import { ProductAddComponent } from './product-add/product-add.component';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import {MatCardModule} from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatButtonModule } from '@angular/material/button';
import { MatListModule } from '@angular/material/list';
import {MatTableModule} from '@angular/material/table';
import { MatIconModule } from '@angular/material/icon';

registerLocaleData(localeEn);

@NgModule({
  declarations: [
    AppComponent,
    ProductComponent,
    OrderComponent,
    BasketComponent,
    DetailProductComponent,
    OrdersallComponent,
    OrdersaDetailsComponent,
    ProductAddComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    MatCardModule,
    MatFormFieldModule,
    MatInputModule,
    MatCheckboxModule,
    MatButtonModule,
    MatListModule,
    MatTableModule,
    MatIconModule
  ],
  providers: [
    provideAnimationsAsync(),
    provideAnimationsAsync('noop')
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
(window as any).globalUserId = 1;
