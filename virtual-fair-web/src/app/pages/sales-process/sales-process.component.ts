import { DatePipe } from "@angular/common";
import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { PurchaseRequestStatusService } from "app/services/purchase-request-status.service";
import { PurchaseRequestService } from "app/services/purchase-request.service";
import { UserService } from "app/services/user.service";
import { UtilsService } from "app/utils/utils.service";

@Component({
  selector: "app-sales-process",
  templateUrl: "./sales-process.component.html",
  styleUrls: ["./sales-process.component.css"],
  providers: [DatePipe],
})
export class SalesProcessComponent implements OnInit {
  salesProcesses: any = {
    1: [],
    2: [],
  };

  displayedSalesProcesses: any = {
    1: [],
    2: [],
  };

  searcher: string;
  loadingFindAll: boolean;
  searchTerm: string;

  statusList: Array<any> = [];

  selectedStatus: any = "all";

  isPublicFilter: boolean = true;

  constructor(
    private router: Router,
    private _purchaseRequestService: PurchaseRequestService,
    private _userService: UserService,
    private _datePipe: DatePipe,
    private _purchaseRequestStatus: PurchaseRequestStatusService,
    private _utilsService: UtilsService
  ) {}

  ngOnInit() {
    if (this._userService.getUser().idProfile === 1) {
      this.getStatusList();
      this.getAllProcesses();
    } else {
      this.getPublicProcessesByTypePublic(1);
      this.getPublicProcessesByTypePublic(2);
    }
  }

  getPublicProcessesByTypePublic(idPurchaseRequestType: number) {
    this.loadingFindAll = true;

    this._purchaseRequestService
      .findByIdPurchaseRequestTypeAndIsPublicEqualToOne(idPurchaseRequestType)
      .subscribe((res: any) => {
        if (res.statusCode == 200) {
          this.loadingFindAll = false;
          this.setPublicProcessesByType(
            idPurchaseRequestType,
            res.purchaseRequests
          );
        } else if (res.statusCode == 403) {
          this.loadingFindAll = false;
          this.router.navigateByUrl("/");
          localStorage.clear();
        } else if (res.statusCode == 500) {
          this.loadingFindAll = false;
          //this._toastrService.error(res.message);
        }
      });
  }

  getPublicProcessesByTypeAll(idPurchaseRequestType: number) {
    this.loadingFindAll = true;

    this._purchaseRequestService
      .findByIdPurchaseRequestTypeAndIsPublicEqualToOne(idPurchaseRequestType)
      .subscribe((res: any) => {
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

  filterByStatus() {
    if (this.selectedStatus !== "all") {
      this.displayedSalesProcesses[1] = this.salesProcesses[1].filter(
        (purchase) => purchase.idPurchaseRequestStatus === this.selectedStatus
      );
      this.displayedSalesProcesses[2] = this.salesProcesses[2].filter(
        (purchase) => purchase.idPurchaseRequestStatus === this.selectedStatus
      );
    } else if (this.selectedStatus === "all") {
      this.displayedSalesProcesses[1] = JSON.parse(
        JSON.stringify(this.salesProcesses[1])
      );
      this.displayedSalesProcesses[2] = JSON.parse(
        JSON.stringify(this.salesProcesses[2])
      );
    }

    this.displayedSalesProcesses[1] = this.displayedSalesProcesses[1].filter(
      (purchase) => purchase.isPublic === +this.isPublicFilter
    );
    this.displayedSalesProcesses[2] = this.displayedSalesProcesses[2].filter(
      (purchase) => purchase.isPublic === +this.isPublicFilter
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

  setPublicProcessesByType(idPurchaseRequestType: any, purchaseRequests: any) {
    this.salesProcesses[idPurchaseRequestType] = purchaseRequests;
    this.salesProcesses[idPurchaseRequestType].map(
      (purchaseRequest) =>
        (purchaseRequest.displayInfo = {
          id: purchaseRequest.id,
          totalWeight: purchaseRequest.totalWeight,
          totalPrice: purchaseRequest.totalPrice,
          desiredDate: this._datePipe.transform(
            purchaseRequest.desiredDate,
            "dd/MM/yyyy"
          ),
          state:
            purchaseRequest.purchaseRequestStatus.name.charAt(0).toUpperCase() +
            purchaseRequest.purchaseRequestStatus.name.toLowerCase().slice(1),
        })
    );
    this.salesProcesses[idPurchaseRequestType] = this.salesProcesses[
      idPurchaseRequestType
    ].sort((a, b) => a.id - b.id);
    this.displayedSalesProcesses[idPurchaseRequestType] = JSON.parse(
      JSON.stringify(this.salesProcesses[idPurchaseRequestType])
    );
    this.filterByStatus();
  }

  getAllProcesses() {
    this.loadingFindAll = true;

    this._purchaseRequestService.findAll().subscribe((res: any) => {
      if (res.statusCode == 200) {
        this.loadingFindAll = false;
        const localPurchases: any = res.purchaseRequests.filter(
          (purchase) => purchase.idPurchaseRequestType === 1
        );
        const foreignPurchases: any = res.purchaseRequests.filter(
          (purchase) => purchase.idPurchaseRequestType === 2
        );

        this.setPublicProcessesByType(1, localPurchases);
        this.setPublicProcessesByType(2, foreignPurchases);
      } else if (res.statusCode == 403) {
        this.loadingFindAll = false;
        this.router.navigateByUrl("/");
        localStorage.clear();
      } else if (res.statusCode == 500) {
        this.loadingFindAll = false;
        //this._toastrService.error(res.message);
      }
    });
  }

  getStatusList() {
    this._purchaseRequestStatus.findAll().subscribe((res) => {
      this.statusList = res.purchaseRequestStatus;
      console.log(this.statusList);
    });
  }

  publish(id: number) {
    const modalData: any = {
      title: "Publicar Proceso de Venta ID: " + id,
      message:
        "¿Confirmas que deseas publicar el proceso de venta con ID " + id + "?",
    };
    this._utilsService
      .openConfirmationModal(modalData)
      .afterClosed()
      .subscribe((res: any) => {
        if (res) {
          this.updateIsPublicById(id, 1);
        }
      });
  }

  unpublish(id: number) {
    const modalData: any = {
      title: "Quitar Publicación Proceso de Venta ID: " + id,
      message:
        "¿Confirmas que deseas quitar la publicación del proceso de venta con ID " + id + "?",
    };
    this._utilsService
      .openConfirmationModal(modalData)
      .afterClosed()
      .subscribe((res: any) => {
        if (res) {
          this.updateIsPublicById(id, 0);
        }
      });
  }

  updateIsPublicById(id: number, isPublic: number) {
    const body: any = { id: id, isPublic: isPublic };
    this._purchaseRequestService
      .updateIsPublicById(id, body)
      .subscribe((res: any) => {
        let notificationData: any;
        if (res.statusCode === 200) {
          notificationData = {
            message: "La actualización del proceso de venta fue exitosa.",
            resultType: "success",
          };
          this.ngOnInit();
        } else {
          notificationData = {
            message: "Hubo un error al intentar actualizar el proceso de venta.",
            resultType: "failure",
          };
        }
        this._utilsService.showNotification(notificationData);
      });
  }
}
