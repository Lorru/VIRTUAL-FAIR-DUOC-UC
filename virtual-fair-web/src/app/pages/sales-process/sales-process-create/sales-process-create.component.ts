import { Component, OnInit } from "@angular/core";
import { Router } from '@angular/router';
import { ProductService } from "app/services/product.service";
import { PurchaseRequestService } from "app/services/purchase-request.service";
import { UtilsService } from "app/utils/utils.service";
declare var $:any;

@Component({
  selector: "app-sales-process-create",
  templateUrl: "./sales-process-create.component.html",
  styleUrls: ["./sales-process-create.component.css"],
})
export class SalesProcessCreateComponent implements OnInit {
  purchaseRequest: any = {};
  productToAdd: any = {};
  productsToRequest: Array<any> = [];
  productList: Array<any>;
  processing: boolean = false;

  constructor(
    private _purchaseRequestService: PurchaseRequestService,
    private _productService: ProductService,
    private _router: Router,
    private _utilsService: UtilsService
  ) {}

  ngOnInit() {
    this.getProductList();
  }

  ngAfterViewInit() {
    $('#myModal').on('shown.bs.modal', function () {
      $('#myInput').trigger('focus')
    })
  }

  addProductToRequest() {
    console.log("producto",this.productToAdd.object);
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
    try {
      let notificationData: any;
      if (this.productsToRequest.length > 0 && this.purchaseRequest.date) {
        let body: any = {
          idClient: JSON.parse(localStorage.getItem("userConnect")).id,
          idPurchaseRequestType: 1,
          purchaseRequestProducts: this.productsToRequest.map(product => ({
            idProduct: product.object.id,
            remark: product.comment,
            requiresRefrigeration: +product.reqRefrigeration,
            weight: product.weightKg
          })),
          desiredDate: new Date(this.purchaseRequest.date)
        };
        this._purchaseRequestService
          .create(body)
          .subscribe((res) => {
            this.processing = false;
            if (res.statusCode === 201) {
              notificationData = {
                message: "La solicitud de compra se envió con éxito.",
                resultType: "success",
              };
              this._router.navigateByUrl("main/purchase-request");
            } else {
              notificationData = {
                message: "Hubo un problema al intentar enviar la solicitud de compra.",
                resultType: "failure",
              };
            }
      
            this._utilsService.showNotification(notificationData);
          })
      } else {
        notificationData = {
          message: "Debe haber agregado al menos un producto e indicar la fecha deseada.",
          resultType: "failure",
        };
        this._utilsService.showNotification(notificationData);
      }
    } catch (error) {
      console.error(error);
    }
  }

  getProductList() {
    let notificationData: any;
    this._productService.findAll().subscribe((res: any) => {
      if(res.statusCode === 200) {
        this.productList = res.products;
      } else {
        notificationData = {
          message: "Ocurrió un error al intentar obtener los productos.",
          resultType: "failure",
        };
        this._utilsService.showNotification(notificationData);
      }
    }, (error: any) => {
      notificationData = {
        message: "Ocurrió un error al intentar obtener los productos.",
        resultType: "failure",
      };
    });
  }
}
