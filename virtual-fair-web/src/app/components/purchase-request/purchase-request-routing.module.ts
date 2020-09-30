import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { PurchaseRequestComponent } from "../purchase-request/purchase-request.component";
import { PurchaseRequestCreateComponent } from "./purchase-request-create/purchase-request-create.component";

const routes: Routes = [
  {
    path: "",
    component: PurchaseRequestComponent,
  },
  {
    path: "create",
    component: PurchaseRequestCreateComponent
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class PurchaseRequestRoutingModule {}
