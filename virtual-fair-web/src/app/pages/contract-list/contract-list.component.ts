import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { UserService } from "app/services/user.service";
import { MatDialog } from "@angular/material/dialog";
import { UserRegisterComponent } from "app/pages/user-register/user-register.component";
import { ContractService } from "app/services/contract.service";
import { AddContractComponent } from "./add-contract/add-contract.component";

@Component({
  selector: "app-contract-list",
  templateUrl: "./contract-list.component.html",
  styleUrls: ["./contract-list.component.css"],
})
export class ContractListComponent implements OnInit {
  contracts: Array<any> = new Array<any>();
  displayedContracts: Array<any> = [];
  searcher: string;
  loadingFindAll: boolean;
  searchTerm: string;

  constructor(
    public router: Router,
    public _contractService: ContractService,
    public _dialog: MatDialog
  ) {}

  ngOnInit() {
    this.findAll();
  }

  findAll() {
    this.loadingFindAll = true;

    this._contractService.findAll().subscribe(
      (res) => {
        if (res.statusCode == 200) {
          this.loadingFindAll = false;
          this.contracts = res.contracts;
          this.contracts.map(
            (contract) =>
              (contract.displayInfo = {
                id: contract.id,
                userName: contract.user.fullName,
                userRol: contract.user.profile.name,
                expirationDate: contract.expirationDate,
                creationDate: contract.creationDate,
                isValid: contract.isValid
              })
          );
          this.contracts = this.contracts.sort((a, b) => a.id - b.id);
          this.displayedContracts = JSON.parse(JSON.stringify(this.contracts));
        } else if (res.statusCode == 204) {
          this.loadingFindAll = false;
          this.contracts = res.contracts;
          if (res.message) {
            //this._toastrService.error(res.message);
          }
        } else if (res.statusCode == 403) {
          this.loadingFindAll = false;
          this.router.navigateByUrl("/");
          localStorage.clear();
        } else if (res.statusCode == 500) {
          this.loadingFindAll = false;
          //this._toastrService.error(res.message);
        }
      },
      (error) => {
        this.loadingFindAll = false;
        //this._toastrService.error(environment.MESSAGE_ERROR_INTERNAL_API);
        console.clear();
      }
    );
  }

  createContract() {
    this._dialog
      .open(AddContractComponent, {
        data: {
          animal: "panda",
        }
      })
      .afterClosed()
      .subscribe((res) => {
        this.findAll();
      });
  }

  searchContract() {
    this.displayedContracts = this.contracts.filter((contract) =>
      this.filterContractDisplayInfo(contract)
    );
  }

  filterContractDisplayInfo(contract: any) {
    let matchesAny: boolean = false;
    Object.keys(contract.displayInfo).forEach((key) => {
      if (contract.displayInfo[key].toString().toLowerCase().includes(this.searchTerm.toLowerCase())) {
        matchesAny = true;
      }
    });
    return matchesAny;
  }

  downloadContract(id:number) {
    this._contractService.findById(id).subscribe((res: any) => {
      console.log("test", res);
      window.open(res.contract.contractPath, '_blank');
    });
  }
}
