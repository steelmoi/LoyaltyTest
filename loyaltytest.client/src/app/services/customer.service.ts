import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ApiConfigService } from './api-config.service';
import { Customer } from '../Models/customer';
import { Observable } from 'rxjs';
import { ApiResultCustomer } from '../Models/Api/api-result-customer';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {

  constructor(private http: HttpClient,
    private apiConfigService: ApiConfigService) { }

  getCustomer(CustomerId: number): Observable<Customer> {
    return this.http.get<Customer>(this.apiConfigService.buildUrl("Customer/" + CustomerId))
  }

  getCustomers(): Observable<Customer[]> {
    return this.http.get<Customer[]>(this.apiConfigService.buildUrl("Customer"))
  }

  addCustomer(store: Customer): Observable<ApiResultCustomer> {
    return this.http.post<ApiResultCustomer>(this.apiConfigService.buildUrl("Customer/Add"), store)
  }

  updatwCustomer(store: Customer): Observable<ApiResultCustomer> {
    return this.http.put<ApiResultCustomer>(this.apiConfigService.buildUrl("Customer/Update"), store)
  }
}
