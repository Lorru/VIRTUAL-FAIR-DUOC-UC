import { Component, Inject, OnInit } from "@angular/core";
import { FormControl } from "@angular/forms";
import { MatDialogRef, MAT_DIALOG_DATA } from "@angular/material/dialog";
import { PurchaseRequestService } from "app/services/purchase-request.service";
import { TransportAuctionService } from "app/services/transport-auction.service";
import { UserService } from "app/services/user.service";
import { UtilsService } from "app/utils/utils.service";
import { Observable, Subscription } from "rxjs";
import { map, startWith } from "rxjs/operators";

@Component({
  selector: "app-add-auction",
  templateUrl: "./add-auction.component.html",
  styleUrls: ["./add-auction.component.css"],
})
export class AddAuctionComponent implements OnInit {
  processing: boolean = false;
  subscriptions: Subscription = new Subscription();

  auction: any = {publish: true};

  myControl = new FormControl();
  filteredOptions: Observable<string[]>;

  salesProcesses: Array<any> = [];

  displayedSalesProcesses: Array<any> = [];

  searcher: string;
  loadingFindAll: boolean;
  searchTerm: string;

  constructor(
    private _userService: UserService,
    public dialogRef: MatDialogRef<AddAuctionComponent>,
    private _transportAuctionService: TransportAuctionService,
    private _utilsService: UtilsService,
    private _purchaseRequestService: PurchaseRequestService,
    @Inject(MAT_DIALOG_DATA) public data: any,

  ) {}

  ngOnInit(): void {
    this.getAllProcesses();

    this.filteredOptions = this.myControl.valueChanges.pipe(
      startWith(this.data.saleProcessId || ""),
      map((value) => (typeof value === "string" ? value : value.fullName)),
      map((value) =>
        value ? this._filter(value) : this.salesProcesses.slice()
      )
    );
  }

  getAllProcesses() {
    this.loadingFindAll = true;

    this._purchaseRequestService.findAll().subscribe((res: any) => {
      if (res.statusCode == 200) {
        this.loadingFindAll = false;
        this.salesProcesses = res.purchaseRequests;
        this.filterByStatus();
        this.filteredOptions = this.myControl.valueChanges.pipe(
          startWith(""),
          map((value) => (typeof value === "string" ? value : value.id)),
          map((name) =>
            name ? this._filter(name) : this.salesProcesses.slice()
          )
        );

        if(this.data.saleProcessId) {
          this.myControl.setValue(this.salesProcesses.find(saleProcess => saleProcess.id.toString() === this.data.saleProcessId))
        }
      } else if (res.statusCode == 403) {
        this.loadingFindAll = false;
        localStorage.clear();
      } else if (res.statusCode == 500) {
        this.loadingFindAll = false;
        //this._toastrService.error(res.message);
      }
    });
  }

  createAuction() {
    const modalData: any = {
      title:
        "Crear Subasta de Transporte",
      message:
        "¿Confirmas que deseas crear una subasta del proceso de venta con ID " + this.myControl.value.id + "?",
    };
    this._utilsService
      .openConfirmationModal(modalData)
      .afterClosed()
      .subscribe((res: any) => {
        if (res) {
          const body: any = {
            idPurchaseRequest: this.myControl.value.id,
            isPublic: +this.auction.publish,
            desiredDate: new Date(this.auction.expirationDate)
          }
          this._transportAuctionService.create(body).subscribe((res: any) => {
            console.log("creado", res);
            let notificationData: any;
            if (res.statusCode === 201) {
              notificationData = {
                message: "La subasta se creó exitosamente.",
                resultType: "success",
              };
              this.dialogRef.close(true);
            } else {
              notificationData = {
                message: "Hubo un problema al intentar crear la subasta.",
                resultType: "failure",
              };
            }

            this._utilsService.showNotification(notificationData);

          });
        }
      });
  }

  // setProcessesByType(idPurchaseRequestType: any, salesProcesses: any) {
  //   this.salesProcesses[idPurchaseRequestType] = salesProcesses;
  //   this.salesProcesses[idPurchaseRequestType].map(
  //     (purchaseRequest) =>
  //       (purchaseRequest.displayInfo = {
  //         id: purchaseRequest.id,
  //         totalWeight: purchaseRequest.totalWeight,
  //         totalPrice: purchaseRequest.totalPrice,
  //         desiredDate: this._datePipe.transform(
  //           purchaseRequest.desiredDate,
  //           "dd/MM/yyyy"
  //         ),
  //         state:
  //           purchaseRequest.purchaseRequestStatus.name.charAt(0).toUpperCase() +
  //           purchaseRequest.purchaseRequestStatus.name.toLowerCase().slice(1),
  //       })
  //   );
  //   this.salesProcesses[idPurchaseRequestType] = this.salesProcesses[
  //     idPurchaseRequestType
  //   ].sort((a, b) => a.id - b.id);
  //   this.displayedSalesProcesses[idPurchaseRequestType] = JSON.parse(
  //     JSON.stringify(this.salesProcesses[idPurchaseRequestType])
  //   );

  //   //this.separateProducerSalesProcesses(idPurchaseRequestType);
  //   this.filterByStatus();
  // }

  filterByStatus() {
    this.salesProcesses = this.salesProcesses.filter(
      (purchase) => purchase.idPurchaseRequestStatus === 3
    );
  }

  ngOnDestroy() {
    this.subscriptions.unsubscribe();
  }

  private _filter(value: string): string[] {
    return this.salesProcesses.filter(
      (saleProcess) => saleProcess.id.toString().indexOf(value) === 0
    );
  }

  displayFn(saleProcess: any): string {
    return saleProcess && saleProcess.id
      ? "ID Proceso: " +
          saleProcess.id +
          " - Cliente: " +
          saleProcess.client.fullName
      : "";
  }
}
