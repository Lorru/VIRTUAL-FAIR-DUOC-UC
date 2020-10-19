import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  private httpHeaders: HttpHeaders = new HttpHeaders().set('Content-Type', 'application/json');

  private URL_API: string = environment.URL_API + 'Product/';

  constructor(private httpClient: HttpClient) {

  }

  findAll(searcher?: string) : Observable<any>{

    let URL_PRODUCT: string = this.URL_API + 'findAll';

    if(searcher){

      URL_PRODUCT = URL_PRODUCT + '?searcher=' + searcher;

    }

    return this.httpClient.get(URL_PRODUCT, { headers: this.httpHeaders.append('Authorization', JSON.parse(localStorage.getItem('sessionToken')).token) });
  }
}
