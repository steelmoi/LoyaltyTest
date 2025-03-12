import { MenuItem } from "./menu-item"
import { MenuOption } from "./menu-option"

export class Menu extends MenuOption {
  IsCollapsible: boolean = false
  Items: MenuItem[] = []
}
