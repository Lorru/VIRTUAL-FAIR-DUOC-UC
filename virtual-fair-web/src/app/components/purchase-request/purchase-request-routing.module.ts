import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { PurchaseRequestComponent } from "../purchase-request/purchase-request.component";
import { PurchaseRequestCreateComponent } from "./purchase-request-create/purchase-request-create.component";
import { PurchaseRequestViewComponent } from './purchase-request-view/purchase-request-view.component';

const routes: Routes = [
  {
    path: "",
    component: PurchaseRequestComponent
  },
  {
    path: "create",
    component: PurchaseRequestCreateComponent
  },
  {
    path: "view/:id",
    component: PurchaseRequestViewComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class PurchaseRequestRoutingModule {}
