import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { environment } from 'environments/environment';

@Injectable({
  providedIn: 'root'
})
export class PurchaseRequestProductService {

  public httpHeaders: HttpHeaders = new HttpHeaders().set('Content-Type', 'application/json');

  public URL_API: string = environment.URL_API + 'PurchaseRequestProduct/';

  constructor(public httpClient: HttpClient) {

  }

  findByIdPurchaseRequest(idPurchaseRequest: number) : Observable<any>{

    let URL_PURCHASE_REQUEST_PRODUCT: string = this.URL_API + 'findByIdPurchaseRequest/' + idPurchaseRequest;

    return this.httpClient.get(URL_PURCHASE_REQUEST_PRODUCT, { headers: this.httpHeaders.append('Authorization', JSON.parse(localStorage.getItem('sessionToken')).token) });
  }

  findByIdPurchaseRequestStatusInTwoNineAndExpirationDateGreatherThanNow() : Observable<any>{

    let URL_PURCHASE_REQUEST_PRODUCT: string = this.URL_API + 'findByIdPurchaseRequestStatusInTwoNineAndExpirationDateGreatherThanNow';

    return this.httpClient.get(URL_PURCHASE_REQUEST_PRODUCT, { headers: this.httpHeaders.append('Authorization', JSON.parse(localStorage.getItem('sessionToken')).token) });
  }

}
