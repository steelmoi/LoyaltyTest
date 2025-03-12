import { Component, OnInit } from '@angular/core';
import { Product } from '../../../Models/product';
import { ProductService } from '../../../services/product.service';

@Component({
  selector: 'app-shop-list',
  templateUrl: './shop-list.component.html',
  styleUrl: './shop-list.component.css'
})
export class ShopListComponent implements OnInit {

  constructor(private productService: ProductService) { }

  ngOnInit(): void {
    this.LoadProducts()    
  }

  LoadProducts(): void {
    this.productService.getProducts()
      .subscribe({
        next: (products: Product[]) => {
          this.Products = products
        }
      })
  }

  GetPathImage(image: string): string {
    return this.productService.GetImage(image)
  }

  Products: Product[] = []
}
