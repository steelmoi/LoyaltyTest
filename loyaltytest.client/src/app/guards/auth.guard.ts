import { ActivatedRouteSnapshot, CanActivateFn, Router, RouterStateSnapshot } from '@angular/router';
import { SessionService } from '../services/session.service';
import { inject } from '@angular/core';

let routes: string[] = [
  'store-list',
  'customer-list',
  'product-list',
  'shop-list'
]

export const authGuard: CanActivateFn = (
  route: ActivatedRouteSnapshot,
  state: RouterStateSnapshot
) => {  
  const session: SessionService = inject(SessionService)
  const router: Router = inject(Router);
  const userLogged = session.GetSession()
  const protectedRoutes: string[] = routes
  //userLogged.id = 1
  return protectedRoutes.includes(state.url) && userLogged.id == 0
    ? router.navigate(['/'])
    : true;
};
