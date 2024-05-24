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
  public getBasketsByUserId(userid:number): Observable<BasketPositionDTO[]>{
    return this.httpClient.get<BasketPositionDTO[]>('https://localhost:7154/basketPosition/'+userid);
  }
  deleteBasketPosition(basketid: number): Observable<void> {
    return this.httpClient.delete<void>('https://localhost:7154/basketPosition/'+basketid)
  }
  
  updateBasketPosition(basketid: number, amount:number): Observable<void> {
    return this.httpClient.put<void>('https://localhost:7154/basketPosition/'+basketid+", "+amount,{})
  }
  
  addBasketPosition(basketPosition:BasketPositionRequestDTO): Observable<void> {
    return this.httpClient.post<void>('https://localhost:7154/basketPosition',basketPosition );
  }
  makeOrder():Observable<void>
  {
    return this.httpClient.post<void>('https://localhost:7154/makeOrder/'+(window as any).globalUserId ,{});
  }
}
