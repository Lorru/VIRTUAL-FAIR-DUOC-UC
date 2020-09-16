import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SecurityTokenGuard implements CanActivate {
  
  constructor(private router: Router){}

  canActivate( ): Observable<boolean> | Promise<boolean> | boolean {
    
    let sessionToken: any = JSON.parse(localStorage.getItem('sessionToken'));

    if(sessionToken){

      return true;

    }else{

      this.router.navigateByUrl('/');
      return false;
    }

  }
  
}
