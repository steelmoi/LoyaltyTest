import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment'


@Injectable({
  providedIn: 'root'
})
export class ApiConfigService {
  private apiUrl = environment.apiUrl
  constructor() { }

  getApiUrl(): string {
    return this.apiUrl
  }

  buildUrl(path: string): string {
    return `${this.apiUrl}${path}`
  }
}
