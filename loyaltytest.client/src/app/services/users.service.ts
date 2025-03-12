import { Injectable } from '@angular/core';
import { ApiConfigService } from './api-config.service';
import { HttpClient } from '@angular/common/http';
import { UserRequest } from '../Models/Api/user-request';
import { Observable } from 'rxjs';
import { ApiResultLogin } from '../Models/Api/api-result-login';

@Injectable({
  providedIn: 'root'
})
export class UsersService {

  constructor(private http: HttpClient,
    private apiConfigService: ApiConfigService) { }

  Login(user: UserRequest): Observable<ApiResultLogin> {
    return this.http.post<ApiResultLogin>(this.apiConfigService.buildUrl("User/Login"), user)
  }
}
