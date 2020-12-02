import { ComponentType } from "@angular/cdk/portal";
import { Injectable, TemplateRef } from "@angular/core";
import { MatDialog, MatDialogRef } from "@angular/material/dialog";
import { ConfirmationModalComponent } from "./confirmation-modal/confirmation-modal.component";
import { ResultModalComponent } from "./result-modal/result-modal.component";
declare var $: any;

@Injectable({
  providedIn: "root",
})
export class UtilsService {
  constructor(public _modalService: MatDialog) {}

  openModal(modalComponent: ComponentType<any> | TemplateRef<any>, modalData?: any): MatDialogRef<any> {
    const modalRef: MatDialogRef<any> = this._modalService.open(
      modalComponent,
      {
        data: modalData,
      }
    );

    return modalRef;
  }

  openConfirmationModal(modalData: any) {
    const modalRef: MatDialogRef<any> = this._modalService.open(
      ConfirmationModalComponent,
      {
        data: modalData,
      }
    );

    return modalRef;
  }

  showNotification(data: any) {
    const icon: string = data.resultType === 'success' ? 'check_circle_outline' : 'highlight_off';
    $.notify(
      {
        icon: data.resultType === 'success' ? 'check_circle_outline' : 'highlight_off',
        message: data.message,
      },
      {
        type: data.resultType === 'success' ? 'success' : 'danger',
        timer: 1000,
        placement: {
          from: 'bottom',
          align: 'center',
        },
        template:
          '<div data-notify="container" class="col-xl-4 col-lg-4 col-11 col-sm-4 col-md-4 alert alert-{0} alert-with-icon" role="alert">' +
          '<button mat-button  type="button" aria-hidden="true" class="close mat-button" data-notify="dismiss">  <i class="material-icons">close</i></button>' +
          '<i class="material-icons" data-notify="icon">' + icon + '</i> ' +
          '<span data-notify="title">{1}</span> ' +
          '<span data-notify="message">{2}</span>' +
          '<div class="progress" data-notify="progressbar">' +
          '<div class="progress-bar progress-bar-{0}" role="progressbar" aria-valuenow="0" aria-valuemin="0" aria-valuemax="100" style="width: 0%;"></div>' +
          "</div>" +
          '<a href="{3}" target="{4}" data-notify="url"></a>' +
          "</div>",
      }
    );
  }
}