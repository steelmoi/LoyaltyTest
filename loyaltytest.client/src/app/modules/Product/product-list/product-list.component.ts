import { Component, OnInit } from '@angular/core';
import { Product } from '../../../Models/product';
import { ProductService } from '../../../services/product.service';
import { ApiResultProduct } from '../../../Models/Api/api-result-product';
import { AlertService } from '../../../services/alert.service';
import { HttpResponse } from '@angular/common/http';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrl: './product-list.component.css'
})
export class ProductListComponent implements OnInit {
  products: Product[] = []
  productSelected: Product = new Product()
  file: File = new File([""], "test.txt")

  isModalOpen: boolean = false;
  isModalImageOpen: boolean = false;
  submitted: boolean = false
  isvalid: boolean = false

  constructor(private productService: ProductService,
    private alertService: AlertService
  ) {

  }

  ngOnInit(): void {
    this.LoadProducts()
  }

  LoadProducts(): void {
    this.productService.getProducts()
      .subscribe({
        next: (products: Product[]) => {
          this.products = products
        }
      })
  }

  onEdit(product: Product): void {

  }

  onDelete(product: Product): void {

  }

  onNew(): void {
    this.productSelected = new Product()
    this.openModal()
  }

  openModal() {
    this.isModalOpen = true;
  }

  openModalImage(product: Product) {
    this.isModalImageOpen = true;
    this.productSelected = product
  }

  closeModal(): void {
    this.submitted = true
    this.isModalOpen = false;
    this.isModalImageOpen = false
  }

  onSave(): void {
    this.closeModal()
    if (this.productSelected.productId == 0)
      this.saveProduct()
    else
      this.updateProduct()
  }

  saveProduct(): void {
    this.productService.addProduct(this.productSelected)
      .subscribe(
        {
          next: (result: ApiResultProduct) => {
            this.callbackSave(result)
          }
        }
      )
  }

  updateProduct(): void {
    this.productService.updateProduct(this.productSelected)
      .subscribe(
        {
          next: (result: ApiResultProduct) => {
            this.callbackSave(result)
          }
        }
      )
  }

  callbackSave(result: ApiResultProduct): void {
    if (result.status == 200) {
      this.LoadProducts()
      this.alertService.ShowSuccess("Operacion exitosa")
    } else
      this.alertService.ShowError("Error: " + result.message)
  }

  onSelectFile(file: File): void {
    this.file = file
  }

  onSaveImage(): void {
    this.closeModal()

    this.productService.AddImage2Product(this.productSelected.productId, this.file).subscribe({
      next: (event: any) => {
        if (event instanceof HttpResponse) {
          debugger
          let res = event.body;
          if (res.status == 200)
          {
            this.alertService.ShowSuccess("Imagen almacenada")
            this.LoadProducts()
          } else
            this.alertService.ShowError(res.message)
        }
      },
      error: (err: any) => {
        debugger

        console.log(err);
      },
      complete: () => {
        debugger
      },
    });
  }

  GetPathImage(image: string): string {
    return this.productService.GetImage(image)
  }
}
