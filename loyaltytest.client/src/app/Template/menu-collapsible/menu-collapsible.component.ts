import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Menu } from '../../Models/menu';

@Component({
  selector: 'app-menu-collapsible',
  templateUrl: './menu-collapsible.component.html',
  styleUrl: './menu-collapsible.component.css'
})
export class MenuCollapsibleComponent {
  @Input() submenu: Menu = new Menu()
  @Output() submenuChange = new EventEmitter<Menu>()
}
