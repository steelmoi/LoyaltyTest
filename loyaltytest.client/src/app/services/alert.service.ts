import { Injectable } from '@angular/core';
import Swal from 'sweetalert2'

@Injectable({
  providedIn: 'root'
})
export class AlertService {

  constructor() { }

  ShowError(msg: string): void {
    Swal.fire({
      title: 'Error',
      text: msg,
      icon: 'error',
      confirmButtonText: 'Ok'
    })
  }
  
  ShowSuccess(msg: string): void {
    Swal.fire({
      title: 'Info',
      text: msg,
      icon: 'success',
      confirmButtonText: 'Ok'
    })
  }

  ShowConfirm(msg: string, Callback: { (): void }): void {
    Swal.fire({
      title: msg,
      showDenyButton: false,
      showCancelButton: true,
      confirmButtonText: "Eliminar"
    }).then((result) => {
      /* Read more about isConfirmed, isDenied below */
      if (result.isConfirmed) {
        Callback()
      }
    });
  }
}
