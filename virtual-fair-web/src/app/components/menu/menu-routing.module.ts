import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { MenuComponent } from "./menu.component";
import { HomeComponent } from "../home/home.component";
import { SecurityTokenGuard } from "src/app/guards/security-token.guard";
import { PurchaseRequestComponent } from "../purchase-request/purchase-request.component";
import { SalesProcessComponent } from "../sales-process/sales-process.component";
import { TransportAuctionComponent } from "../transport-auction/transport-auction.component";
import { UserComponent } from "../user/user.component";
import { ReportComponent } from "../report/report.component";
import { PurchaseRequestGuard } from "src/app/guards/purchase-request.guard";
import { UserGuard } from "src/app/guards/user.guard";
import { SalesProcessGuard } from "src/app/guards/sales-process.guard";
import { TransportAuctionGuard } from "src/app/guards/transport-auction.guard";
import { ReportGuard } from "src/app/guards/report.guard";
import { ContractComponent } from "../contract/contract.component";
import { ContractGuard } from "src/app/guards/contract.guard";

const routes: Routes = [
  {
    path: "menu",
    component: MenuComponent,
    children: [
      {
        path: "home",
        component: HomeComponent,
        canActivate: [SecurityTokenGuard],
      },
      {
        path: "purchase-request",
        canActivate: [SecurityTokenGuard, PurchaseRequestGuard],
        loadChildren: () => import('../purchase-request/purchase-request.module').then(m => m.PurchaseRequestModule)
      },
      {
        path: "sales-process",
        component: SalesProcessComponent,
        canActivate: [SecurityTokenGuard, SalesProcessGuard],
      },
      {
        path: "transport-auction",
        component: TransportAuctionComponent,
        canActivate: [SecurityTokenGuard, TransportAuctionGuard],
      },
      {
        path: "users",
        component: UserComponent,
        canActivate: [SecurityTokenGuard, UserGuard],
      },
      {
        path: "contracts",
        component: ContractComponent,
        canActivate: [SecurityTokenGuard, ContractGuard],
      },
      {
        path: "reports",
        component: ReportComponent,
        canActivate: [SecurityTokenGuard, ReportGuard],
      },
      {
        path: "**",
        component: MenuComponent,
        canActivate: [SecurityTokenGuard],
      },
    ],
    canActivate: [SecurityTokenGuard],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class MenuRoutingModule {}
