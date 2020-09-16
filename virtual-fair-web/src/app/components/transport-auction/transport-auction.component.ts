import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { ToastrService } from 'ngx-toastr';

import { TransportAuctionService } from 'src/app/services/transport-auction.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-transport-auction',
  templateUrl: './transport-auction.component.html',
  styleUrls: ['./transport-auction.component.css'],
  providers:[
    TransportAuctionService
  ]
})
export class TransportAuctionComponent implements OnInit {

  userConnect: any;

  transportAuctions: Array<any> = new Array<any>();
  transportAuctionsByIdCarrier: Array<any> = new Array<any>();

  searcher: string;

  loadingFindAll: boolean;
  loadingFindByIdCarrier: boolean;

  constructor(private router: Router, private _toastrService: ToastrService, private _transportAuctionService: TransportAuctionService) { }

  ngOnInit() {
    
    this.userConnect = JSON.parse(localStorage.getItem('userConnect'));

    if(this.userConnect.idProfile == 4){

      this.findByIdCarrier();

    }

    this.findAll();

  }

  findAll(){

    this.loadingFindAll = true;

    this._transportAuctionService.findAll(this.searcher).subscribe(res => {

      if(res.statusCode == 200){

        this.loadingFindAll = false;
        this.transportAuctions = res.transportAuctions;

      }else if(res.statusCode == 204){

        this.loadingFindAll = false;
        this.transportAuctions = res.transportAuctions;

        if(res.message){

          this._toastrService.error(res.message);

        }

      }else if(res.statusCode == 403){

        this.loadingFindAll = false;
        this.router.navigateByUrl('/');
        localStorage.clear();

      }else if(res.statusCode == 500){

        this.loadingFindAll = false;
        this._toastrService.error(res.message);

      }

    }, error => {

      this.loadingFindAll = false;
      this._toastrService.error(environment.MESSAGE_ERROR_INTERNAL_API);
      console.clear();

    });

  }

  findByIdCarrier(){

    this.loadingFindByIdCarrier = true;

    this._transportAuctionService.findByIdCarrier(this.userConnect.id).subscribe(res => {

      if(res.statusCode == 200){

        this.loadingFindByIdCarrier = false;
        this.transportAuctionsByIdCarrier = res.transportAuctions;

      }else if(res.statusCode == 204){

        this.loadingFindByIdCarrier = false;
        this.transportAuctionsByIdCarrier = res.transportAuctions;

        if(res.message){

          this._toastrService.error(res.message);

        }

      }else if(res.statusCode == 403){

        this.loadingFindByIdCarrier = false;
        this.router.navigateByUrl('/');
        localStorage.clear();

      }else if(res.statusCode == 500){

        this.loadingFindByIdCarrier = false;
        this._toastrService.error(res.message);

      }

    }, error => {

      this.loadingFindByIdCarrier = false;
      this._toastrService.error(environment.MESSAGE_ERROR_INTERNAL_API);
      console.clear();

    });

  }

}
