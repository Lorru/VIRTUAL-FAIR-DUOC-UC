import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { environment } from 'environments/environment';

@Injectable({
  providedIn: 'root'
})
export class TransportAuctionCarrierService {

  public httpHeaders: HttpHeaders = new HttpHeaders().set('Content-Type', 'application/json');

  public URL_API: string = environment.URL_API + 'TransportAuctionCarrier/';

  constructor(public httpClient: HttpClient) {

  }

  findById(id: number) : Observable<any>{

    let URL: string = this.URL_API + 'findById/' + id;

    return this.httpClient.get(URL, { headers: this.httpHeaders.append('Authorization', JSON.parse(localStorage.getItem('sessionToken')).token) });
  }

  findByIdTransportAuction(idTransportAuction: number ) : Observable<any>{
    let URL: string = this.URL_API + 'findByIdTransportAuction/' + idTransportAuction;

    return this.httpClient.get(URL, { headers: this.httpHeaders.append('Authorization', JSON.parse(localStorage.getItem('sessionToken')).token) });
  }

  getParticipantByIdPurchaseRequest(idPurchaseRequest: number) : Observable<any>{
    let URL: string = this.URL_API + 'getParticipantByIdPurchaseRequest/' + idPurchaseRequest;

    return this.httpClient.get(URL, { headers: this.httpHeaders.append('Authorization', JSON.parse(localStorage.getItem('sessionToken')).token) });
  }


  findAll(searcher?: string) : Observable<any>{

    let URL_TRANSPORT_AUCTION: string = this.URL_API + 'findAll';

    if(searcher){

      URL_TRANSPORT_AUCTION = URL_TRANSPORT_AUCTION + '?searcher=' + searcher;

    }

    return this.httpClient.get(URL_TRANSPORT_AUCTION, { headers: this.httpHeaders.append('Authorization', JSON.parse(localStorage.getItem('sessionToken')).token) });
  }

  
  findByIsPublicEqualToOne() : Observable<any>{

    let URL: string = this.URL_API + 'findByIsPublicEqualToOne';

    return this.httpClient.get(URL, { headers: this.httpHeaders.append('Authorization', JSON.parse(localStorage.getItem('sessionToken')).token) });
  }

  findByIdCarrier(idCarrier: number) : Observable<any>{

    let URL_TRANSPORT_AUCTION: string = this.URL_API + 'findByIdCarrier/' + idCarrier;

    return this.httpClient.get(URL_TRANSPORT_AUCTION, { headers: this.httpHeaders.append('Authorization', JSON.parse(localStorage.getItem('sessionToken')).token) });
  }

  create(auctionData: any): Observable<any> {
    let URL: string = this.URL_API + "create";

    return this.httpClient.post(URL, JSON.stringify(auctionData), {
      headers: this.httpHeaders.append(
        "Authorization",
        JSON.parse(localStorage.getItem("sessionToken")).token
      ),
    });
  }

  findByIdPurchaseRequest(idPurchaseRequest: number) : Observable<any>{

    let URL_TRANSPORT_AUCTION: string = this.URL_API + 'findByIdPurchaseRequest/' + idPurchaseRequest;

    return this.httpClient.get(URL_TRANSPORT_AUCTION, { headers: this.httpHeaders.append('Authorization', JSON.parse(localStorage.getItem('sessionToken')).token) });
  }
}
