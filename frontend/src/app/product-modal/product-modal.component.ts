import { Component, OnInit } from '@angular/core';
import { ModalController } from '@ionic/angular';
import axios from 'axios';
import { Product, StoreService } from '../store.service';

interface Category {
  id: number,
  name: string
}

@Component({
  selector: 'app-product-modal',
  templateUrl: './product-modal.component.html',
  styleUrls: ['./product-modal.component.sass']
})
export class ProductModalComponent implements OnInit{
  newCategoryName: string = '';
  categories: any[] = [];
  selectedCategory: string = "";
  productName: string = '';
  productPrice: number = 0;
  productImage: Uint8Array | null = null;

  constructor(private storeservice: StoreService, private modalCtrl: ModalController) {}

  async ngOnInit(): Promise<void> {
    await this.updateCategorySelection();
  }

  /**
   * Create a new Cetegory
   */
  async addCategory() {
    // call the backend to create the category
    await axios.post(`https://localhost:7290/Category?name=${this.newCategoryName}`);
    // update existing categories in the HMI
    await this.updateCategorySelection();

    // hide section to create a new category
    const createCategorySection = document.getElementById('createCategorySection');
    if (createCategorySection !== null) {
      createCategorySection.style.display = "none";
    }
    this.selectedCategory = this.newCategoryName;
  }

  /**
   * Call the backend to retrieve existing categories.
   * And update options of the Category select in the HTML
   */
  async updateCategorySelection() {
    const response = await axios.get('https://localhost:7290/Category');
    this.categories = response.data;
  }

  /**
   * Display the section to create a new Category if the user select the value 'Other' else hide it
   */
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

  /**
   * Prevent the user to write something else that numbers
   * @param event 
   */
  validationNumber(event: any) {
    const pattern = /[0-9.,]/;
    let inputChar = String.fromCharCode(event.charCode);

    if (!pattern.test(inputChar)) {
      // invalid character, prevent input
      event.preventDefault();
    }
  }

  /**
   * Display the preview of the image selected.
   * And convert the image into byte array
   */
  uploadImage(){
    const inputFile = document.getElementById('inputFile') as HTMLInputElement;
    const preview = document.getElementById('preview') as HTMLImageElement;

    if (inputFile && inputFile.files) {
      var file = inputFile.files[0];

      const reader = new FileReader();

      reader.onloadend = () => {
        if(preview){
          preview.src = reader.result as string;
        }
        this.productImage = this.convertDataURIToBinary(reader.result as string);
      };
  
      reader.readAsDataURL(file);
    }
  }

  /**
   * Convert the image into byte array
   * @param dataURI 
   */
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
  
  /**
   * Create a new Product
   */
  async addProduct(){
    // retrieve id of the category selected
    var response = await axios.get(`https://localhost:7290/Category/name?name=${this.selectedCategory}`);
    var category: Category = response.data;

    // construct the Product to created
    // TODO: add the image (backend can't store image in the database)
    const product: Product = {
      id: 0, // id value is override by the backend
      categoryId: category.id,
      name: this.productName,
      price: this.productPrice
    };

    // call the backend to create a new Product
    await axios.post('https://localhost:7290/Product', product);

    // update product by category used in the admin view
    this.storeservice.updateProductsByCategories();

    // close the modal
    this.modalCtrl.dismiss(null, 'confirm');
  }
}
