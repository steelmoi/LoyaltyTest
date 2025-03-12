import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Menu } from '../../Models/menu';

@Component({
  selector: 'app-menu-fixed',
  templateUrl: './menu-fixed.component.html',
  styleUrl: './menu-fixed.component.css'
})
export class MenuFixedComponent {
  @Input() submenu: Menu = new Menu()
  @Output() submenuChange = new EventEmitter<Menu>()
}
