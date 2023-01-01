import { Component, ViewChild } from '@angular/core';
import { IonModal } from '@ionic/angular';
import axios from 'axios';
import { Product, StoreService } from '../store.service';

interface Category {
  id: number,
  name: string
}

@Component({
  selector: 'admin-navbar',
  templateUrl: './admin-navbar.component.html',
  styleUrls: ['./admin-navbar.component.sass']
})
export class AdminNavbarComponent {
  @ViewChild(IonModal)
  modal!: IonModal;
  name: string = '';
  categories: any[] = [];
  newCategoryName: string = '';
  selectedCategory: string = "";
  productName: string = '';
  productPrice: number = 0;
  productImage: Uint8Array | null = null;

  constructor(private storeservice: StoreService) {}

  async addAdmin() {
    await axios.post('https://localhost:7290/User',
      {
        username: this.name,
        isAdmin: true
      }
    );
  }

  async initProductModal(){
    await this.updateCategorySelection();
  }

  async addCategory(){
    await axios.post(`https://localhost:7290/Category?name=${this.newCategoryName}`);
    await this.updateCategorySelection();
    const createCategorySection = document.getElementById('createCategorySection');
    if (createCategorySection !== null) {
      createCategorySection.style.display = "none";
    }
    this.selectedCategory = this.newCategoryName;
  }

  async updateCategorySelection() {
    const response = await axios.get('https://localhost:7290/Category');
    this.categories = response.data;
  }

  selectCategory(){
    const createCategorySection = document.getElementById('createCategorySection');
    if (createCategorySection !== null) {
      if (this.selectedCategory === 'Other') {
        createCategorySection.style.display = "flex";
      } else {
        createCategorySection.style.display = "none";
      }
    }
  }

  validationNumber(event: any) {
    const pattern = /[0-9.,]/;
    let inputChar = String.fromCharCode(event.charCode);

    if (!pattern.test(inputChar)) {
      // invalid character, prevent input
      event.preventDefault();
    }
  }

  uploadImage(){
    
    const inputFile = document.getElementById('inputFile') as HTMLInputElement;
    const preview = document.getElementById('preview') as HTMLImageElement;
    console.log(inputFile);

    if (inputFile && inputFile.files) {
      var file = inputFile.files[0];

      const reader = new FileReader();
  
      // reader.addEventListener("loadend", function () {
      //   // convert image file to base64 string
      //   console.log('base64', reader.result);
      //   if(preview){
      //     preview.src = reader.result as string;
      //   }
      //   this.productImage = convertDataURIToBinary(reader.result as string);
      //   console.log('byte array', byteArray);
        
      // }, false);

      reader.onloadend = () => {
      // convert image file to base64 string
        console.log('base64', reader.result);
        if(preview){
          preview.src = reader.result as string;
        }
        this.productImage = convertDataURIToBinary(reader.result as string);
      };
  
      reader.readAsDataURL(file);
    }
  }

  convertDataURIToBinary(dataURI: string) {
    var base64Index = dataURI.indexOf(';base64,') + ';base64,'.length;
    var base64 = dataURI.substring(base64Index);
    var raw = window.atob(base64);
    var rawLength = raw.length;
    var array = new Uint8Array(new ArrayBuffer(rawLength));
  
    for(let i = 0; i < rawLength; i++) {
      array[i] = raw.charCodeAt(i);
    }
    return array;
  }

  async addProduct(){
    var response = await axios.get(`https://localhost:7290/Category/name?name=${this.selectedCategory}`);
    var category: Category = response.data;
    console.log(category);
    const product: Product = {
      id: 0,
      categoryId: category.id,
      name: this.productName,
      price: this.productPrice
    };
    console.log(product);
    await axios.post('https://localhost:7290/Product', product);

    this.storeservice.updateProductsByCategories();
  }
}

function convertDataURIToBinary(dataURI: string) {
  var base64Index = dataURI.indexOf(';base64,') + ';base64,'.length;
  var base64 = dataURI.substring(base64Index);
  var raw = window.atob(base64);
  var rawLength = raw.length;
  var array = new Uint8Array(new ArrayBuffer(rawLength));

  for(let i = 0; i < rawLength; i++) {
    array[i] = raw.charCodeAt(i);
  }
  return array;
}

