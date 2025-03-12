import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { StoreService } from '../../../services/store.service';
import { ProductService } from '../../../services/product.service';
import { Store } from '../../../Models/store';
import { Product } from '../../../Models/product';

@Component({
  selector: 'app-store-product',
  templateUrl: './store-product.component.html',
  styleUrl: './store-product.component.css'
})
export class StoreProductComponent implements OnInit {
  Stores: Store[] = []
  Products: Product[] = []

  productSelected: Product = new Product
  storeSelected: Store = new Store()

  @Output() selectStore: EventEmitter<Store> = new EventEmitter<Store>()
  @Output() selectProduct: EventEmitter<Product> = new EventEmitter < Product>()

  constructor(private productService: ProductService,
    private storeService: StoreService
  ) { }

  ngOnInit(): void {
    this.LoadProducts()
    this.LoadStores()
  }

  LoadProducts(): void {
    this.productService.getProducts()
      .subscribe({
        next: (products: Product[]) => {
          this.Products = products
        }
      })
  }

  LoadStores(): void {
    this.storeService.getStores()
      .subscribe({
        next: (stores: Store[]) => {
          this.Stores = stores
        }
      })
  }

  OnSelectStore(event: any) {
    this.selectStore.emit(this.storeSelected)
  }

  OnSelectProduct(event: any) {
    this.selectProduct.emit(this.productSelected)
  }
}
