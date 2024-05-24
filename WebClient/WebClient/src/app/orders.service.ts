import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { OrderDTO } from './model/OrderDTO.interface';
import { OrderPositionDTO } from './model/OrderPositionDTO.interface';

@Injectable({
  providedIn: 'root'
})
export class OrdersService {
  constructor(private httpClient:HttpClient) { }
  public getAll():Observable<OrderDTO[]>{
    return this.httpClient.get<OrderDTO[]>('https://localhost:7154/orderall');
  }
  public getOne(userID:number):Observable<OrderDTO[]>{
    return this.httpClient.get<OrderDTO[]>('https://localhost:7154/getOrder/'+userID);
  }
  public getPositions(orderID:number):Observable<OrderPositionDTO[]>{
    return this.httpClient.get<OrderPositionDTO[]>('https://localhost:7154/oders/'+orderID);
  }
}
