import { DatePipe } from "@angular/common";
import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { PurchaseRequestService } from "app/services/purchase-request.service";
import { UserService } from "app/services/user.service";

@Component({
  selector: "app-sales-process",
  templateUrl: "./sales-process.component.html",
  styleUrls: ["./sales-process.component.css"],
  providers: [DatePipe]
})
export class SalesProcessComponent implements OnInit {
  salesProcesses: any = {
    1: [],
    2: []
  }

  displayedSalesProcesses: any = {
    1: [],
    2: []
  };

  searcher: string;
  loadingFindAll: boolean;
  searchTerm: string;

  constructor(
    private router: Router,
    private _purchaseRequestService: PurchaseRequestService,
    private _userService: UserService,
    private _datePipe: DatePipe
  ) {}

  ngOnInit() {
    this.getPublicProcessesByTypePublic(1);
    this.getPublicProcessesByTypePublic(2);
  }

  getPublicProcessesByTypePublic(idPurchaseRequestType: number) {
    this.loadingFindAll = true;

    this._purchaseRequestService.findByIdPurchaseRequestTypeAndIsPublicEqualToOne(idPurchaseRequestType).subscribe((res: any) => {
      this.setPublicProcessesByType(idPurchaseRequestType, res);
    });
  }

  getPublicProcessesByTypeAll(idPurchaseRequestType: number) {
    this.loadingFindAll = true;

    this._purchaseRequestService.findByIdPurchaseRequestTypeAndIsPublicEqualToOne(idPurchaseRequestType).subscribe((res: any) => {
      this.setPublicProcessesByType(idPurchaseRequestType, res);
    });
  }

  registerUser() {
    // this._dialog.open(UserRegisterComponent, {
    //   data: {
    //     animal: 'panda'
    //   },
    //   width: '700px',
    // }).afterClosed().subscribe(res => {
    //   this.findAll();
    // });
  }

  getUserEncoded(userData: any) {
    return btoa(JSON.stringify(userData));
  }

  searchByTerm() {
    // this.displayedpurchaseRequests = this.foreignSalesProcesses.filter(
    //   (purchaseRequest) => this.filterDisplayInfo(purchaseRequest)
    // );
  }

  filterDisplayInfo(purchaseRequest: any) {
    let matchesAny: boolean = false;
    Object.keys(purchaseRequest.displayInfo).forEach((key) => {
      if (
        purchaseRequest.displayInfo[key] &&
        purchaseRequest.displayInfo[key].toString().includes(this.searchTerm)
      ) {
        matchesAny = true;
      }
    });
    return matchesAny;
  }

  setPublicProcessesByType(idPurchaseRequestType: any, res: any) {
    if (res.statusCode == 200) {
      this.loadingFindAll = false;
      this.salesProcesses[idPurchaseRequestType] = res.purchaseRequests;
      this.salesProcesses[idPurchaseRequestType].map(
        (purchaseRequest) =>
          (purchaseRequest.displayInfo = {
            id: purchaseRequest.id,
            totalWeight: purchaseRequest.totalWeight,
            totalPrice: purchaseRequest.totalPrice,
            desiredDate: this._datePipe.transform(purchaseRequest.desiredDate, 'dd/MM/yyyy'),
            state:
              purchaseRequest.purchaseRequestStatus.name
                .charAt(0)
                .toUpperCase() +
              purchaseRequest.purchaseRequestStatus.name
                .toLowerCase()
                .slice(1),
          })
      );
      this.salesProcesses[idPurchaseRequestType] = this.salesProcesses[idPurchaseRequestType].sort(
        (a, b) => a.id - b.id
      );
      this.displayedSalesProcesses[idPurchaseRequestType] = JSON.parse(
        JSON.stringify(this.salesProcesses[idPurchaseRequestType])
      );
    } else if (res.statusCode == 403) {
      this.loadingFindAll = false;
      this.router.navigateByUrl("/");
      localStorage.clear();
    } else if (res.statusCode == 500) {
      this.loadingFindAll = false;
      //this._toastrService.error(res.message);
    }
  }
}
