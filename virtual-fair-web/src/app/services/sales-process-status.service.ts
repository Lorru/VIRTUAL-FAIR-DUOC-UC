import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class SalesProcessStatusService {

  private httpHeaders: HttpHeaders = new HttpHeaders().set('Content-Type', 'application/json');

  private URL_API: string = environment.URL_API + 'SalesProcessStatus/';

  constructor(private httpClient: HttpClient) {

  }

  findAll() : Observable<any>{

    let URL_SALES_PROCESS_STATUS: string = this.URL_API + 'findAll';

    return this.httpClient.get(URL_SALES_PROCESS_STATUS, { headers: this.httpHeaders.append('Authorization', JSON.parse(localStorage.getItem('sessionToken')).token) });
  }
}
