import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { environment } from 'environments/environment';

@Injectable({
  providedIn: 'root'
})
export class PurchaseRequestRemarkService {

  public httpHeaders: HttpHeaders = new HttpHeaders().set('Content-Type', 'application/json');

  public URL_API: string = environment.URL_API + 'PurchaseRequestRemark/';

  constructor(public httpClient: HttpClient) {

  }

  create(body: any) : Observable<any>{

    let URL_PURCHASE_REQUEST_TYPE: string = this.URL_API + 'create';

    return this.httpClient.post(URL_PURCHASE_REQUEST_TYPE, body, { headers: this.httpHeaders.append('Authorization', JSON.parse(localStorage.getItem('sessionToken')).token) });
  }
}
