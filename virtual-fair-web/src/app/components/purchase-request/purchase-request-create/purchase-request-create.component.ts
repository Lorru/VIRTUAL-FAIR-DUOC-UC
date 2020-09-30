import { Component, OnInit } from "@angular/core";
import { ToastrService } from "ngx-toastr";
import { PurchaseRequestService } from "src/app/services/purchase-request.service";
declare var $:any;

@Component({
  selector: "app-purchase-request-create",
  templateUrl: "./purchase-request-create.component.html",
  styleUrls: ["./purchase-request-create.component.css"],
})
export class PurchaseRequestCreateComponent implements OnInit {
  purchaseRequest: any = {};
  productToAdd: any = {};
  productsToRequest: Array<any> = [];

  constructor(
    private _toastService: ToastrService,
    private _purchaseRequestService: PurchaseRequestService
  ) {}

  ngOnInit() {}

  ngAfterViewInit() {
    $('#myModal').on('shown.bs.modal', function () {
      $('#myInput').trigger('focus')
    })
  }

  addProductToRequest() {
    if (this.productToAdd.name && this.productToAdd.weightKg > 0) {
      this.productsToRequest.push(
        JSON.parse(JSON.stringify(this.productToAdd))
      );
    } else {
      this._toastService.error(
        "Los campos 'Nombre producto' y 'Peso Kg' son requeridos"
      );
    }
  }

  removeProductToRequest(productoToRemove: any) {
    let index: number = this.productsToRequest.indexOf(productoToRemove);
    this.productsToRequest.splice(index, 1);
  }

  sendPurchaseRequest() {
    try {
      let body: any = {
        idClient: JSON.parse(localStorage.getItem("userConnect")),
        idPurchaseRequestStatus: 0,
        idPurchaseRequestType: 0,
        isPublic: 0,
      };
      if (this.productsToRequest.length > 0 && this.purchaseRequest.date) {
        this._purchaseRequestService
          .create(body)
          .subscribe((res) => {
            if(res.statusCode === 200) {

            }
          })
          .unsubscribe();
      } else {
        this._toastService.error(
          "Debe haber agregado al menos un producto y tener la fecha deseada"
        );
      }
    } catch (error) {}
  }
}
