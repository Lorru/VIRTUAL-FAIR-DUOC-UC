import { Injectable } from "@angular/core";
import { HttpHeaders, HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";

import { environment } from "environments/environment";

@Injectable({
  providedIn: "root",
})
export class PurchaseRequestService {
  private httpHeaders: HttpHeaders = new HttpHeaders().set(
    "Content-Type",
    "application/json"
  );

  private URL_API: string = environment.URL_API + "PurchaseRequest/";

  constructor(private httpClient: HttpClient) {}

  findAll(searcher?: string): Observable<any> {
    let URL_PURCHASE_REQUEST: string = this.URL_API + "findAll";

    if (searcher) {
      URL_PURCHASE_REQUEST = URL_PURCHASE_REQUEST + "?searcher=" + searcher;
    }

    return this.httpClient.get(URL_PURCHASE_REQUEST, {
      headers: this.httpHeaders.append(
        "Authorization",
        JSON.parse(localStorage.getItem("sessionToken")).token
      ),
    });
  }

  findByIdClient(idClient: number, searcher?: string): Observable<any> {
    let URL_PURCHASE_REQUEST: string =
      this.URL_API + "findByIdClient/" + idClient;

    if (searcher) {
      URL_PURCHASE_REQUEST = URL_PURCHASE_REQUEST + "?searcher=" + searcher;
    }

    return this.httpClient.get(URL_PURCHASE_REQUEST, {
      headers: this.httpHeaders.append(
        "Authorization",
        JSON.parse(localStorage.getItem("sessionToken")).token
      ),
    });
  }

  create(createBody: any): Observable<any> {
    let URL_PURCHASE_REQUEST_CREATE: string = this.URL_API + "create";

    return this.httpClient.post(URL_PURCHASE_REQUEST_CREATE, createBody, {
      headers: this.httpHeaders.append(
        "Authorization",
        JSON.parse(localStorage.getItem("sessionToken")).token
      ),
    });
  }

  updateStatusById(id: number, body: any) {
    return this.httpClient.put(this.URL_API + `updateStatusById/${id}`, body, {
      headers: this.httpHeaders.append(
        "Authorization",
        JSON.parse(localStorage.getItem("sessionToken")).token
      ),
    });
  }

  findByIsPublicEqualToOne(): Observable<any> {
    const URL: string = this.URL_API + "findByIsPublicEqualToOne";

    return this.httpClient.get(URL, {
      headers: this.httpHeaders.append(
        "Authorization",
        JSON.parse(localStorage.getItem("sessionToken")).token
      ),
    });
  }

  findByIdPurchaseRequestTypeAndIsPublicEqualToOne(
    idPurchaseRequestType: number
  ): Observable<any> {
    const URL: string =
      this.URL_API +
      "findByIdPurchaseRequestTypeAndIsPublicEqualToOne/" +
      idPurchaseRequestType;

    return this.httpClient.get(URL, {
      headers: this.httpHeaders.append(
        "Authorization",
        JSON.parse(localStorage.getItem("sessionToken")).token
      ),
    });
  }

  findByIdPurchaseRequestStatusAndIdPurchaseRequestType(
    idPurchaseRequestType: number
  ): Observable<any> {
    const URL: string =
      this.URL_API +
      "findByIdPurchaseRequestStatusAndIdPurchaseRequestType/" +
      idPurchaseRequestType;

    return this.httpClient.get(URL, {
      headers: this.httpHeaders.append(
        "Authorization",
        JSON.parse(localStorage.getItem("sessionToken")).token
      ),
    });
  }

  updateIsPublicById(id: number, body: any) {
    return this.httpClient.put(
      this.URL_API + `updateIsPublicById/${id}`,
      body,
      {
        headers: this.httpHeaders.append(
          "Authorization",
          JSON.parse(localStorage.getItem("sessionToken")).token
        ),
      }
    );
  }

  findByIdPurchaseRequestTypeAndIdProducerAndIsPublicEqualToOne(
    idPurchaseRequestType: number,
    idProducer: number
  ) {
    const URL: string = `${this.URL_API}findByIdPurchaseRequestTypeAndIdProducerAndIsPublicEqualToOne/${idPurchaseRequestType}/${idProducer}`;

    return this.httpClient.get(URL, {
      headers: this.httpHeaders.append(
        "Authorization",
        JSON.parse(localStorage.getItem("sessionToken")).token
      ),
    });
  }
}
