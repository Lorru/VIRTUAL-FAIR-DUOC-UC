import { Injectable } from "@angular/core";
import { CanActivate, Router } from "@angular/router";
import { UserService } from "app/services/user.service";
import { Observable } from "rxjs";

@Injectable({
  providedIn: "root",
})
export class LoginGuard implements CanActivate {
  constructor(public router: Router, public _userService: UserService) {}

  canActivate(): Observable<boolean> | Promise<boolean> | boolean {
    if (this._userService.getSessionToken()) {
      this.router.navigateByUrl("/main");
      return false;
    } else {
      return true;
    }
  }
}
