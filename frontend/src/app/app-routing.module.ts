import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminViewComponent } from './admin-view/admin-view.component';
import { AppComponent } from './app.component';
import { UserViewComponent } from './user-view/user-view.component';

const routes: Routes = [
  {path: '', component: UserViewComponent},
  {path: 'admin-view-component', component: AdminViewComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
