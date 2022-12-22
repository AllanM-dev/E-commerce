import { Component, OnInit } from '@angular/core';
import { StoreService } from './store.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.sass']
})
export class AppComponent implements OnInit {
  isAdmin: boolean = false;
  createUserModal: boolean = false;
  constructor(private storeservice: StoreService) { }

  ngOnInit() {
    this.storeservice.isAdmin.subscribe(data=>{
      this.isAdmin = data;
    });
  }
}
