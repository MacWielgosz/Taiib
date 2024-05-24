import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ProductDTO } from './model/ProductDTO.interface';
import { Sort } from './model/Sort.interface';
import { ProductRequestDTO } from './model/ProductRequestDTO.interface';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  updateProduct(id: number, product: ProductRequestDTO): Observable<any> {
    const url = `https://localhost:7154/productEdit/${id}`;
    return this.httpClient.put(url, product, {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    });
  }


  constructor(private httpClient:HttpClient) { }

  public get(sort:Sort): Observable<ProductDTO[]>{
    return this.httpClient.get<ProductDTO[]>('https://localhost:7154/product',{
      params:{
        size:sort.size ?? 10,
        from:sort.from ?? 0,
        name:sort.name ?? "",
        isActive:sort.isActive ?? 2,
        asc:sort.asc ?? true
      }
    });
  }
  addProduct(product: ProductRequestDTO): Observable<void> {
    const url = `https://localhost:7154/productAdd`;
    return this.httpClient.post<void>(url, product, {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    });
  }
  
  deleteProduct(productId: number): Observable<void> {
    return this.httpClient.delete<void>('https://localhost:7154/productDelete/'+productId)
  }
  activateProduct(productId: number): Observable<void> {
    return this.httpClient.put<void>('https://localhost:7154/producPut/'+productId,{})
  }
  getProductById(productId: number) : Observable<ProductDTO> {
    return this.httpClient.get<ProductDTO>('https://localhost:7154/product/' + productId)
  }
}
