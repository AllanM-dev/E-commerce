import { Component, OnInit } from '@angular/core';
import { Product, StoreService } from '../store.service';

@Component({
  selector: 'app-admin-view',
  templateUrl: './admin-view.component.html',
  styleUrls: ['./admin-view.component.sass']
})
export class AdminViewComponent implements OnInit {

  categoryDict = new Map<string, Product[]>();

  constructor(private storeservice: StoreService) {}

  async ngOnInit(): Promise<void> {
    // call the backend to update the list of products by category
    await this.storeservice.updateProductsByCategories();
    this.storeservice.productsByCategory.subscribe(x => this.categoryDict = x);
  }

  /**
   * Convert into array the dictionary of categories
   */
  getEntities() {
    return Object.keys(this.categoryDict).map((key) => {
      return [key, (this.categoryDict as any)[key]]
    })
  }
}
