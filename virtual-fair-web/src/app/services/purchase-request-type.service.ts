import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { environment } from 'environments/environment';

@Injectable({
  providedIn: 'root'
})
export class PurchaseRequestTypeService {

  private httpHeaders: HttpHeaders = new HttpHeaders().set('Content-Type', 'application/json');

  private URL_API: string = environment.URL_API + 'PurchaseRequestType/';

  constructor(private httpClient: HttpClient) {

  }

  findAll() : Observable<any>{

    let URL_PURCHASE_REQUEST_TYPE: string = this.URL_API + 'findAll';

    return this.httpClient.get(URL_PURCHASE_REQUEST_TYPE, { headers: this.httpHeaders.append('Authorization', JSON.parse(localStorage.getItem('sessionToken')).token) });
  }
}
