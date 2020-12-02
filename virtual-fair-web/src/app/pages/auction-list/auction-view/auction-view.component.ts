import { Component, OnInit } from "@angular/core";
import { MatDialog } from "@angular/material/dialog";
import { ActivatedRoute } from "@angular/router";
import { PurchaseRequestProducerService } from "app/services/purchase-request-producer.service";
import { PurchaseRequestProductService } from "app/services/purchase-request-product.service";
import { PurchaseRequestService } from "app/services/purchase-request.service";
import { TransportAuctionCarrierService } from "app/services/transport-auction-carrier.service";
import { TransportAuctionService } from "app/services/transport-auction.service";
import { UserService } from "app/services/user.service";
import { UtilsService } from "app/utils/utils.service";

@Component({
  selector: "app-auction-view",
  templateUrl: "./auction-view.component.html",
  styleUrls: ["./auction-view.component.css"],
})
export class AuctionViewComponent implements OnInit {
  auctionId: number;
  auction: any;
  requestedProducts: Array<any> = [];
  transportParticipation: any = {};

  participants: Array<any> = [];

  stringSalesProcessType: string = "";

  isTransporterParticipating: boolean = false;
  canSaveParticipation: boolean = false;

  purchaseRequestStatus: number;
  isAdmin: boolean;

  offer: number;

  processingAdvancingStatus: boolean;

  isUserWinner: boolean;

  constructor(
    public _transportAuctionService: TransportAuctionService,

    public _purchaseRequestProductService: PurchaseRequestProductService,
    public _activatedRoute: ActivatedRoute,
    public _purchaseRequestService: PurchaseRequestService,
    public _userService: UserService,
    public _utilsService: UtilsService,
    public _purchaseRequestProducerService: PurchaseRequestProducerService,
    public _dialog: MatDialog,
    public _transportAuctionCarrierService: TransportAuctionCarrierService
  ) {
    this.isAdmin = this._userService.getUser().idProfile === 1;
    this._activatedRoute.params.subscribe((params) => {
      this.auctionId = params["id"];
    });
  }

  ngOnInit() {
    this.findById();
  }

  findById() {
    this._transportAuctionService
      .findById(this.auctionId)
      .subscribe((res: any) => {
        if (res.statusCode == 200) {
          this.auction = res.transportAuction;
          this.purchaseRequestStatus = this.auction.purchaseRequest.idPurchaseRequestStatus;

          this.setRequestedProducts((callback) => {
            if (this.isAdmin) {
              this.getWinners();
              this.getAuctionParticipation();
            } else {
              this.getAuctionParticipation();
            }
          });
        } else {
        }
        console.log("auction res", res);
      });
  }

  setRequestedProducts(callback) {
    this._purchaseRequestProductService
      .findByIdPurchaseRequest(this.auction.idPurchaseRequest)
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
      this.transportParticipation[product.id] = {
        idPurchaseRequestProduct: product.id,
      };
    });
  }

  acceptDelivery() {
    const body: any = {
      id: this.auctionId,
      idClient: this._userService.getUser().id,
      idPurchaseRequestStatus: 8,
    };
    this._purchaseRequestService
      .updateStatusById(this.auctionId, body)
      .subscribe((res: any) => {
        console.log("acceptDelivery", res);
        let notificationData: any;
        if (res.statusCode === 200) {
          notificationData = {
            message:
              "Entrega registrada como recibida. Proceso de compra finalizado",
            resultType: "success",
          };
          this.ngOnInit();
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
      id: this.auctionId,
      idClient: this._userService.getUser().id,
      idPurchaseRequestStatus: statusId,
    };
    this._purchaseRequestService
      .updateStatusById(this.auctionId, body)
      .subscribe((res: any) => {
        if (res.statusCode === 200) {
          callback(true);
        }
      });
  }

  registerOffer() {
    const modalData: any = {
      title: "Confirmar registro de oferta",
      message:
        "¿Confirmas que deseas participar en la subasta con ID: " +
        this.auctionId +
        "?",
    };
    this._utilsService
      .openConfirmationModal(modalData)
      .afterClosed()
      .subscribe((res: any) => {
        if (res) {
          let body: any = {
            idCarrier: this._userService.getUser().idProfile,
            idTransportAuction: this.auctionId,
            isParticipant: 1,
            price: this.offer,
          };

          this._transportAuctionCarrierService
            .create(body)
            .subscribe((res: any) => {
              let notificationData: any;
              if (res.statusCode === 201) {
                notificationData = {
                  message: "La oferta se ha registrado con éxito.",
                  resultType: "success",
                };
                this.getAuctionParticipation();
              } else {
                if (
                  res.message ===
                  "El contrato para poder realizar una oferta de una solicitud de compra hacia el extranjero no es válido."
                ) {
                  notificationData = {
                    message:
                      "El contrato para poder realizar una oferta de una solicitud de compra hacia el extranjero no es válido.",
                    resultType: "failure",
                  };
                } else {
                  notificationData = {
                    message:
                      "Hubo un problema al intentar registrar la oferta en el proceso.",
                    resultType: "failure",
                  };
                }
              }
              this._utilsService.showNotification(notificationData);
            });
        }
      });
  }

  getAuctionParticipation() {
    this._transportAuctionCarrierService
      .findByIdTransportAuction(this.auctionId)
      .subscribe((res: any) => {
        if (res.statusCode === 200 || res.statusCode === 204) {
          this.participants = res.transportAuctionCarriers;
          this.participants = this.participants.sort(
            (a, b) => a.price - b.price
          );
          const thisCarrier: any = this.participants.find(
            (participant) =>
              participant.idCarrier === this._userService.getUser().id
          );
          this.canSaveParticipation = !thisCarrier;
          if (thisCarrier) {
            this.offer = thisCarrier.price;
          }
          if (this.participants[0]) {
            this.isUserWinner =
              this.participants[0].idCarrier === this._userService.getUser().id;
          }
          //this.canSaveParticipation = this.participants.find(participant => participant.id === this._userService.getUser().id);
        } else {
          let notificationData = {
            message:
              "Hubo un problema al intentar obtener la lista de participantes de la subasta.",
            resultType: "failure",
          };

          this._utilsService.showNotification(notificationData);
        }

        console.log("auctionParticipation", res);
      });
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
              this.auctionId,
              this._userService.getUser().id
            )
            .subscribe((res: any) => {
              let notificationData: any;
              if (res.statusCode === 200) {
                notificationData = {
                  message: "La participación se ha descartado con éxito.",
                  resultType: "success",
                };
                this.getAuctionParticipation();
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
      title: "Publicar subasta de transporte con ID: " + id,
      message:
        "¿Confirmas que deseas publicar la subasta de transporte con ID " +
        id +
        "?",
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
      title: "Quitar publicación de subasta de transporte con ID: " + id,
      message:
        "¿Confirmas que deseas quitar la publicación de la subasta de transporte con ID " +
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
    this._transportAuctionService
      .updateIsPublicById(id, body)
      .subscribe((res: any) => {
        let notificationData: any;
        if (res.statusCode === 200) {
          notificationData = {
            message: "La actualización de la subasta fue exitosa.",
            resultType: "success",
          };
          this.ngOnInit();
        } else {
          notificationData = {
            message: "Hubo un error al intentar actualizar la subasta.",
            resultType: "failure",
          };
        }
        this._utilsService.showNotification(notificationData);
      });
  }

  finalizeAuction() {
    const modalData: any = {
      title: "Aceptar mejor oferta",
      message:
        "¿Confirmas que deseas aceptar la oferta de $" +
        this.participants[0].price +
        " de " +
        this.participants[0].carrier.fullName +
        "?",
    };
    this._utilsService
      .openConfirmationModal(modalData)
      .afterClosed()
      .subscribe((res: any) => {
        if (res) {
          this.advanceStatus(10);
        }
      });
  }

  initTransport() {
    const modalData: any = {
      title: "Inicio transporte",
      message: "¿Confirmas que deseas registrar el inicio de transporte?",
    };
    this._utilsService
      .openConfirmationModal(modalData)
      .afterClosed()
      .subscribe((res: any) => {
        if (res) {
          this.advanceStatus(6);
        }
      });
  }

  deliver() {
    const modalData: any = {
      title: "Registrar entrega",
      message:
        "¿Confirmas que deseas registrar que has entregado los productos?",
    };
    this._utilsService
      .openConfirmationModal(modalData)
      .afterClosed()
      .subscribe((res: any) => {
        if (res) {
          this.advanceStatus(7);
        }
      });
  }

  advanceStatus(statusId: number) {
    this.processingAdvancingStatus = true;
    const body: any = {
      id: this.auction.idPurchaseRequest,
      idPurchaseRequestStatus: statusId,
    };
    this._purchaseRequestService
      .updateStatusById(this.auction.idPurchaseRequest, body)
      .subscribe((res: any) => {
        this.processingAdvancingStatus = false;
        let notificationData: any;
        if (res.statusCode === 200) {
          notificationData = {
            message: "Estado actualizado exitosamente.",
            resultType: "success",
          };
          this.ngOnInit();
        } else {
          notificationData = {
            message: "Hubo un problema al intentar actualizar el estado.",
            resultType: "failure",
          };
        }
        this._utilsService.showNotification(notificationData);
      });
  }

  getWinners() {
    this._transportAuctionCarrierService
      .getParticipantByIdPurchaseRequest(this.auction.idPurchaseRequest)
      .subscribe((res: any) => {
        this.participants = [res.transportAuctionCarrier] || [];
      });
  }
}
