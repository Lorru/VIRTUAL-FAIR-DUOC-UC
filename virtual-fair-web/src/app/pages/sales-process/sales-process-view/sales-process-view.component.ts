import { Component, OnInit } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import { PurchaseRequestProductService } from "app/services/purchase-request-product.service";
import { PurchaseRequestRemarkService } from "app/services/purchase-request-remark.service";
import { PurchaseRequestService } from "app/services/purchase-request.service";
import { UserService } from "app/services/user.service";
import { UtilsService } from "app/utils/utils.service";

@Component({
  selector: "app-sales-process-view",
  templateUrl: "./sales-process-view.component.html",
  styleUrls: ["./sales-process-view.component.css"],
})
export class SalesProcessViewComponent implements OnInit {
  purchaseRequestId: number;
  requestedProducts: Array<any> = [];

  stringSalesProcessType: string = "";

  constructor(
    private _purchaseRequestProductService: PurchaseRequestProductService,
    private _activatedRoute: ActivatedRoute,
    private _purchaseRequestService: PurchaseRequestService,
    private _userService: UserService,
    private _utilsService: UtilsService,
    private _purchaseRequestRemark: PurchaseRequestRemarkService
  ) {
    this._activatedRoute.params.subscribe((params) => {
      this.purchaseRequestId = params["id"];
    });
  }

  ngOnInit() {
    this.setRequestedProducts();
  }

  setRequestedProducts() {
    this._purchaseRequestProductService
      .findByIdPurchaseRequest(this.purchaseRequestId)
      .subscribe((res) => {
        if (res.statusCode === 200) {
          this.requestedProducts = res.purchaseRequestProducts;
          this.stringSalesProcessType =
            res.purchaseRequestProducts[0].purchaseRequest
              .idPurchaseRequestType === 1
              ? "extranjero"
              : "local";
        } else {
          const notificationData: any = {
            message:
              "Hubo un problema al intentar obtener los productos de la solicitud.",
            resultType: "failure",
          };
          this._utilsService.showNotification(notificationData);
        }
      });
  }

  acceptDelivery() {
    const body: any = {
      id: this.purchaseRequestId,
      idClient: this._userService.getUser().id,
      idPurchaseRequestStatus: 8,
    };
    this._purchaseRequestService
      .updateStatusById(this.purchaseRequestId, body)
      .subscribe((res: any) => {
        console.log("acceptDelivery", res);
        let notificationData: any;
        if (res.statusCode === 200) {
          notificationData = {
            message:
              "Entrega registrada como recibida. Proceso de compra finalizado",
            resultType: "success",
          };
          this.setRequestedProducts();
        } else {
          notificationData = {
            message: "Hubo un problema al intentar finalizar el proceso.",
            resultType: "failure",
          };
        }
        this._utilsService.showNotification(notificationData);
      });
  }

  // rejectDelivery() {
  //   this._utilsService
  //     .openModal(RejectDeliveryModalComponent)
  //     .afterClosed()
  //     .subscribe((res) => {
  //       if (res) {
  //         let notificationData: any;
  //         this.updateStatusById(9, (callback) => {
  //           if (callback) {
  //             this.sendRemark(res, (callback) => {
  //               if (callback) {
  //                 notificationData = {
  //                   message:
  //                     "La entrega se ha rechazado. Evaluaremos lo sucedido.",
  //                   resultType: "success",
  //                 };
  //                 this.setRequestedProducts();
  //               } else {
  //                 notificationData = {
  //                   message:
  //                     "Hubo un problema al intentar enviar la razón del rechazo.",
  //                   resultType: "failure",
  //                 };
  //               }
  //             });
  //             this._utilsService.showNotification(notificationData);
  //             return;
  //           } else {
  //             notificationData = {
  //               message: "Hubo un problema al intentar rechazar la entrega.",
  //               resultType: "failure",
  //             };
  //           }
  //           this._utilsService.showNotification(notificationData);
  //           return;
  //         });
  //       }
  //     });
  // }

  rejectDelivery() {
    // this._utilsService
    //   .openModal(RejectDeliveryModalComponent)
    //   .afterClosed()
    //   .subscribe((res) => {
    //     if (res) {
    //       const body: any = {
    //         idClient: this._userService.getUser().id,
    //         remark: res,
    //         idPurchaseRequestStatus: 9,
    //         idPurchaseRequest: +this.purchaseRequestId
    //       };
    //       this._purchaseRequestRemark.create(body).subscribe((res: any) => {
    //         let notificationData: any;
    //         if (res.statusCode === 200) {
    //           notificationData = {
    //             message: "La entrega se ha rechazado. Evaluaremos lo sucedido.",
    //             resultType: "success",
    //           };
    //         } else {
    //           notificationData = {
    //             message: "Hubo un problema al intentar rechazar la entrega.",
    //             resultType: "failure",
    //           };
    //         }
    //         this._utilsService.showNotification(notificationData);
    //       });
    //     }
    //   });
  }

  updateStatusById(statusId: number, callback) {
    const body: any = {
      id: this.purchaseRequestId,
      idClient: this._userService.getUser().id,
      idPurchaseRequestStatus: statusId,
    };
    this._purchaseRequestService
      .updateStatusById(this.purchaseRequestId, body)
      .subscribe((res: any) => {
        if (res.statusCode === 200) {
          callback(true);
        }
      });
  }
}
