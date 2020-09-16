import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  private httpHeaders: HttpHeaders = new HttpHeaders().set('Content-Type', 'application/json');

  private URL_API: string = environment.URL_API + 'User/';

  constructor(private httpClient: HttpClient) {

  }

  findAll(searcher?: string) : Observable<any>{

    let URL_USER: string = this.URL_API + 'findAll';

    if(searcher){

      URL_USER = URL_USER + '?searcher=' + searcher;

    }

    return this.httpClient.get(URL_USER, { headers: this.httpHeaders.append('Authorization', JSON.parse(localStorage.getItem('sessionToken')).token) });
  }

  findByEmailAndPassword(user: any) : Observable<any>{

    let URL_USER: string = this.URL_API + 'findByEmailAndPassword';

    return this.httpClient.post(URL_USER, JSON.stringify(user), { headers: this.httpHeaders });
  }
}
