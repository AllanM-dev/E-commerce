import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs/internal/BehaviorSubject';

@Injectable({
  providedIn: 'root'
})
export class StoreService {

  private isAdminSource = new BehaviorSubject<boolean>(false);
  isAdmin = this.isAdminSource.asObservable();
  constructor() { }
  setIsAdmin(isAdmin: boolean){
    this.isAdminSource.next(isAdmin)
  }
}
