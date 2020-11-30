import { Component, Inject, OnInit } from "@angular/core";
import { MatDialogRef, MAT_DIALOG_DATA } from "@angular/material/dialog";
import { UtilsService } from "app/utils/utils.service";

@Component({
  selector: "app-reject-delivery-modal",
  templateUrl: "./reject-delivery-modal.component.html",
  styleUrls: ["./reject-delivery-modal.component.css"],
})
export class RejectDeliveryModalComponent implements OnInit {
  rejectionReason: string = "";
  minLength: number = 10;
  maxLength: number = 256;

  constructor(
    public dialogRef: MatDialogRef<RejectDeliveryModalComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    public _utilsService: UtilsService
  ) {}

  ngOnInit(): void {}

  isRejectionReasonValid() {
    const isRejectionValid: boolean =
      this.rejectionReason &&
      this.rejectionReason.trim() !== "" &&
      this.rejectionReason.length > this.minLength &&
      this.rejectionReason.length <= this.maxLength;

    if (isRejectionValid) {
      const modalData: any = {
        title: "Confirmar rechazo de entrega",
        message: "¿Confirmas que deseas rechazar la entrega?",
      };
      this._utilsService
        .openConfirmationModal(modalData)
        .afterClosed()
        .subscribe((res: any) => {
          if (res) {
            return true;
          }
        });
    }
  }
}
