import { Component, OnInit } from '@angular/core';
import { Product, StoreService } from '../store.service';

interface ProductByCat {
  catName: string,
  products: Product[]
}

@Component({
  selector: 'app-admin-view',
  templateUrl: './admin-view.component.html',
  styleUrls: ['./admin-view.component.sass']
})
export class AdminViewComponent implements OnInit {

  categoryDict = new Map<string, Product[]>();

  constructor(private storeservice: StoreService) {}

  async ngOnInit(): Promise<void> {
    await this.storeservice.updateProductsByCategories();
    this.storeservice.productsByCategory.subscribe(x => this.categoryDict = x);
    console.log(this.categoryDict);
    console.log(Object.keys(this.categoryDict).length);
    console.log(this.getEntities());
  }

  getEntities() {
    return Object.keys(this.categoryDict).map((key) => {
      return [key, (this.categoryDict as any)[key]]
    })
  }
}
