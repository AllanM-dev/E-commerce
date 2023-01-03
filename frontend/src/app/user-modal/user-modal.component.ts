import { Component } from '@angular/core';
import { ModalController } from '@ionic/angular';
import axios from 'axios';

@Component({
  selector: 'app-user-modal',
  templateUrl: './user-modal.component.html',
  styleUrls: ['./user-modal.component.sass']
})
export class UserModalComponent {
  name: string = '';

  constructor(private modalCtrl: ModalController) {}

  /**
   * Create a new useras Admin
   */
  async addAdmin() {
    // call the backend to create the new Admin
    await axios.post('https://localhost:7290/User',
      {
        username: this.name,
        isAdmin: true
      }
    );

    // close the modal
    this.modalCtrl.dismiss(this.name, 'confirm');
  }
}
