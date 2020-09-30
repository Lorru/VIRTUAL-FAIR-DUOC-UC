import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class PurchaseRequestService {

  private httpHeaders: HttpHeaders = new HttpHeaders().set('Content-Type', 'application/json');

  private URL_API: string = environment.URL_API + 'PurchaseRequest/';

  constructor(private httpClient: HttpClient) {

  }

  findAll(searcher?: string) : Observable<any>{

    let URL_PURCHASE_REQUEST: string = this.URL_API + 'findAll';

    if(searcher){

      URL_PURCHASE_REQUEST = URL_PURCHASE_REQUEST + '?searcher=' + searcher;

    }

    return this.httpClient.get(URL_PURCHASE_REQUEST, { headers: this.httpHeaders.append('Authorization', JSON.parse(localStorage.getItem('sessionToken')).token) });
  }

  findByIdClient(idClient: number, searcher?: string) : Observable<any>{

    let URL_PURCHASE_REQUEST: string = this.URL_API + 'findByIdClient/' + idClient;

    if(searcher){

      URL_PURCHASE_REQUEST = URL_PURCHASE_REQUEST + '?searcher=' + searcher;

    }

    return this.httpClient.get(URL_PURCHASE_REQUEST, { headers: this.httpHeaders.append('Authorization', JSON.parse(localStorage.getItem('sessionToken')).token) });
  }

  create(createBody: any) : Observable<any>{
    let URL_PURCHASE_REQUEST_CREATE: string = this.URL_API + 'create';

    return this.httpClient.post(URL_PURCHASE_REQUEST_CREATE, createBody, { headers: this.httpHeaders.append('Authorization', JSON.parse(localStorage.getItem('sessionToken')).token) });
  }
}
