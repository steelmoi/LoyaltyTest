import { Component, OnInit } from '@angular/core';
import { Menu } from '../../Models/menu';
import { Users } from '../../Models/users';
import { MenuService } from '../../services/menu.service';
import { SessionService } from '../../services/session.service';

@Component({
  selector: 'app-main-sidebar',
  templateUrl: './main-sidebar.component.html',
  styleUrl: './main-sidebar.component.css'
})
export class MainSidebarComponent implements OnInit {
  public MainMenu: Menu[] = []
  public userLogged: Users = new Users()

  constructor(private menuService: MenuService,
    private sessionServices: SessionService) {

  }

  ngOnInit(): void {
    this.userLogged = this.sessionServices.GetSession()
    this.menuService.GetMenu().subscribe({
      next: (data: Menu[]) => {
        this.MainMenu = data
        console.log(this.MainMenu)
      },
      error: (error: Error) => {
        console.error(error);
      }
    });
  }
}
