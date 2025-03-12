import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ApiConfigService } from './api-config.service';
import { Observable } from 'rxjs';
import { Store } from '../Models/store';
import { ApiResultStore } from '../Models/Api/api-result-store';
import { ApiResultProductStore } from '../Models/Api/api-result-product-store';
import { ProductStore } from '../Models/product-store';

@Injectable({
  providedIn: 'root'
})
export class StoreService {

  constructor(
    private http: HttpClient,
    private apiConfigService: ApiConfigService
  ) { }

  getStore(StoreId: number): Observable<Store> {
    return this.http.get<Store>(this.apiConfigService.buildUrl("Store/" + StoreId))
  }

  getStores(): Observable<Store[]> {
    return this.http.get<Store[]>(this.apiConfigService.buildUrl("Store"))
  }

  addStore(store: Store): Observable<ApiResultStore> {
    return this.http.post<ApiResultStore>(this.apiConfigService.buildUrl("Store/Add"), store)
  }

  updatwStore(store: Store): Observable<ApiResultStore> {
    return this.http.put<ApiResultStore>(this.apiConfigService.buildUrl("Store/Update"), store)
  }

  addProduct2Store(productStore: ProductStore): Observable<ApiResultProductStore> {
    return this.http.post<ApiResultProductStore>(this.apiConfigService.buildUrl("Store/Product/Add"), productStore)
  }
}
