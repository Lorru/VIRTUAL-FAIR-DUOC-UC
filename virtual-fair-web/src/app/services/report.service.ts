import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { environment } from 'environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ReportService {

  private httpHeaders: HttpHeaders = new HttpHeaders().set('Content-Type', 'application/json');

  private URL_API: string = environment.URL_API + 'Report/';

  constructor(private httpClient: HttpClient) {

  }

  sendReportToParticipantsByIdPurchaseRequest(idPurchaseRequest: number) : Observable<any>{

    let URL_PRODUCT: string = `${this.URL_API}sendReportToParticipantsByIdPurchaseRequest/${idPurchaseRequest}`;

    return this.httpClient.get(URL_PRODUCT, { headers: this.httpHeaders.append('Authorization', JSON.parse(localStorage.getItem('sessionToken')).token) });
  }
}
