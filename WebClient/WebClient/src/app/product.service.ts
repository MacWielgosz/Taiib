import { HttpClient } from '@angular/common/http';
import { I18NHtmlParser } from '@angular/compiler';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ProductDTO } from './model/ProductDTO.interface';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  constructor(private httpClient:HttpClient) { }

  public get(from:number , to:number ): Observable<ProductDTO[]>{
    return this.httpClient.get<ProductDTO[]>('https://localhost:7154/product/',{
      params:{
        from:from ??0,
        to: to ?? 10
      }
    });
  }

  
}
