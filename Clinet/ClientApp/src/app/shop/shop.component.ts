import { Component, OnInit } from '@angular/core';
import { IBrand } from '../shared/models/brand';
import { IType } from '../shared/models/type';
import { ShopService } from './shop.service';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.css']
})
export class ShopComponent implements OnInit {

  products: IProduct[];
  brands:IBrand[];
  types:IType[];

  constructor(private shopService:ShopService) { }

  ngOnInit() {
    this.GetProducts();
    this.GetBrands();
    this.GetTypes();
  }

  GetProducts(){
    this.shopService.GetProducts().subscribe(responce =>{
      this.products = responce.data
    },error =>{
      console.log(error);
    });
  }

  GetBrands(){
    this.shopService.GetBrands().subscribe(responce =>{
      this.brands = responce
    },error =>{
      console.log(error);
    });
  }

  GetTypes(){
    this.shopService.GetTypes().subscribe(responce =>{
      this.types = responce
    },error =>{
      console.log(error);
    });
  }

}
