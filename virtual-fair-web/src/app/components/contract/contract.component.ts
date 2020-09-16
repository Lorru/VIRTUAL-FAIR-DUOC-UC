import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { ToastrService } from 'ngx-toastr';

import { ContractService } from 'src/app/services/contract.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-contract',
  templateUrl: './contract.component.html',
  styleUrls: ['./contract.component.css'],
  providers:[
    ContractService
  ]
})
export class ContractComponent implements OnInit {

  contracts: Array<any> = new Array<any>();

  searcher: string;

  loadingFindAll: boolean;

  constructor(private router: Router, private _toastrService: ToastrService, private _contractService: ContractService) { }

  ngOnInit() {
    
    this.findAll();

  }

  findAll(){

    this.loadingFindAll = true;

    this._contractService.findAll(this.searcher).subscribe(res => {

      if(res.statusCode == 200){

        this.loadingFindAll = false;
        this.contracts = res.contracts;

      }else if(res.statusCode == 204){

        this.loadingFindAll = false;
        this.contracts = res.contracts;

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

}
