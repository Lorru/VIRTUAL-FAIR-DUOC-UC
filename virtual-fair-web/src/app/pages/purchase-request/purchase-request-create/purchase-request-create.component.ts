import { Component, OnInit } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import { ProductService } from "app/services/product.service";
import { PurchaseRequestProductService } from "app/services/purchase-request-product.service";
import { PurchaseRequestService } from "app/services/purchase-request.service";
import { UserService } from "app/services/user.service";
import { UtilsService } from "app/utils/utils.service";
declare var $: any;

@Component({
  selector: "app-purchase-request-create",
  templateUrl: "./purchase-request-create.component.html",
  styleUrls: ["./purchase-request-create.component.css"],
})
export class PurchaseRequestCreateComponent implements OnInit {
  purchaseRequest: any = {};
  productToAdd: any = {};
  productsToRequest: Array<any> = [];
  productList: Array<any>;
  processing: boolean = false;

  requestType: number;

  buyType: string;

  constructor(
    private _purchaseRequestService: PurchaseRequestService,
    private _productService: ProductService,
    private _router: Router,
    private _utilsService: UtilsService,
    private _userService: UserService,
    private _activatedRoute: ActivatedRoute,
    private _purchaseRequestProductService: PurchaseRequestProductService
  ) {
    this._activatedRoute.params.subscribe((params) => {
      this.buyType = params["type"];
    });
  }

  ngOnInit() {
    this.requestType = this._userService.getUser().idProfile === 5 ? 1 : 2;
    if (this.buyType === "residue") {
      this.getResidueProductList();
    } else {
      this.getProductList();
    }
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
      title: "Enviar Solicitud de Compra",
      message: "¿Confirmas que deseas realizar esta solicitud de compra?",
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
                idPurchaseRequestType: this.requestType,
                purchaseRequestProducts: this.productsToRequest.map(
                  (product) => ({
                    idProduct: product.object.id,
                    remark: product.comment,
                    requiresRefrigeration: +product.reqRefrigeration,
                    weight: product.weightKg,
                  })
                ),
                desiredDate: new Date(this.purchaseRequest.date),
              };
              this._purchaseRequestService.create(body).subscribe((res) => {
                this.processing = false;
                if (res.statusCode === 201) {
                  notificationData = {
                    message: "La solicitud de compra se envió con éxito.",
                    resultType: "success",
                  };
                  this._router.navigateByUrl("main/purchase-request");
                } else {
                  if (
                    res.message ===
                    "El contrato para realizar una solicitud de compra hacia el extranjero no es válido."
                  ) {
                    notificationData = {
                      message:
                        "El contrato para realizar una solicitud de compra hacia el extranjero no es válido.",
                      resultType: "failure",
                    };
                  } else {
                    notificationData = {
                      message:
                        "Hubo un problema al intenta enviar la solicitud",
                      resultType: "failure",
                    };
                  }
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
    this._productService.findAll().subscribe(
      (res: any) => {
        if (res.statusCode === 200) {
          this.productList = res.products;
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

  sendBalancePurchaseRequest() {
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
                    remark: "Compra de saldo",
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
                    this._router.navigateByUrl("main/purchase-request");
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

  getResidueProductList() {
    let notificationData: any;
    this._purchaseRequestProductService
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
