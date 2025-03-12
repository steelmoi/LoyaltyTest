import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Menu } from '../Models/menu';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class MenuService {

  url: string = '/assets/menu.json';

  constructor(private httpClient: HttpClient) { }

  GetMenu(): Observable<Menu[]> {

    return this.httpClient.get<Menu[]>(this.url);
  }
}
