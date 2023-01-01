import { Injectable } from '@angular/core';
import axios from 'axios';
import { BehaviorSubject } from 'rxjs/internal/BehaviorSubject';

export interface Product {
  id: number,
  name: string,
  price: number,
  categoryId: number
}

@Injectable({
  providedIn: 'root'
})
export class StoreService {

  private UsernameSource = new BehaviorSubject<string>("");
  private ProductsByCategorySource = new BehaviorSubject(new Map<string, Product[]>);
  username = this.UsernameSource.asObservable();
  productsByCategory = this.ProductsByCategorySource.asObservable();

  constructor() { }

  setUsername(username: string){
    this.UsernameSource.next(username)
  }

  async updateProductsByCategories(){
    const response = await axios.get('https://localhost:7290/Product/category');
    this.ProductsByCategorySource.next(response.data);
  }
  

}
