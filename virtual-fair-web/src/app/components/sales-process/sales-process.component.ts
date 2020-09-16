import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { ToastrService } from 'ngx-toastr';

import { PurchaseRequestTypeService } from 'src/app/services/purchase-request-type.service';
import { SalesProcessStatusService } from 'src/app/services/sales-process-status.service';
import { SalesProcessService } from 'src/app/services/sales-process.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-sales-process',
  templateUrl: './sales-process.component.html',
  styleUrls: ['./sales-process.component.css'],
  providers:[
    SalesProcessService,
    SalesProcessStatusService,
    PurchaseRequestTypeService
  ]
})
export class SalesProcessComponent implements OnInit {

  userConnect: any;

  salesProcesss: Array<any> = new Array<any>();
  salesProcesssByIdProducer: Array<any> = new Array<any>();
  salesProcessStatuss: Array<any> = new Array<any>();
  purchaseRequestTypes: Array<any> = new Array<any>();

  idSalesProcessStatus: number;
  idPurchaseRequestType: number;

  loadingFindAllSalesProcessStatus: boolean;
  loadingFindAllPurchaseRequestType: boolean;
  loadingFindByIdSalesProcessStatusAndIdPurchaseRequestType: boolean;
  loadingFindByIdProducerAndFindByIdSalesProcessStatusAndIdPurchaseRequestType: boolean;

  constructor(private router: Router, private _toastrService: ToastrService, private _salesProcessService: SalesProcessService, private _salesProcessStatus: SalesProcessStatusService, private _purchaseRequestType: PurchaseRequestTypeService) { }

  ngOnInit() {

    this.userConnect = JSON.parse(localStorage.getItem('userConnect'));

    this.findAllPurchaseRequestType();

  }

  findAllPurchaseRequestType(){

    this.loadingFindAllPurchaseRequestType = true;

    this._purchaseRequestType.findAll().subscribe(res => {

      if(res.statusCode == 200){

        this.loadingFindAllPurchaseRequestType = false;
        this.purchaseRequestTypes = res.purchaseRequestTypes;
        this.idPurchaseRequestType = this.purchaseRequestTypes[0].id;

        this.findAllSalesProcessStatus();

      }else if(res.statusCode == 204){

        this.loadingFindAllPurchaseRequestType = false;
        this.purchaseRequestTypes = res.purchaseRequestTypes;

        if(res.message){

          this._toastrService.error(res.message);

        }

      }else if(res.statusCode == 403){

        this.loadingFindAllPurchaseRequestType = false;
        this.router.navigateByUrl('/');
        localStorage.clear();

      }else if(res.statusCode == 500){

        this.loadingFindAllPurchaseRequestType = false;
        this._toastrService.error(res.message);

      }

    }, error => {

      this.loadingFindAllPurchaseRequestType = false;
      this._toastrService.error(environment.MESSAGE_ERROR_INTERNAL_API);
      console.clear();

    });
  }

  findAllSalesProcessStatus(){

    this.loadingFindAllSalesProcessStatus = true;

    this._salesProcessStatus.findAll().subscribe(res => {

      if(res.statusCode == 200){

        this.loadingFindAllSalesProcessStatus = false;
        this.salesProcessStatuss = res.salesProcessStatus;
        this.idSalesProcessStatus = this.salesProcessStatuss[0].id;

        if(this.userConnect.idProfile == 3){

          this.findByIdProducerAndIdSalesProcessStatusAndIdPurchaseRequestType();

        }

        this.findByIdSalesProcessStatusAndIdPurchaseRequestType();

      }else if(res.statusCode == 204){

        this.loadingFindAllSalesProcessStatus = false;
        this.salesProcessStatuss = res.salesProcessStatus;

        if(res.message){

          this._toastrService.error(res.message);

        }

      }else if(res.statusCode == 403){

        this.loadingFindAllSalesProcessStatus = false;
        this.router.navigateByUrl('/');
        localStorage.clear();

      }else if(res.statusCode == 500){

        this.loadingFindAllSalesProcessStatus = false;
        this._toastrService.error(res.message);

      }

    }, error => {

      this.loadingFindAllSalesProcessStatus = false;
      this._toastrService.error(environment.MESSAGE_ERROR_INTERNAL_API);
      console.clear();

    });
  }

  findByIdSalesProcessStatusAndIdPurchaseRequestType(){

    this.loadingFindByIdSalesProcessStatusAndIdPurchaseRequestType = true;

    this._salesProcessService.findByIdSalesProcessStatusAndIdPurchaseRequestType(this.idSalesProcessStatus, this.idPurchaseRequestType).subscribe(res => {

      if(res.statusCode == 200){

        this.loadingFindByIdSalesProcessStatusAndIdPurchaseRequestType = false;
        this.salesProcesss = res.salesProcess;

      }else if(res.statusCode == 204){

        this.loadingFindByIdSalesProcessStatusAndIdPurchaseRequestType = false;
        this.salesProcesss = res.salesProcess;

        if(res.message){

          this._toastrService.error(res.message);

        }

      }else if(res.statusCode == 403){

        this.loadingFindByIdSalesProcessStatusAndIdPurchaseRequestType = false;
        this.router.navigateByUrl('/');
        localStorage.clear();

      }else if(res.statusCode == 500){

        this.loadingFindByIdSalesProcessStatusAndIdPurchaseRequestType = false;
        this._toastrService.error(res.message);

      }

    }), error => {

      this.loadingFindByIdSalesProcessStatusAndIdPurchaseRequestType = false;
      this._toastrService.error(environment.MESSAGE_ERROR_INTERNAL_API);
      console.clear();

    };
  }

  findByIdProducerAndIdSalesProcessStatusAndIdPurchaseRequestType(){

    this.loadingFindByIdProducerAndFindByIdSalesProcessStatusAndIdPurchaseRequestType = true;

    this._salesProcessService.findByIdProducerAndIdSalesProcessStatusAndIdPurchaseRequestType(this.userConnect.id, this.idSalesProcessStatus, this.idPurchaseRequestType).subscribe(res => {

      if(res.statusCode == 200){

        this.loadingFindByIdProducerAndFindByIdSalesProcessStatusAndIdPurchaseRequestType = false;
        this.salesProcesssByIdProducer = res.salesProcess;

      }else if(res.statusCode == 204){

        this.loadingFindByIdProducerAndFindByIdSalesProcessStatusAndIdPurchaseRequestType = false;
        this.salesProcesssByIdProducer = res.salesProcess;

        if(res.message){

          this._toastrService.error(res.message);

        }

      }else if(res.statusCode == 403){

        this.loadingFindByIdProducerAndFindByIdSalesProcessStatusAndIdPurchaseRequestType = false;
        this.router.navigateByUrl('/');
        localStorage.clear();

      }else if(res.statusCode == 500){

        this.loadingFindByIdProducerAndFindByIdSalesProcessStatusAndIdPurchaseRequestType = false;
        this._toastrService.error(res.message);

      }

    }), error => {

      this.loadingFindByIdProducerAndFindByIdSalesProcessStatusAndIdPurchaseRequestType = false;
      this._toastrService.error(environment.MESSAGE_ERROR_INTERNAL_API);
      console.clear();

    };
  }

}
