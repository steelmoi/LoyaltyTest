import { Component, Input, OnInit, Output } from '@angular/core';
import { Store } from '../../../Models/store';
import { AbstractControl, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-record-store',
  templateUrl: './record-store.component.html',
  styleUrl: './record-store.component.css'
})
export class RecordStoreComponent implements OnInit {
  @Input() store: Store = new Store()
  @Output() storeChange = new Observable<Store>
  @Input() submitted: boolean = false

  @Input() valid: boolean = false
  @Output() validChange = new Observable<boolean>

  storeForm: FormGroup = new FormGroup({
    Code: new FormControl(''),
    Name: new FormControl('')
  });

  constructor(private formBuilder: FormBuilder) {

  }

  ngOnInit(): void {
    this.storeForm = this.formBuilder.group(
      {
        Code: ['', Validators.required],
        Name: ['', Validators.required]
      }
    );
  }

  get f(): { [key: string]: AbstractControl } {
    return this.storeForm.controls;
  }

  onChange(event: Event) { 
    this.valid = !this.storeForm.invalid    
  }
}
