import { Component } from '@angular/core';
import axios from 'axios';
import { StoreService } from '../store.service';

@Component({
  selector: 'topbar',
  templateUrl: './topbar.component.html',
  styleUrls: ['./topbar.component.sass']
})
export class TopbarComponent {
  username: string = "";
  isAdmin: boolean = false;
  constructor(private storeservice: StoreService) {}

  async login() {
    const { data, status } = await axios.get<any>(
      `https://localhost:7290/Permissions?username=${this.username}`
    );
    this.storeservice.setIsAdmin(data);
  }
}
