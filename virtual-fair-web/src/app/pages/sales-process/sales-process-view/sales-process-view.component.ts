import { Component, OnInit } from "@angular/core";
import { MatDialog } from "@angular/material/dialog";
import { ActivatedRoute } from "@angular/router";
import { PurchaseRequestProducerService } from "app/services/purchase-request-producer.service";
import { PurchaseRequestProductService } from "app/services/purchase-request-product.service";
import { PurchaseRequestService } from "app/services/purchase-request.service";
import { ReportService } from "app/services/report.service";
import { TransportAuctionCarrierService } from "app/services/transport-auction-carrier.service";
import { UserService } from "app/services/user.service";
import { UtilsService } from "app/utils/utils.service";
import { SalesProcessProdWinnersComponent } from "../sales-process-prod-winners/sales-process-prod-winners.component";

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

  transportParticipants: Array<any> = [];

  stringSalesProcessType: string = "";

  isProducerParticipating: boolean = false;
  canSaveParticipation: boolean = false;

  purchaseRequestStatus: number;
  isAdmin: boolean;

  isProducerWinner: boolean;

  participatingText: string;

  constructor(
    public _purchaseRequestProductService: PurchaseRequestProductService,
    public _activatedRoute: ActivatedRoute,
    public _purchaseRequestService: PurchaseRequestService,
    public _userService: UserService,
    public _utilsService: UtilsService,
    public _purchaseRequestProducerService: PurchaseRequestProducerService,
    public _dialog: MatDialog,
    public _reportService: ReportService,
    public _transportAuctionCarrier: TransportAuctionCarrierService
  ) {
    this.isAdmin = this._userService.getUser().idProfile === 1;
    this._activatedRoute.params.subscribe((params) => {
      this.purchaseRequestId = params["id"];
    });
  }

  ngOnInit() {
    this.setRequestedProducts((callback) => {
      this.purchaseRequestStatus = this.requestedProducts[0].purchaseRequest.idPurchaseRequestStatus;
      if (this.purchaseRequestStatus === 3 && this.isAdmin) {
        this.getWinners();
      } else {
        this.getProducerParticipation();
        if (this.isAdmin) {
          this.getTransportistParticipation();
          this.getTransportWinners();
        }
      }

      if (this.purchaseRequestStatus >= 3 && this._userService.getUser().idProfile === 3) {
        this.getIfProducerIsWinner();
      }
    });
  }

  getIfProducerIsWinner() {
    this._purchaseRequestProducerService.findByIdPurchaseRequestAndIdProducerAndIsParticipantEqualToOne(this.purchaseRequestId, this._userService.getUser().id).subscribe((res: any) => {
      if (res.statusCode === 200) {
        this.isProducerWinner = res.result;
      }
    });
  }

  setRequestedProducts(callback) {
    this._purchaseRequestProductService
      .findByIdPurchaseRequest(this.purchaseRequestId)
      .subscribe((res) => {
        if (res.statusCode === 200) {
          this.requestedProducts = res.purchaseRequestProducts;
          this.stringSalesProcessType =
            res.purchaseRequestProducts[0].purchaseRequest
              .idPurchaseRequestType === 1
              ? "local"
              : "extranjero";
          callback(true);
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

  abandonProcess() {
    const modalData: any = {
      title: "Abandonar proceso",
      message:
        "¿Confirmas que deseas abandonar este proceso de venta? No se podrán realizar futuras acciones sobre este proceso.",
    };
    this._utilsService
      .openConfirmationModal(modalData)
      .afterClosed()
      .subscribe((res: any) => {
        if (res) {
          const body: any = {
            id: this.purchaseRequestId,
            idClient: this._userService.getUser().id,
            idPurchaseRequestStatus: 2,
          };
          this._purchaseRequestService
            .updateStatusById(this.purchaseRequestId, body)
            .subscribe((res: any) => {
              console.log("acceptDelivery", res);
              let notificationData: any;
              if (res.statusCode === 200) {
                notificationData = {
                  message: "Proceso abandonado exitosamente.",
                  resultType: "success",
                };
                this.ngOnInit();
              } else {
                notificationData = {
                  message: "Hubo un problema al intentar cambiar el estado.",
                  resultType: "failure",
                };
              }
              this._utilsService.showNotification(notificationData);
            });
        }
      });
  }

  reopenParticipation() {
    const modalData: any = {
      title: "Reabrir participación",
      message:
        "¿Confirmas que deseas reabrir la participación de este proceso de venta? El estado cambiará a 'Solicitado'.",
    };
    this._utilsService
      .openConfirmationModal(modalData)
      .afterClosed()
      .subscribe((res: any) => {
        if (res) {
          const body: any = {
            id: this.purchaseRequestId,
            idClient: this._userService.getUser().id,
            idPurchaseRequestStatus: 1,
          };
          this._purchaseRequestService
            .updateStatusById(this.purchaseRequestId, body)
            .subscribe((res: any) => {
              console.log("acceptDelivery", res);
              let notificationData: any;
              if (res.statusCode === 200) {
                notificationData = {
                  message:
                    "Proceso de venta reabierta a participación exitosamente.",
                  resultType: "success",
                };
                this.ngOnInit();
              } else {
                notificationData = {
                  message: "Hubo un problema al intentar cambiar el estado.",
                  resultType: "failure",
                };
              }
              this._utilsService.showNotification(notificationData);
            });
        }
      });
  }

  enableTransport() {
    const modalData: any = {
      title: "Habilitar Transporte",
      message:
        "¿Confirmas que deseas habilitar el transporte de este proceso de venta? El estado cambiará a 'En bodega'.",
    };
    this._utilsService
      .openConfirmationModal(modalData)
      .afterClosed()
      .subscribe((res: any) => {
        if (res) {
          const body: any = {
            id: this.purchaseRequestId,
            idClient: this._userService.getUser().id,
            idPurchaseRequestStatus: 5,
          };
          this._purchaseRequestService
            .updateStatusById(this.purchaseRequestId, body)
            .subscribe((res: any) => {
              console.log("acceptDelivery", res);
              let notificationData: any;
              if (res.statusCode === 200) {
                notificationData = {
                  message:
                    "Proceso de venta habilitada para transporte exitosamente.",
                  resultType: "success",
                };
                this.ngOnInit();
              } else {
                notificationData = {
                  message: "Hubo un problema al intentar cambiar el estado.",
                  resultType: "failure",
                };
              }
              this._utilsService.showNotification(notificationData);
            });
        }
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
                expirationDate: new Date(
                  this.productParticipacion[key].expirationDate
                ),
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
                if (
                  res.message ===
                  "El contrato para poder participar de una solicitud de compra hacia el extranjero no es válido."
                ) {
                  notificationData = {
                    message:
                      "El contrato para poder participar de una solicitud de compra hacia el extranjero no es válido.",
                    resultType: "failure",
                  };
                } else {
                  notificationData = {
                    message:
                      "Hubo un problema al intentar registrar la participación en el proceso.",
                    resultType: "failure",
                  };
                }
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

  getTransportistParticipation() {
    this._transportAuctionCarrier
      .findByIdPurchaseRequest(this.purchaseRequestId)
      .subscribe((res: any) => {
        if (res.statusCode === 200 || res.statusCode === 204) {
          this.transportParticipants = res.transportAuctionCarriers;
          this.transportParticipants = this.transportParticipants.sort(
            (a, b) => a.price - b.price
          );
          //this.findProducerParticipation();
        } else {
          let notificationData = {
            message:
              "Hubo un problema al intentar obtener la lista de participantes del proceso.",
            resultType: "failure",
          };

          this._utilsService.showNotification(notificationData);
        }

        console.log("transportist participants", res);
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
          expirationDate: new Date(participant.expirationDate)
            .toISOString()
            .substr(0, 10),
          isSet: true,
        };
      }
      numberParticipatingProducts++;
    });
    this.canSaveParticipation =
      !(numberParticipatingProducts === this.requestedProducts.length) ||
      numberParticipatingProducts === 0 ||
      !this.isProducerParticipating;
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

  setWinners() {
    this._dialog
      .open(SalesProcessProdWinnersComponent, {
        data: {
          purchaseRequestId: this.purchaseRequestId,
        },
        width: "700px",
      })
      .afterClosed()
      .subscribe((res) => {
        if (res) {
          this.ngOnInit();
        }
      });
  }

  getWinners() {
    this._purchaseRequestProducerService
      .getParticipantsByIdPurchaseRequest(this.purchaseRequestId)
      .subscribe((res: any) => {
        this.participants = res.purchaseRequestProducers || [];
      });
  }

  validateWeight(requestedProduct: any) {
    const weightToAdd: number = this.productParticipacion[requestedProduct.id]
      .weight;
    if (weightToAdd > requestedProduct.weight || weightToAdd <= 0) {
      this.productParticipacion[requestedProduct.id].weight = undefined;
    }
  }

  sendReport() {
    const modalData: any = {
      title: "Enviar reportes a participantes",
      message:
        "¿Confirmas que deseas enviar un reporte de venta a los correos de los participantes?",
    };
    this._utilsService
      .openConfirmationModal(modalData)
      .afterClosed()
      .subscribe((res: any) => {
        if (res) {
          this._reportService
            .sendReportToParticipantsByIdPurchaseRequest(this.purchaseRequestId)
            .subscribe((res: any) => {
              let notificationData: any;
              if (res.statusCode === 200) {
                notificationData = {
                  message: "Los reportes fueron enviados exitosamente",
                  resultType: "success",
                };
                this.ngOnInit();
              } else {
                notificationData = {
                  message: "Hubo un error al intentar enviar los reportes.",
                  resultType: "failure",
                };
              }
              this._utilsService.showNotification(notificationData);
            });
        }
      });
  }

  getIifProcerWinner() {
    this._purchaseRequestProducerService
      .findByIdPurchaseRequestAndIdProducerAndIsParticipantEqualToOne(
        this.purchaseRequestId,
        this._userService.getUser().id
      )
      .subscribe((res: any) => {
        this.participants = res.purchaseRequestProducers || [];
      });
  }

  getTransportWinners() {
    this._transportAuctionCarrier
      .getParticipantByIdPurchaseRequest(this.purchaseRequestId)
      .subscribe((res: any) => {
      });
  }
}
