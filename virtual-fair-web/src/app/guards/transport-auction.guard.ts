import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, Router } from '@angular/router';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TransportAuctionGuard implements CanActivate {

  constructor(public router: Router){}

  canActivate( ): Observable<boolean> | Promise<boolean> | boolean {
    
    let userConnect: any = JSON.parse(localStorage.getItem('userConnect'));

    if(userConnect && (userConnect.idProfile == 1 || userConnect.idProfile == 4)){

      return true;

    }else{

      this.router.navigateByUrl('/');
      return false;
    }

  }
  
}
