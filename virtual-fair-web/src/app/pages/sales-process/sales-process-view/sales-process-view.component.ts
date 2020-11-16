import { Component, OnInit } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import { PurchaseRequestProducerService } from "app/services/purchase-request-producer.service";
import { PurchaseRequestProductService } from "app/services/purchase-request-product.service";
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
  productParticipacion: any = {};

  participants: Array<any> = [];

  stringSalesProcessType: string = "";

  isProducerParticipating: boolean = false;
  canSaveParticipation: boolean = false;

  constructor(
    private _purchaseRequestProductService: PurchaseRequestProductService,
    private _activatedRoute: ActivatedRoute,
    private _purchaseRequestService: PurchaseRequestService,
    private _userService: UserService,
    private _utilsService: UtilsService,
    private _purchaseRequestProducerService: PurchaseRequestProducerService
  ) {
    this._activatedRoute.params.subscribe((params) => {
      this.purchaseRequestId = params["id"];
    });
  }

  ngOnInit() {
    this.setRequestedProducts();
    this.getProducerParticipation();
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

  initMapProductParticipacion() {
    this.requestedProducts.forEach((product: any) => {
      this.productParticipacion[product.id] = {
        idPurchaseRequestProduct: product.id,
      };
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

  saveParticipation() {
    const modalData: any = {
      title: "Confirmar participación",
      message:
        "¿Confirmas que deseas participar en los productos que ingresaste?",
    };
    this._utilsService
      .openConfirmationModal(modalData)
      .afterClosed()
      .subscribe((res: any) => {
        if (res) {
          let body: Array<any> = [];
          Object.keys(this.productParticipacion).forEach((key) => {
            if (this.productParticipacion[key].idPurchaseRequestProduct) {
              const participation: any = {
                idProducer: this._userService.getUser().id,
                idPurchaseRequestProduct: this.productParticipacion[key]
                  .idPurchaseRequestProduct,
                price: this.productParticipacion[key].price,
                weight: this.productParticipacion[key].weight,
              };

              body.push(participation);
            }
          });

          this._purchaseRequestProducerService
            .createMassive(body)
            .subscribe((res: any) => {
              let notificationData: any;
              if (res.statusCode === 201) {
                notificationData = {
                  message: "La participación se ha registrado con éxito.",
                  resultType: "success",
                };
                this.getProducerParticipation();
              } else {
                notificationData = {
                  message:
                    "Hubo un problema al intentar registrar la participación en el proceso.",
                  resultType: "failure",
                };
              }
              this._utilsService.showNotification(notificationData);
            });
        }
      });
  }

  getProducerParticipation() {
    this._purchaseRequestProducerService
      .findByIdPurchaseRequest(this.purchaseRequestId)
      .subscribe((res: any) => {
        if (res.statusCode === 200 || res.statusCode === 204) {
          this.participants = res.purchaseRequestProducers;
          this.findProducerParticipation();
        } else {
          let notificationData = {
            message:
              "Hubo un problema al intentar obtener la lista de participantes del proceso.",
            resultType: "failure",
          };

          this._utilsService.showNotification(notificationData);
        }

        console.log("producerParticipation", res);
      });
  }

  findProducerParticipation() {
    this.initMapProductParticipacion();

    let numberParticipatingProducts: number = 0;
    this.participants.forEach((participant: any) => {
      if (participant.idProducer === this._userService.getUser().id) {
        this.isProducerParticipating = true;
        this.productParticipacion[participant.idPurchaseRequestProduct] = {
          weight: participant.weight,
          price: participant.price,
          isSet: true,
        };
      }
      numberParticipatingProducts++;
    });
    this.canSaveParticipation =
      !(numberParticipatingProducts === this.requestedProducts.length) ||
      numberParticipatingProducts === 0;
  }

  removeParticipation() {
    const modalData: any = {
      title: "Descartar participación",
      message:
        "¿Confirmas que deseas descartar tu participación actual en este proceso de venta?",
    };
    this._utilsService
      .openConfirmationModal(modalData)
      .afterClosed()
      .subscribe((res: any) => {
        if (res) {
          this._purchaseRequestProducerService
            .destroyByIdPurchaseRequestAndIdProducer(
              this.purchaseRequestId,
              this._userService.getUser().id
            )
            .subscribe((res: any) => {
              let notificationData: any;
              if (res.statusCode === 200) {
                notificationData = {
                  message: "La participación se ha descartado con éxito.",
                  resultType: "success",
                };
                this.getProducerParticipation();
              } else {
                notificationData = {
                  message:
                    "Hubo un problema al intentar descartar la participación en el proceso.",
                  resultType: "failure",
                };
              }
              this._utilsService.showNotification(notificationData);
            });
        }
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
        "¿Confirmas que deseas quitar la publicación del proceso de venta con ID " +
        id +
        "?",
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
            message:
              "Hubo un error al intentar actualizar el proceso de venta.",
            resultType: "failure",
          };
        }
        this._utilsService.showNotification(notificationData);
      });
  }

  // setMostlikelyToWInPerProduct() {
  //   this.requestedProducts.forEach((product: any) => {
  //     const productParticipants: Array<any> = this.participants.filter(
  //       (participant) => participant.idPurchaseRequestProduct == product.id
  //     );
  //     if (productParticipants.length > 0) {
  //       const product.lowestPriceBid = productParticipants.reduce((a, b) => {
  //         return a.price < b.price ? a.price : b.price;
  //       });
  //       product.lowestPriceBid =
  //       console.log("lowest", product.lowestPriceBid);
  //     }
  //   });
  // }
}
