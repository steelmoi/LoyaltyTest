import { Component, OnInit } from '@angular/core';
import { Customer } from '../../../Models/customer';
import { AlertService } from '../../../services/alert.service';
import { CustomerService } from '../../../services/customer.service';
import { ApiResultCustomer } from '../../../Models/Api/api-result-customer';

@Component({
  selector: 'app-customer-list',
  templateUrl: './customer-list.component.html',
  styleUrl: './customer-list.component.css'
})
export class CustomerListComponent implements OnInit {
  Customers: Customer[] = []
  customerSelected: Customer = new Customer()

  isModalOpen: boolean = false;
  submitted: boolean = false
  isvalid: boolean = false

  constructor(private customerService: CustomerService,
    private alertService: AlertService

  ) { }

  ngOnInit(): void {
    this.LoadCustomers()
  }

  LoadCustomers(): void {
    this.customerService.getCustomers()
      .subscribe({
        next: (customers: Customer[]) => {
          this.Customers = customers
        },
        error: (error: any) => {
          debugger
        }
      })
  }

  onNew(): void {
    this.customerSelected = new Customer()
    this.openModal()
  }

  openModal() {
    this.isModalOpen = true;
  }

  closeModal() {
    this.submitted = true
    this.isModalOpen = false;
  }

  onSave(): void {
    this.closeModal()
    if (this.customerSelected.customerId == 0)
      this.saveCustomer()
    else
      this.updateCustomer()
  }

  saveCustomer(): void {
    this.customerService.addCustomer(this.customerSelected)
      .subscribe(
        {
          next: (result: ApiResultCustomer) => {
            this.callbackSave(result)
          }
        }
      )
  }

  updateCustomer(): void {
    this.customerService.updatwCustomer(this.customerSelected)
      .subscribe(
        {
          next: (result: ApiResultCustomer) => {
            this.callbackSave(result)
          }
        }
      )
  }

  callbackSave(result: ApiResultCustomer): void {
    if (result.status == 200) {
      this.LoadCustomers()
      this.alertService.ShowSuccess("Operacion exitosa")
    } else
      this.alertService.ShowError("Error: " + result.message)
  }

  onEdit(customer: Customer): void {
    this.customerSelected = customer
    this.openModal()
  }

  onDelete(customer: Customer): void {
    this.customerSelected = customer
    this.alertService.ShowConfirm("Desea eliminar el registro?", this.onConfirmDelete.bind(this))
  }

  onConfirmDelete(): void {
    this.customerSelected.status = 0
    this.updateCustomer()
  }
}
