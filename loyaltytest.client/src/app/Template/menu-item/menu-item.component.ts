import { Component, EventEmitter, Input, Output } from '@angular/core';
import { MenuItem } from '../../Models/menu-item';
import { Router } from '@angular/router';

@Component({
  selector: 'app-menu-item',
  templateUrl: './menu-item.component.html',
  styleUrl: './menu-item.component.css'
})
export class MenuItemComponent {
  @Input() item: MenuItem = new MenuItem()
  @Output() itemChange = new EventEmitter<MenuItem>()

  constructor(private router: Router) { }

  OnClickItem(item: MenuItem): void {
    this.router.navigate([item.Route])
  }
}
