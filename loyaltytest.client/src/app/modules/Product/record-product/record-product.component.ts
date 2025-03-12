import { Component, Input, OnInit, Output } from '@angular/core';
import { Product } from '../../../Models/product';
import { Observable } from 'rxjs';
import { AbstractControl, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-record-product',
  templateUrl: './record-product.component.html',
  styleUrl: './record-product.component.css'
})
export class RecordProductComponent implements OnInit {
  @Input() product: Product = new Product()
  @Output() productChange = new Observable<Product>
  @Input() submitted: boolean = false

  @Input() valid: boolean = false
  @Output() validChange = new Observable<boolean>

  productForm: FormGroup = new FormGroup({
    skuProduct: new FormControl(''),
    description: new FormControl(''),
    price: new FormControl('0'),
    stock: new FormControl('0')
  })

  constructor(private formBuilder: FormBuilder) { }

  ngOnInit(): void {
    this.productForm = this.formBuilder.group(
      {
        skuProduct: ['', Validators.required],
        description: ['', Validators.required],
        price: ['', Validators.min(1)],
        stock: ['', Validators.min(1)]
      }
    );
  }

  get f(): { [key: string]: AbstractControl } {
    return this.productForm.controls;
  }
}
