import { Component, OnInit } from "@angular/core";
import { ToastrService } from "ngx-toastr";
import { PurchaseRequestService } from "src/app/services/purchase-request.service";
import { ProductService } from 'src/app/services/product.service';
import { Router } from '@angular/router';
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
  productList: Array<any>;

  constructor(
    private _toastService: ToastrService,
    private _purchaseRequestService: PurchaseRequestService,
    private _productService: ProductService,
    private _router: Router
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
      if (this.productsToRequest.length > 0 && this.purchaseRequest.date) {
        this._purchaseRequestService
          .create(body)
          .subscribe((res) => {
            if(res.statusCode === 201) {
              this._toastService.success(
                "La solicitud de compra se creó con exito."
              ).onHidden.subscribe(res => {
                this._router.navigate(['menu/purchase-request']);
              });
            } else {
              this._toastService.error(
                "Hubo un error al intentar crear la solicitud de compra."
              );
            }
          })
      } else {
        this._toastService.error(
          "Debe haber agregado al menos un producto y tener la fecha deseada."
        );
      }
    } catch (error) {
      console.error(error);
    }
  }

  getProductList() {
    this._productService.findAll().subscribe((res: any) => {
      if(res.statusCode === 200) {
        this.productList = res.products;
      } else {
        this._toastService.error(
          "Ocurrió un error al intentar obtener los productos"
        );
      }
    }, (error: any) => {
      this._toastService.error(
        "Ocurrió un error al intentar obtener los productos"
      );
    });
  }
}
