import { Component, Inject, OnInit } from "@angular/core";
import { MatDialogRef, MAT_DIALOG_DATA } from "@angular/material/dialog";

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
    @Inject(MAT_DIALOG_DATA) public data: any
  ) {}

  ngOnInit(): void {}

  isRejectionReasonValid() {
    return (
      this.rejectionReason &&
      this.rejectionReason.trim() !== "" &&
      this.rejectionReason.length > this.minLength &&
      this.rejectionReason.length <= this.maxLength
    );
  }
}
