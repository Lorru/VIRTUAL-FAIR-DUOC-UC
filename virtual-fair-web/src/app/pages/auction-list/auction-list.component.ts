import { Component, OnInit } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import { MatDialog } from "@angular/material/dialog";
import { TransportAuctionService } from "app/services/transport-auction.service";
import { AddAuctionComponent } from "./add-auction/add-auction.component";
import { DatePipe } from "@angular/common";
import { UserService } from "app/services/user.service";

@Component({
  selector: "app-auction-list",
  templateUrl: "./auction-list.component.html",
  styleUrls: ["./auction-list.component.css"],
  providers: [DatePipe]
})
export class AuctionListComponent implements OnInit {
  auctions: Array<any> = new Array<any>();
  displayedAuctions: Array<any> = [];
  searcher: string;
  loadingFindAll: boolean;
  searchTerm: string;

  saleProcessIdToLookFor: number;
  openedAddAuction: boolean;

  profileId: number;

  constructor(
    private router: Router,
    private _transportAuctionService: TransportAuctionService,
    public _dialog: MatDialog,
    private _activatedRoute: ActivatedRoute,
    private _datePipe: DatePipe,
    private _userService: UserService
  ) {
    this.profileId = this._userService.getUser().idProfile;
    this._activatedRoute.params.subscribe((params) => {
      this.saleProcessIdToLookFor = params["id"];
    });
  }

  ngOnInit() {
    if (this.profileId === 1) {
      this.findAll();
    } else {
      this.findByIsPublicEqualToOne();
    }
  }

  findAll() {
    this.loadingFindAll = true;

    this._transportAuctionService.findAll().subscribe(
      (res) => {
        if (res.statusCode == 200) {
          this.loadingFindAll = false;
          this.auctions = res.transportAuctions;
          this.auctions.map(
            (auction) =>
              (auction.displayInfo = {
                id: auction.id,
                idPurchaseRequest: auction.idPurchaseRequest,
                solicitedBy: auction.purchaseRequest.client.fullName,
                limitDate: this._datePipe.transform(
                  auction.desiredDate,
                  "dd/MM/yyyy"
                ),
                status: auction.purchaseRequest.purchaseRequestStatus.name
              })
          );
          this.auctions = this.auctions.sort((a, b) => a.id - b.id);
          this.displayedAuctions = JSON.parse(JSON.stringify(this.auctions));

          const auctionToLookFor: any = this.auctions.find(auction => auction.idPurchaseRequest.toString() === this.saleProcessIdToLookFor);

          if(!auctionToLookFor && this.saleProcessIdToLookFor && !this.openedAddAuction) {
            this.addAuction(this.saleProcessIdToLookFor);
          }
        } else if (res.statusCode == 204) {
          this.loadingFindAll = false;
          this.auctions = res.auctions;
          if(this.saleProcessIdToLookFor && !this.openedAddAuction) {
            this.addAuction(this.saleProcessIdToLookFor);
          }
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

  findByIsPublicEqualToOne() {
    this.loadingFindAll = true;

    this._transportAuctionService.findByIsPublicEqualToOne().subscribe(
      (res) => {
        if (res.statusCode == 200) {
          this.loadingFindAll = false;
          this.auctions = res.transportAuctions;
          this.auctions.map(
            (auction) =>
              (auction.displayInfo = {
                id: auction.id,
                idPurchaseRequest: auction.idPurchaseRequest,
                solicitedBy: auction.purchaseRequest.client.fullName,
                limitDate: this._datePipe.transform(
                  auction.desiredDate,
                  "dd/MM/yyyy"
                ),
                status: auction.purchaseRequest.purchaseRequestStatus.name
              })
          );
          this.auctions = this.auctions.sort((a, b) => a.id - b.id);
          this.displayedAuctions = JSON.parse(JSON.stringify(this.auctions));
        } else if (res.statusCode == 204) {
          this.loadingFindAll = false;
          this.auctions = res.auctions;
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














  addAuction(saleProcessId?: number) {
    this._dialog
      .open(AddAuctionComponent, {
        data: {
          saleProcessId: saleProcessId
        },
        width: "450px",
      })
      .afterClosed()
      .subscribe((res) => {
        this.openedAddAuction = true;
        this.findAll();
      });
  }

  getAuctionEncoded(auctionData: any) {
    return btoa(JSON.stringify(auctionData));
  }

  searchAuctions() {
    this.displayedAuctions = this.auctions.filter((auction) =>
      this.filterAuctionsDisplayInfo(auction)
    );
  }

  filterAuctionsDisplayInfo(auction: any) {
    let matchesAny: boolean = false;
    Object.keys(auction.displayInfo).forEach((key) => {
      if (auction.displayInfo[key].toString().toLowerCase().includes(this.searchTerm.toLowerCase())) {
        matchesAny = true;
      }
    });
    return matchesAny;
  }
}
