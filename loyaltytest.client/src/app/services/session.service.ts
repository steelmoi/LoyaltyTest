import { Injectable } from '@angular/core';
import { Users } from '../Models/users';

@Injectable({
  providedIn: 'root'
})
export class SessionService {

  constructor() { }

  public CreateSession(user: Users): void {
    this.AddItem("userLogged", JSON.stringify(user))
  }

  public DestroySession(): void {
    this.removeItem("userLogged")
    this.ResetSession()
  }

  public GetSession(): Users {
    let u = sessionStorage.getItem("userLogged")
    return JSON.parse(sessionStorage.getItem("userLogged") || '{"userID": 0}')
  }

  private AddItem(key: string, value: string): void {
    sessionStorage.setItem(key, value)
  }

  private removeItem(key: string): void {
    sessionStorage.removeItem(key);
  }

  private ResetSession(): void {
    sessionStorage.clear()
  }
}
