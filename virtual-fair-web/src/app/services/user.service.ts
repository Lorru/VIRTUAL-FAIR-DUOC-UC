import { Injectable } from "@angular/core";
import { HttpHeaders, HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { environment } from "environments/environment";
import { Router } from "@angular/router";

@Injectable({
  providedIn: "root",
})
export class UserService {
  private httpHeaders: HttpHeaders = new HttpHeaders().set(
    "Content-Type",
    "application/json"
  );

  currentUser: any;

  private URL_API: string = environment.URL_API + "User/";

  constructor(private httpClient: HttpClient, private _router: Router) {}

  findAll(searcher?: string): Observable<any> {
    let URL_USER: string = this.URL_API + "findAll";

    if (searcher) {
      URL_USER = URL_USER + "?searcher=" + searcher;
    }

    return this.httpClient.get(URL_USER, {
      headers: this.httpHeaders.append(
        "Authorization",
        JSON.parse(localStorage.getItem("sessionToken")).token
      ),
    });
  }

  findByEmailAndPassword(user: any): Observable<any> {
    let URL_USER: string = this.URL_API + "findByEmailAndPassword";

    return this.httpClient.post(URL_USER, JSON.stringify(user), {
      headers: this.httpHeaders,
    });
  }

  create(newUserData: any): Observable<any> {
    let URL_USER_CREATE: string = this.URL_API + "create";

    return this.httpClient.post(URL_USER_CREATE, JSON.stringify(newUserData), {
      headers: this.httpHeaders.append(
        "Authorization",
        JSON.parse(localStorage.getItem("sessionToken")).token
      ),
    });
  }

  update(userData: any): Observable<any> {
    let URL_USER_UPDATE: string = this.URL_API + "updateById/" + userData.id;

    return this.httpClient.put(URL_USER_UPDATE, JSON.stringify(userData), {
      headers: this.httpHeaders.append(
        "Authorization",
        JSON.parse(localStorage.getItem("sessionToken")).token
      ),
    });
  }

  getUser(): any {
    if (!this.currentUser) {
      this.currentUser = JSON.parse(localStorage.getItem("userConnect"));
    }
    return this.currentUser;
  }

  getSessionToken(): any {
    const sessionToken: any = JSON.parse(localStorage.getItem("sessionToken"));
    if (sessionToken && !this.isTokenExpired(sessionToken)) {
      return sessionToken;
    } else if (sessionToken) {
      this.logout();
      return false;
    } else {
      return false;
    }
  }

  isTokenExpired(sessionToken: any): boolean {
    if (sessionToken) {
      const sessionToken: any = JSON.parse(
        localStorage.getItem("sessionToken")
      );
      const isTokenExpired: boolean =
        sessionToken.loginExpiration <= Date.now();
      return isTokenExpired;
    } else {
      return false;
    }
  }

  logout() {
    this.currentUser = undefined;
    localStorage.clear();
    this._router.navigateByUrl("/");
  }
}
