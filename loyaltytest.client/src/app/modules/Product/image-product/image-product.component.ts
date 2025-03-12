import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-image-product',
  templateUrl: './image-product.component.html',
  styleUrl: './image-product.component.css'
})
export class ImageProductComponent {
  file: File = new File([""], "test.txt")
  @Output() fileChange: EventEmitter<File> = new  EventEmitter<File>()

  selectFile(event: any): void {
    this.file = event.target.files.item(0)
    this.fileChange.emit(this.file)
  }
}
