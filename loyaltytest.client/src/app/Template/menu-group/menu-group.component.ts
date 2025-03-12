import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Menu } from '../../Models/menu';

@Component({
  selector: 'app-menu-group',
  templateUrl: './menu-group.component.html',
  styleUrl: './menu-group.component.css'
})
export class MenuGroupComponent {
  @Input() menu: Menu = new Menu()
  @Output() menuChange = new EventEmitter<Menu>()
}
