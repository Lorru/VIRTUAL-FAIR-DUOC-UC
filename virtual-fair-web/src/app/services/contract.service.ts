import { Injectable } from "@angular/core";
import { HttpHeaders, HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { environment } from "environments/environment";

@Injectable({
  providedIn: "root",
})
export class ContractService {
  public httpHeaders: HttpHeaders = new HttpHeaders().set(
    "Content-Type",
    "application/json"
  );

  public URL_API: string = environment.URL_API + "Contract/";

  constructor(public httpClient: HttpClient) {}

  findAll(searcher?: string): Observable<any> {
    let URL_CONTRACT: string = this.URL_API + "findAll";

    if (searcher) {
      URL_CONTRACT = URL_CONTRACT + "?searcher=" + searcher;
    }

    return this.httpClient.get(URL_CONTRACT, {
      headers: this.httpHeaders.append(
        "Authorization",
        JSON.parse(localStorage.getItem("sessionToken")).token
      ),
    });
  }

  create(body: any): Observable<any> {
    let URL: string = this.URL_API + "create";

    return this.httpClient.post(URL, body, {
      headers: this.httpHeaders.append(
        "Authorization",
        JSON.parse(localStorage.getItem("sessionToken")).token
      ),
    });
  }

  findById(id:number) {
    let URL: string = this.URL_API + "findById/" + id;

    return this.httpClient.get(URL, {
      headers: this.httpHeaders.append(
        "Authorization",
        JSON.parse(localStorage.getItem("sessionToken")).token
      ),
    });
  }
}
