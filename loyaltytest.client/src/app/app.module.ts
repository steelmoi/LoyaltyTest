import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ContentWrapperComponent } from './Template/content-wrapper/content-wrapper.component';
import { MainFooterComponent } from './Template/main-footer/main-footer.component';
import { MainHeaderComponent } from './Template/main-header/main-header.component';
import { LayoutComponent } from './Template/layout/layout.component';
import { MainSidebarComponent } from './Template/main-sidebar/main-sidebar.component';
import { MenuCollapsibleComponent } from './Template/menu-collapsible/menu-collapsible.component';
import { MenuFixedComponent } from './Template/menu-fixed/menu-fixed.component';
import { MenuGroupComponent } from './Template/menu-group/menu-group.component';
import { MenuItemComponent } from './Template/menu-item/menu-item.component';
import { RecordStoreComponent } from './modules/Store/record-store/record-store.component';
import { LoginComponent } from './modules/Login/login/LoginComponent';
import { StoreListComponent } from './modules/Store/store-list/store-list.component';
import { ModalComponent } from './modules/modal/modal.component';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SweetAlert2Module } from '@sweetalert2/ngx-sweetalert2';
import { RecordCustomerComponent } from './modules/Customer/record-customer/record-customer.component';
import { CustomerListComponent } from './modules/Customer/customer-list/customer-list.component';
import { ProductListComponent } from './modules/Product/product-list/product-list.component';
import { RecordProductComponent } from './modules/Product/record-product/record-product.component';
import { ImageProductComponent } from './modules/Product/image-product/image-product.component';
import { StoreProductComponent } from './modules/Store/store-product/store-product.component';
import { ShopListComponent } from './modules/Shop/shop-list/shop-list.component';

@NgModule({
  declarations: [
    AppComponent,
    ContentWrapperComponent,
    MainFooterComponent,
    MainHeaderComponent,
    LayoutComponent,
    MainSidebarComponent,
    MenuCollapsibleComponent,
    MenuFixedComponent,
    MenuGroupComponent,
    MenuItemComponent,
    RecordStoreComponent,
    LoginComponent,
    StoreListComponent,
    ModalComponent,
    RecordCustomerComponent,
    CustomerListComponent,
    ProductListComponent,
    RecordProductComponent,
    ImageProductComponent,
    StoreProductComponent,
    ShopListComponent
  ],
  imports: [
    BrowserModule, HttpClientModule,
    AppRoutingModule, CommonModule,
    FormsModule, ReactiveFormsModule,
    SweetAlert2Module
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
