import { Component } from '@angular/core';
import axios from 'axios';
import { StoreService } from '../store.service';
import {Router} from "@angular/router"


@Component({
  selector: 'topbar',
  templateUrl: './topbar.component.html',
  styleUrls: ['./topbar.component.sass']
})
export class TopbarComponent {
  username: string = "";

  constructor(private storeservice: StoreService, private router: Router) {}

  /**
   * Navigate to the admin page if the user is an admin
   * else to the user page
   */
  async login() {
    if (this.username !== "") {
      // call the backend to know if the user is an admin
      const { data, status } = await axios.get<any>(
        `https://localhost:7290/user/isAdmin?username=${this.username}`
      );

      // store the username
      this.storeservice.setUsername(this.username);
      if(data === true){
        this.router.navigate(['/admin-view-component']);
      } else {
        this.router.navigate(['/']);
      }
    }
  }
}
