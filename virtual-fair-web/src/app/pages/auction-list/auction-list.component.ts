import { Component, OnInit } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import { UserService } from "app/services/user.service";
import { MatDialog } from "@angular/material/dialog";
import { UserRegisterComponent } from "app/pages/user-register/user-register.component";
import { TransportAuctionService } from "app/services/transport-auction.service";
import { AddAuctionComponent } from "./add-auction/add-auction.component";

@Component({
  selector: "app-auction-list",
  templateUrl: "./auction-list.component.html",
  styleUrls: ["./auction-list.component.css"],
})
export class AuctionListComponent implements OnInit {
  auctions: Array<any> = new Array<any>();
  displayedAuctions: Array<any> = [];
  searcher: string;
  loadingFindAll: boolean;
  searchTerm: string;

  saleProcessIdToLookFor: number;
  openedAddAuction: boolean;

  constructor(
    private router: Router,
    private _userService: UserService,
    private _transportAuctionService: TransportAuctionService,
    public _dialog: MatDialog,
    private _activatedRoute: ActivatedRoute
  ) {
    this._activatedRoute.params.subscribe((params) => {
      this.saleProcessIdToLookFor = params["id"];
    });
  }

  ngOnInit() {
    this.findAll();
  }

  findAll() {
    this.loadingFindAll = true;

    this._transportAuctionService.findAll(this.searcher).subscribe(
      (res) => {
        if (res.statusCode == 200) {
          this.loadingFindAll = false;
          this.auctions = res.auctions;
          this.auctions.map(
            (user) =>
              (user.displayInfo = {
                id: user.id,
                fullName: user.fullName,
                email: user.email,
                profileName:
                  user.profile.name.charAt(0).toUpperCase() +
                  user.profile.name.toLowerCase().slice(1),
              })
          );
          this.auctions = this.auctions.sort((a, b) => a.id - b.id);
          this.displayedAuctions = JSON.parse(JSON.stringify(this.auctions));

          if(this.saleProcessIdToLookFor) {
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

  getUserEncoded(userData: any) {
    return btoa(JSON.stringify(userData));
  }

  searchUsers() {
    this.displayedAuctions = this.auctions.filter((user) =>
      this.filterUsersDisplayInfo(user)
    );
  }

  filterUsersDisplayInfo(user: any) {
    let matchesAny: boolean = false;
    Object.keys(user.displayInfo).forEach((key) => {
      if (user.displayInfo[key].toString().includes(this.searchTerm)) {
        matchesAny = true;
      }
    });
    return matchesAny;
  }
}
