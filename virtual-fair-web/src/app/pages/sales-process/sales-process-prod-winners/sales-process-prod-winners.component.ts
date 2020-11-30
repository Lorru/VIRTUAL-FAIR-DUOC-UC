import { Component, Inject, OnInit } from "@angular/core";
import { MatDialogRef, MAT_DIALOG_DATA } from "@angular/material/dialog";
import { ProfileService } from "app/services/profile.service";
import { PurchaseRequestProducerService } from "app/services/purchase-request-producer.service";
import { PurchaseRequestService } from "app/services/purchase-request.service";
import { UserService } from "app/services/user.service";
import { UtilsService } from "app/utils/utils.service";
import { Subscription } from "rxjs";

@Component({
  selector: "app-sales-process-prod-winners",
  templateUrl: "./sales-process-prod-winners.component.html",
  styleUrls: ["./sales-process-prod-winners.component.css"],
})
export class SalesProcessProdWinnersComponent implements OnInit {
  participants: Array<any> = [];

  processing: boolean = false;
  subscriptions: Subscription = new Subscription();

  constructor(
    public _userService: UserService,
    public dialogRef: MatDialogRef<SalesProcessProdWinnersComponent>,
    public _utilsService: UtilsService,
    public _purchaseRequestProducerService: PurchaseRequestProducerService,
    @Inject(MAT_DIALOG_DATA) public data: any,
    public _purchaseRequestService: PurchaseRequestService
  ) {}

  ngOnInit(): void {
    this.getWinners();
  }

  ngOnDestroy() {
    this.subscriptions.unsubscribe();
  }

  getWinners() {
    this._purchaseRequestProducerService
      .getParticipantsByIdPurchaseRequest(this.data.purchaseRequestId)
      .subscribe((res: any) => {
        this.participants = res.purchaseRequestProducers || [];
      });
  }

  acceptWinners() {
    const modalData: any = {
      title: "Aceptar ganadores Proceso de Venta " + this.data.purchaseRequestId,
      message:
        "¿Confirmas que deseas aceptar a estos ganadores? Se avanzará la etapa a Recolección de Productos."
    };
    this._utilsService
      .openConfirmationModal(modalData)
      .afterClosed()
      .subscribe((res: any) => {
        if (res) {
          this.advanceStatus();
        }
      });
  }

  advanceStatus() {
    this.processing = true;
    const body: any = {
      id: this.data.purchaseRequestId,
      idClient: this._userService.getUser().id,
      idPurchaseRequestStatus: 3,
    };
    this._purchaseRequestService
      .updateStatusById(this.data.purchaseRequestId, body)
      .subscribe((res: any) => {
        this.processing = false;
        let notificationData: any;
        if (res.statusCode === 200) {
          notificationData = {
            message:
              "Ganadores determinados exitosamente. Etapa avanzada a Recolección de Productos.",
            resultType: "success",
          };
          this.dialogRef.close(true);
        } else {
          notificationData = {
            message: "Hubo un problema al intentar avanzar de etapa.",
            resultType: "failure",
          };
        }
        this._utilsService.showNotification(notificationData);
      });
  }

  // registerNewUser() {
  //   this.processing = true;
  //   this.subscriptions.add(this._userService.create(this.newUserData).subscribe((res) => {
  //     this.processing = false;
  //     let resultModalData: any;
  //     if (res.statusCode === 201) {
  //       resultModalData = {
  //         message: "El usuario ha sido registrado con éxito.",
  //         resultType: "success",
  //       };
  //       this.dialogRef.close();
  //     } else {
  //       resultModalData = {
  //         message: "Hubo un problema al intentar registrar el usuario.",
  //         resultType: "failure",
  //       };
  //     }

  //     this._utilsService.showNotification(resultModalData);
  //   }));
  // }
}
