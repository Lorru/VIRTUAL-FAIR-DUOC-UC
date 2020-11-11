import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { environment } from 'environments/environment';

@Injectable({
  providedIn: 'root'
})
export class SalesProcessService {

  private httpHeaders: HttpHeaders = new HttpHeaders().set('Content-Type', 'application/json');

  private URL_API: string = environment.URL_API + 'SalesProcess/';

  constructor(private httpClient: HttpClient) {

  }

  findByIdSalesProcessStatusAndIdPurchaseRequestType(idSalesProcessStatus: number, idPurchaseRequestType: number) : Observable<any>{

    let URL_SALES_PROCESS: string = this.URL_API + 'findByIdSalesProcessStatusAndIdPurchaseRequestType/' + idSalesProcessStatus + '/' + idPurchaseRequestType;

    return this.httpClient.get(URL_SALES_PROCESS, { headers: this.httpHeaders.append('Authorization', JSON.parse(localStorage.getItem('sessionToken')).token) });
  }

  findByIdProducerAndIdSalesProcessStatusAndIdPurchaseRequestType(idProducer: number, idSalesProcessStatus: number, idPurchaseRequestType: number) : Observable<any>{

    let URL_SALES_PROCESS: string = this.URL_API + 'findByIdProducerAndIdSalesProcessStatusAndIdPurchaseRequestType/' + idProducer + '/' + idSalesProcessStatus + '/' + idPurchaseRequestType;

    return this.httpClient.get(URL_SALES_PROCESS, { headers: this.httpHeaders.append('Authorization', JSON.parse(localStorage.getItem('sessionToken')).token) });
  }
}
