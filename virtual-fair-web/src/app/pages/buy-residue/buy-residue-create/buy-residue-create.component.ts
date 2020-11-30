import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { ProductService } from "app/services/product.service";
import { PurchaseRequestProductService } from "app/services/purchase-request-product.service";
import { PurchaseRequestService } from "app/services/purchase-request.service";
import { UtilsService } from "app/utils/utils.service";
declare var $: any;

@Component({
  selector: "app-buy-residue-create",
  templateUrl: "./buy-residue-create.component.html",
  styleUrls: ["./buy-residue-create.component.css"],
})
export class BuyResidueCreateComponent implements OnInit {
  purchaseRequest: any = {};
  productToAdd: any = {};
  productsToRequest: Array<any> = [];
  productList: Array<any>;
  processing: boolean = false;

  constructor(
    private _purchaseRequestService: PurchaseRequestService,
    private _productService: PurchaseRequestProductService,
    private _router: Router,
    private _utilsService: UtilsService
  ) {}

  ngOnInit() {
    this.getProductList();
  }

  ngAfterViewInit() {
    $("#myModal").on("shown.bs.modal", function () {
      $("#myInput").trigger("focus");
    });
  }

  addProductToRequest() {
    console.log("producto", this.productToAdd.object);
    if (this.productToAdd.object && this.productToAdd.weightKg > 0) {
      this.productsToRequest.push(
        JSON.parse(JSON.stringify(this.productToAdd))
      );
    } else {
      let notificationData: any = {
        message: "Los campos 'Producto' y 'Peso Kg' son requeridos",
        resultType: "failure",
      };
      this._utilsService.showNotification(notificationData);
    }
  }

  removeProductToRequest(productoToRemove: any) {
    let index: number = this.productsToRequest.indexOf(productoToRemove);
    this.productsToRequest.splice(index, 1);
  }

  sendPurchaseRequest() {
    const modalData: any = {
      title: "Solicitar compra de saldo",
      message:
        "¿Confirmas que deseas realizar esta solicitud de compra de saldo?",
    };
    this._utilsService
      .openConfirmationModal(modalData)
      .afterClosed()
      .subscribe((res: any) => {
        if (res) {
          try {
            let notificationData: any;
            if (
              this.productsToRequest.length > 0 &&
              this.purchaseRequest.date
            ) {
              let body: any = {
                idClient: JSON.parse(localStorage.getItem("userConnect")).id,
                purchaseRequestProducts: this.productsToRequest.map(
                  (product) => ({
                    id: product.object.id,
                    idProduct: product.object.product.id,
                    requiresRefrigeration: +product.reqRefrigeration,
                    weight: product.weightKg,
                  })
                ),
                desiredDate: new Date(this.purchaseRequest.date),
              };
              this._purchaseRequestService
                .createBalancePurchaseRequest(body)
                .subscribe((res) => {
                  this.processing = false;
                  if (res.statusCode === 201) {
                    notificationData = {
                      message:
                        "La solicitud de compra de saldo se envió con éxito.",
                      resultType: "success",
                    };
                    this._router.navigateByUrl("main/buy-residue");
                  } else {
                    notificationData = {
                      message:
                        "Hubo un problema al intentar enviar la solicitud de compra de saldo.",
                      resultType: "failure",
                    };
                  }

                  this._utilsService.showNotification(notificationData);
                });
            } else {
              notificationData = {
                message:
                  "Debe haber agregado al menos un producto e indicar la fecha deseada.",
                resultType: "failure",
              };
              this._utilsService.showNotification(notificationData);
            }
          } catch (error) {
            console.error(error);
          }
        }
      });
  }

  getProductList() {
    let notificationData: any;
    this._productService
      .findByIdPurchaseRequestStatusInTwoNineAndExpirationDateGreatherThanNow()
      .subscribe(
        (res: any) => {
          if (res.statusCode === 200) {
            this.productList = res.purchaseRequestProducts;
          } else {
            notificationData = {
              message: "Ocurrió un error al intentar obtener los productos.",
              resultType: "failure",
            };
            this._utilsService.showNotification(notificationData);
          }
        },
        (error: any) => {
          notificationData = {
            message: "Ocurrió un error al intentar obtener los productos.",
            resultType: "failure",
          };
        }
      );
  }
}
