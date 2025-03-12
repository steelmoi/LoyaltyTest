import { Component, Input, OnInit, Output } from '@angular/core';
import { Customer } from '../../../Models/customer';
import { Observable } from 'rxjs';
import { AbstractControl, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-record-customer',
  templateUrl: './record-customer.component.html',
  styleUrl: './record-customer.component.css'
})
export class RecordCustomerComponent implements OnInit {
  @Input() customer: Customer = new Customer()
  @Output() customerChange = new Observable<Customer>
  @Input() submitted: boolean = false

  @Input() valid: boolean = false
  @Output() validChange = new Observable<boolean>

  customerForm: FormGroup = new FormGroup({
    customerName: new FormControl(''),
    customerFirstName: new FormControl(''),
    customerLastName: new FormControl('')
  });

  constructor(private formBuilder: FormBuilder) {

  }

  ngOnInit(): void {
    this.customerForm = this.formBuilder.group(
      {
        customerName: ['', Validators.required],
        customerFirstName: ['', Validators.required],
        customerLastName: ['', Validators.required]
      }
    );
  }

  get f(): { [key: string]: AbstractControl } {
    return this.customerForm.controls;
  }
}
