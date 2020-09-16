import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PurchaseRequestGuard implements CanActivate {

  constructor(private router: Router){}

  canActivate( ): Observable<boolean> | Promise<boolean> | boolean {
    
    let userConnect: any = JSON.parse(localStorage.getItem('userConnect'));

    if(userConnect && (userConnect.idProfile == 5 || userConnect.idProfile == 6)){

      return true;

    }else{

      this.router.navigateByUrl('/');
      return false;
    }

  }
  
}
