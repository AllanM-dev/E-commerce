import { Component } from '@angular/core';
import { ModalController } from '@ionic/angular';
import { ProductModalComponent } from '../product-modal/product-modal.component';
import { UserModalComponent } from '../user-modal/user-modal.component';

@Component({
  selector: 'admin-navbar',
  templateUrl: './admin-navbar.component.html',
  styleUrls: ['./admin-navbar.component.sass']
})
export class AdminNavbarComponent {
  constructor(private modalCtrl: ModalController) {}

  /**
   * Open the Product Modal
   */
  async openProductModal(){
    const modal = await this.modalCtrl.create({
      component: ProductModalComponent,
    });
    modal.present();
  }

  /**
   * Open the User Modal
   */
  async openUserModal(){
    const modal = await this.modalCtrl.create({
      component: UserModalComponent,
    });
    modal.present();
  }
}

