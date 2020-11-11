import { DatePipe } from "@angular/common";
import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { PurchaseRequestService } from "app/services/purchase-request.service";
import { UserService } from "app/services/user.service";

@Component({
  selector: "app-purchase-request",
  templateUrl: "./purchase-request.component.html",
  styleUrls: ["./purchase-request.component.css"],
  providers: [DatePipe]
})
export class PurchaseRequestComponent implements OnInit {
  purchaseRequests: Array<any> = new Array<any>();
  displayedpurchaseRequests: Array<any> = [];
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
    this.findAll();
  }

  findAll() {
    this.loadingFindAll = true;

    this._purchaseRequestService
      .findByIdClient(this._userService.getUser().id)
      .subscribe(
        (res) => {
          if (res.statusCode == 200) {
            this.loadingFindAll = false;
            this.purchaseRequests = res.purchaseRequests;
            this.purchaseRequests.map(
              (purchaseRequest) =>
                (purchaseRequest.displayInfo = {
                  id: purchaseRequest.id,
                  totalWeight: purchaseRequest.totalWeight,
                  totalPrice: purchaseRequest.totalPrice,
                  creationDate: this._datePipe.transform(purchaseRequest.updateDate, 'dd/MM/yyyy'),
                  updateDate: this._datePipe.transform(purchaseRequest.updateDate, 'dd/MM/yyyy'),
                  state:
                    purchaseRequest.purchaseRequestStatus.name
                      .charAt(0)
                      .toUpperCase() +
                    purchaseRequest.purchaseRequestStatus.name
                      .toLowerCase()
                      .slice(1),
                })
            );
            this.purchaseRequests = this.purchaseRequests.sort(
              (a, b) => a.id - b.id
            );
            this.displayedpurchaseRequests = JSON.parse(
              JSON.stringify(this.purchaseRequests)
            );
          } else if (res.statusCode == 204) {
            this.loadingFindAll = false;
            this.purchaseRequests = res.users;
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
    this.displayedpurchaseRequests = this.purchaseRequests.filter(
      (purchaseRequest) => this.filterDisplayInfo(purchaseRequest)
    );
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
}
