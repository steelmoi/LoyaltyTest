import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'app-modal',
  templateUrl: './modal.component.html',
  styleUrl: './modal.component.css'
})
export class ModalComponent {
  @Input() isOpen: boolean = false;
  @Input() title: string = 'Modal Title';
  @Output() closeModal = new EventEmitter<void>();
  @Output() saveEvent = new EventEmitter<void>()

  close() {
    this.closeModal.emit();
  }

  onSave(): void {
    this.saveEvent.emit()
  }
}
