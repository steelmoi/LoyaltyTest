import { Component, OnInit } from '@angular/core';
import { StoreService } from '../../../services/store.service';
import { Store } from '../../../Models/store';
import { ApiResultStore } from '../../../Models/Api/api-result-store';
import { AlertService } from '../../../services/alert.service';
import Swal from 'sweetalert2'
import { Product } from '../../../Models/product';
import { ApiResultProductStore } from '../../../Models/Api/api-result-product-store';
import { ProductStore } from '../../../Models/product-store';

@Component({
  selector: 'app-store-list',
  templateUrl: './store-list.component.html',
  styleUrl: './store-list.component.css'
})
export class StoreListComponent implements OnInit {
  Stores: Store[] = []
  storeSelected: Store = new Store()
  productSelected: Product = new Product()

  title = '';
  isModalOpen: boolean = false;
  isModalRelOpen: boolean = false;
  submitted: boolean = false
  isvalid: boolean = false

  constructor(private storeService: StoreService,
    private alertService: AlertService

  ) { } 

  openModal() {
    this.isModalOpen = true;
  }

  closeModal() {
    this.submitted = true
    this.isModalOpen = false;
    this.isModalRelOpen = false
  }

  ngOnInit(): void {
    this.LoadStores()
  }

  LoadStores(): void {
    this.storeService.getStores()
      .subscribe({
        next: (Stores: Store[]) => {
          this.Stores = Stores
        }
      })
  }

  onSave(): void {
    this.closeModal()
    if (this.storeSelected.storeId == 0)
      this.saveStore()
    else
      this.updateStore()
  }

  saveStore(): void {
    this.storeService.addStore(this.storeSelected)
      .subscribe(
        {
          next: (result: ApiResultStore) => {
            this.callbackSave(result)
          }
        }
      )
  }

  updateStore(): void {
    this.storeService.updatwStore(this.storeSelected)
      .subscribe(
        {
          next: (result: ApiResultStore) => {
            this.callbackSave(result)
          }
        }
      )
  }

  callbackSave(result: ApiResultStore): void {
    if (result.status == 200)
    {
      this.LoadStores()
      this.alertService.ShowSuccess("Operacion exitosa")
    } else
      this.alertService.ShowError("Error: " + result.message)
  }

  callbackSaveProductStore(result: ApiResultProductStore): void {
    if (result.status == 200) {
      this.closeModal()
      this.alertService.ShowSuccess("Operacion exitosa")
    } else
      this.alertService.ShowError("Error: " + result.message)
  }

  onEdit(store: Store): void {
    this.storeSelected = store
    this.openModal()
  }

  onDelete(store: Store): void {
    this.storeSelected = store
    this.alertService.ShowConfirm("Desea eliminar el registro?", this.onConfirmDelete.bind(this))
  }

  onConfirmDelete(): void {
    this.storeSelected.status = 0
    this.updateStore()
  }

  onAddProduct(store: Store): void {
    this.isModalRelOpen = true
  }

  onViewProducts(store: Store): void {
    debugger
  }

  onSaveRelation() {
    if (this.storeSelected.storeId == 0 ||
      this.productSelected.productId == 0
    )
      this.alertService.ShowError("Seleccione una Tienda y un Producto")
    else {
      this.saveProductStore()
    }
  }

  saveProductStore() {
    let data = new ProductStore()
    data.ProductsProductId = this.productSelected.productId
    data.StoresStoreId = this.storeSelected.storeId

    this.storeService.addProduct2Store(data)
      .subscribe({
        next: (result: ApiResultProductStore) => {
          this.callbackSaveProductStore(result)
        }
      })
  }

  onSelectStore(store: Store): void {
    this.storeSelected = store
  }

  onSelectProduct(product: Product): void {
    this.productSelected = product
  }
}
