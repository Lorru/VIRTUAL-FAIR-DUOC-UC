import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { UserService } from 'app/services/user.service';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SecurityTokenGuard implements CanActivate {
  
  constructor(private _router: Router, private _userService: UserService){}

  canActivate( ): Observable<boolean> | Promise<boolean> | boolean {

    if(this._userService.getSessionToken()){
      return true;
    }else{
      this._router.navigateByUrl('/');
      return false;
    }

  }
  
}
