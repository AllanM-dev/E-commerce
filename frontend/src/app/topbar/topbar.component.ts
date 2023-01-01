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

  async login() {
    if (this.username !== "") {
      const { data, status } = await axios.get<any>(
        `https://localhost:7290/user/isAdmin?username=${this.username}`
      );
      this.storeservice.setUsername(this.username);
      if(data === true){
        this.router.navigate(['/admin-view-component']);
      } else {
        this.router.navigate(['/']);
      }
    }
  }
}
