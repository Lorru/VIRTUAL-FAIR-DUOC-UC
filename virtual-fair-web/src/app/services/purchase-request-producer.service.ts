import { Injectable } from "@angular/core";
import { HttpHeaders, HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";

import { environment } from "environments/environment";

@Injectable({
  providedIn: "root",
})
export class PurchaseRequestProducerService {
  private httpHeaders: HttpHeaders = new HttpHeaders().set(
    "Content-Type",
    "application/json"
  );

  private URL_API: string = environment.URL_API + "PurchaseRequestProducer/";

  constructor(private httpClient: HttpClient) {}

  findByIdPurchaseRequest(idPurchaseRequest: number): Observable<any> {
    let URL: string =
      this.URL_API + "findByIdPurchaseRequest/" + idPurchaseRequest;

    return this.httpClient.get(URL, {
      headers: this.httpHeaders.append(
        "Authorization",
        JSON.parse(localStorage.getItem("sessionToken")).token
      ),
    });
  }

  createMassive(body: any): Observable<any> {
    let URL: string = this.URL_API + "createMassive";

    return this.httpClient.post(URL, body, {
      headers: this.httpHeaders.append(
        "Authorization",
        JSON.parse(localStorage.getItem("sessionToken")).token
      ),
    });
  }

  findByIdPurchaseRequestAndIdProducer(
    idPurchaseRequest: number,
    idProducer: number
  ) {
    let URL: string = `${this.URL_API}findByIdPurchaseRequestAndIdProducer/${idPurchaseRequest}/${idProducer}`;

    return this.httpClient.get(URL, {
      headers: this.httpHeaders.append(
        "Authorization",
        JSON.parse(localStorage.getItem("sessionToken")).token
      ),
    });
  }

  destroyByIdPurchaseRequestAndIdProducer(
    idPurchaseRequest: number,
    idProducer: number
  ) {
    let URL: string = `${this.URL_API}destroyByIdPurchaseRequestAndIdProducer/${idPurchaseRequest}/${idProducer}`;

    return this.httpClient.delete(URL, {
      headers: this.httpHeaders.append(
        "Authorization",
        JSON.parse(localStorage.getItem("sessionToken")).token
      ),
    });
  }
}
