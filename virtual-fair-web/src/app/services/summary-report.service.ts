import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { environment } from 'environments/environment';

@Injectable({
  providedIn: 'root'
})
export class SummaryReportService {

  private httpHeaders: HttpHeaders = new HttpHeaders().set('Content-Type', 'application/json');

  private URL_API: string = environment.URL_API + 'SummaryReport/';

  constructor(private httpClient: HttpClient) {

  }

  findByIdPurchaseRequestStatusInTwoNineAndUpdateDate(updateDateOf, updateDateTo) : Observable<any>{

    let URL_PRODUCT: string = `${this.URL_API}findByIdPurchaseRequestStatusInTwoNineAndUpdateDate/${updateDateOf}/${updateDateTo}`;

    return this.httpClient.get(URL_PRODUCT, { headers: this.httpHeaders.append('Authorization', JSON.parse(localStorage.getItem('sessionToken')).token) });
  }

  findByIdPurchaseRequestStatusInTwoNineAndUpdateDatePdf(updateDateOf, updateDateTo) : Observable<any>{

    let URL_PRODUCT: string = `${this.URL_API}findByIdPurchaseRequestStatusInTwoNineAndUpdateDatePdf/${updateDateOf}/${updateDateTo}`;

    return this.httpClient.get(URL_PRODUCT, { headers: this.httpHeaders.append('Authorization', JSON.parse(localStorage.getItem('sessionToken')).token) });
  }
}
