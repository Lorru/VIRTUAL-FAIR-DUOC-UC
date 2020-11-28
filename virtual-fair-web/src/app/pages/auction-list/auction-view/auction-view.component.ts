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

  constructor(
    private _transportAuctionService: TransportAuctionService,

    private _purchaseRequestProductService: PurchaseRequestProductService,
    private _activatedRoute: ActivatedRoute,
    private _purchaseRequestService: PurchaseRequestService,
    private _userService: UserService,
    private _utilsService: UtilsService,
    private _purchaseRequestProducerService: PurchaseRequestProducerService,
    public _dialog: MatDialog,
    private _transportAuctionCarrierService: TransportAuctionCarrierService
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
    this._transportAuctionService.findById(this.auctionId).subscribe((res: any) => {
      if (res.statusCode == 200) {
        this.auction = res.transportAuction;
        this.purchaseRequestStatus = this.auction.purchaseRequest.idPurchaseRequestStatus;

        this.setRequestedProducts(callback => {
          if(this.purchaseRequestStatus === 3 && this.isAdmin) {
            this.getWinners();
          } else {
            this.getAuctionParticipation();
          }
    
        });
      } else {
      }
      console.log("auction res", res);
    })
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
              ? "extranjero"
              : "local";
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
        "¿Confirmas que deseas participar en la subasta con ID: " + this.auctionId + "?",
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
            price: this.offer
          }

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
                notificationData = {
                  message:
                    "Hubo un problema al intentar registrar la oferta en el proceso.",
                  resultType: "failure",
                };
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
    // this._dialog
    //   .open(SalesProcessProdWinnersComponent, {
    //     data: {
    //       auctionId: this.auctionId
    //     },
    //     width: "700px",
    //   })
    //   .afterClosed()
    //   .subscribe((res) => {
    //     if(res) {
    //       this.ngOnInit();
    //     }
    //   });
  }

  getWinners() {
    this._purchaseRequestProducerService
      .getParticipantsByIdPurchaseRequest(this.auctionId)
      .subscribe((res: any) => {
        this.participants = res.purchaseRequestProducers || [];
      });
  }

  validateWeight(requestedProduct: any) {
    const weightToAdd: number = this.transportParticipation[requestedProduct.id].weight;
    if(weightToAdd > requestedProduct.weight || weightToAdd <= 0) {
      this.transportParticipation[requestedProduct.id].weight = undefined;
    }
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
