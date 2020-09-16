import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { ToastrService } from 'ngx-toastr';

import { PurchaseRequestService } from 'src/app/services/purchase-request.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-purchase-request',
  templateUrl: './purchase-request.component.html',
  styleUrls: ['./purchase-request.component.css'],
  providers:[
    PurchaseRequestService
  ]
})
export class PurchaseRequestComponent implements OnInit {

  userConnect: any;

  purchaseRequests: Array<any> = new Array<any>();

  searcher: string;

  loadingFindByIdClient: boolean;

  constructor(private router: Router, private _toastrService: ToastrService, private _purchaseRequestService: PurchaseRequestService) { }

  ngOnInit() {

    this.userConnect = JSON.parse(localStorage.getItem('userConnect'));

    this.findByIdClient();

  }

  findByIdClient(){

    this.loadingFindByIdClient = true;

    this._purchaseRequestService.findByIdClient(this.userConnect.id, this.searcher).subscribe(res => {

      if(res.statusCode == 200){

        this.loadingFindByIdClient = false;
        this.purchaseRequests = res.purchaseRequests;

      }else if(res.statusCode == 204){

        this.loadingFindByIdClient = false;
        this.purchaseRequests = res.purchaseRequests;

        if(res.message){

          this._toastrService.error(res.message);

        }

      }else if(res.statusCode == 403){

        this.loadingFindByIdClient = false;
        this.router.navigateByUrl('/');
        localStorage.clear();

      }else if(res.statusCode == 500){

        this.loadingFindByIdClient = false;
        this._toastrService.error(res.message);

      }

    }, error => {

      this.loadingFindByIdClient = false;
      this._toastrService.error(environment.MESSAGE_ERROR_INTERNAL_API);
      console.clear();

    });

  }
}
