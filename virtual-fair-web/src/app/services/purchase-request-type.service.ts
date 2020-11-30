import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { environment } from 'environments/environment';

@Injectable({
  providedIn: 'root'
})
export class PurchaseRequestTypeService {

  public httpHeaders: HttpHeaders = new HttpHeaders().set('Content-Type', 'application/json');

  public URL_API: string = environment.URL_API + 'PurchaseRequestType/';

  constructor(public httpClient: HttpClient) {

  }

  findAll() : Observable<any>{

    let URL_PURCHASE_REQUEST_TYPE: string = this.URL_API + 'findAll';

    return this.httpClient.get(URL_PURCHASE_REQUEST_TYPE, { headers: this.httpHeaders.append('Authorization', JSON.parse(localStorage.getItem('sessionToken')).token) });
  }
}
