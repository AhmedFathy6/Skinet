import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { IBrand } from '../shared/models/brand';
import { IType } from '../shared/models/type';

@Injectable({
  providedIn: 'root'
})
export class ShopService {

  baseUrl ='https://localhost:5001/api/'
  constructor(private http: HttpClient) { }

  GetProducts(){
    return this.http.get<IPagination>(this.baseUrl+'products?pagesize=50');
  }

  
  GetBrands(){
    return this.http.get<IBrand[]>(this.baseUrl+'products/brands');
  }

  GetTypes(){
    return this.http.get<IType[]>(this.baseUrl+'products/types');
  }
}
