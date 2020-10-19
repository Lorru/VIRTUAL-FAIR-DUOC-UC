import { Component, OnInit } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import { ToastrService } from 'ngx-toastr';
import { PurchaseRequestProductService } from "src/app/services/purchase-request-product.service";

@Component({
  selector: "app-purchase-request-view",
  templateUrl: "./purchase-request-view.component.html",
  styleUrls: ["./purchase-request-view.component.css"],
})
export class PurchaseRequestViewComponent implements OnInit {
  purchaseRequestId: number;
  requestedProducts: Array<any> = [];

  constructor(
    private _purchaseRequestProductService: PurchaseRequestProductService,
    private _activatedRoute: ActivatedRoute,
    private _toastService: ToastrService
  ) {
    this._activatedRoute.params.subscribe((params) => {
      this.purchaseRequestId = params["id"];
    });
  }

  ngOnInit() {
    if (this.requestedProducts) {
      this.setRequestedProducts();
    }
  }

  setRequestedProducts() {
    this._purchaseRequestProductService
      .findByIdPurchaseRequest(this.purchaseRequestId)
      .subscribe((res) => {
        if (res.statusCode === 200) {
          this.requestedProducts = res.purchaseRequestProducts;
        } else {
          this._toastService.error(
            "Hubo un error al intentar obtener los productos solicitados"
          );
        }
      });
  }
}
