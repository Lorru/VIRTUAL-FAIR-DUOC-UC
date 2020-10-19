import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class PurchaseRequestProductService {

  private httpHeaders: HttpHeaders = new HttpHeaders().set('Content-Type', 'application/json');

  private URL_API: string = environment.URL_API + 'PurchaseRequestProduct/';

  constructor(private httpClient: HttpClient) {

  }

  findByIdPurchaseRequest(idPurchaseRequest: number) : Observable<any>{

    let URL_PURCHASE_REQUEST_PRODUCT: string = this.URL_API + 'findByIdPurchaseRequest/' + idPurchaseRequest;

    return this.httpClient.get(URL_PURCHASE_REQUEST_PRODUCT, { headers: this.httpHeaders.append('Authorization', JSON.parse(localStorage.getItem('sessionToken')).token) });
  }
}
