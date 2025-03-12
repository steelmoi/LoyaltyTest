import { Injectable } from '@angular/core';
import { ApiConfigService } from './api-config.service';
import { HttpClient, HttpRequest } from '@angular/common/http';
import { Product } from '../Models/product';
import { Observable } from 'rxjs';
import { ApiResultProduct } from '../Models/Api/api-result-product';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  constructor(private apiConfigService: ApiConfigService
    , private http: HttpClient
  ) { }

  getProduct(ProductId: number): Observable<Product> {
    return this.http.get<Product>(this.apiConfigService.buildUrl("Product/" + ProductId))
  }

  getProducts(): Observable<Product[]> {
    return this.http.get<Product[]>(this.apiConfigService.buildUrl("Product"))
  }

  addProduct(product: Product): Observable<ApiResultProduct> {
    return this.http.post<ApiResultProduct>(this.apiConfigService.buildUrl("Product/Add"), product)
  }

  updateProduct(product: Product): Observable<ApiResultProduct> {
    return this.http.put<ApiResultProduct>(this.apiConfigService.buildUrl("Product/Update"), product)
  }

  AddImage2Product(ProductId: number, file: File) {
    let urlApi = this.apiConfigService.buildUrl("Product/Image/Link/" + ProductId)
    
    const formData: FormData = new FormData();
    formData.append('file', file);
    const req = new HttpRequest('POST', urlApi, formData, {
      responseType: 'json'
    });

    return this.http.request(req);
  }

  GetImage(image: string): string {
    return this.apiConfigService.buildUrl("Upload/" + image)

  }
}
