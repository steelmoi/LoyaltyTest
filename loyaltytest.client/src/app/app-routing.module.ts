import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './modules/Login/login/LoginComponent';
import { LayoutComponent } from './Template/layout/layout.component';
import { authGuard } from './guards/auth.guard';
import { StoreListComponent } from './modules/Store/store-list/store-list.component';
import { CustomerListComponent } from './modules/Customer/customer-list/customer-list.component';
import { ProductListComponent } from './modules/Product/product-list/product-list.component';
import { ShopListComponent } from './modules/Shop/shop-list/shop-list.component';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'login',
    pathMatch: 'full'
  },
  {
    path: 'login',
    component: LoginComponent
  },
  {
    path: '',
    component: LayoutComponent,
    canActivate: [authGuard],
    children: [
      { path: 'store-list', component: StoreListComponent },
      { path: 'customer-list', component: CustomerListComponent },
      { path: 'product-list', component: ProductListComponent },
      { path: 'shop-list', component: ShopListComponent }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
