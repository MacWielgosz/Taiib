import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { BasketPositionDTO } from './model/BasketPositionDTO.interface';
import { BasketPositionRequestDTO } from './model/BasketPositionRequestDTO.interface';
@Injectable({
  providedIn: 'root'
})
export class BasketService {
  constructor(private httpClient:HttpClient) { }
  public getBasketsByUserId(userID:number): Observable<BasketPositionDTO[]>{
    return this.httpClient.get<BasketPositionDTO[]>('https://localhost:7154/basketPosition/'+userID);
  }
  deleteBasketPosition(basketID: number): Observable<void> {
    return this.httpClient.delete<void>('https://localhost:7154/basketPosition/'+basketID)
  }
  
  updateBasketPosition(basketID: number, amount:number): Observable<void> {
    return this.httpClient.put<void>('https://localhost:7154/basketPosition/'+basketID+", "+amount,{})
  }
  
  addProduct(basketPosition:BasketPositionRequestDTO): Observable<void> {
    return this.httpClient.post<void>('https://localhost:7154/basketPosition',{
      params:{
          productID:basketPosition.productID ?? 0,
          userID:basketPosition.userID ?? 0,
          amount:basketPosition.amount ?? 0
      }
    });
  }
}
