import { Routes } from "@angular/router";

import { DashboardComponent } from "../../pages/dashboard/dashboard.component";
import { UserProfileComponent } from "../../pages/user-profile/user-profile.component";
import { TableListComponent } from "../../table-list/table-list.component";
import { TypographyComponent } from "../../typography/typography.component";
import { IconsComponent } from "../../icons/icons.component";
import { MapsComponent } from "../../maps/maps.component";
import { NotificationsComponent } from "../../notifications/notifications.component";
import { UpgradeComponent } from "../../upgrade/upgrade.component";
import { UserListComponent } from "../../pages/user-list/user-list.component";
import { UserGuard } from "app/guards/user.guard";
import { PurchaseRequestComponent } from "../../pages/purchase-request/purchase-request.component";
import { PurchaseRequestGuard } from "app/guards/purchase-request.guard";
import { PurchaseRequestCreateComponent } from "../../pages/purchase-request/purchase-request-create/purchase-request-create.component";
import { PurchaseRequestViewComponent } from "../../pages/purchase-request/purchase-request-view/purchase-request-view.component";
import { MainLayoutComponent } from "./main-layout.component";
import { SalesProcessComponent } from "../sales-process/sales-process.component";
import { SalesProcessViewComponent } from "../sales-process/sales-process-view/sales-process-view.component";
import { SalesProcessGuard } from "app/guards/sales-process.guard";

export const MainLayoutRoutes: Routes = [
  // {
  //   path: '',
  //   children: [ {
  //     path: 'dashboard',
  //     component: DashboardComponent
  // }]}, {
  // path: '',
  // children: [ {
  //   path: 'userprofile',
  //   component: UserProfileComponent
  // }]
  // }, {
  //   path: '',
  //   children: [ {
  //     path: 'icons',
  //     component: IconsComponent
  //     }]
  // }, {
  //     path: '',
  //     children: [ {
  //         path: 'notifications',
  //         component: NotificationsComponent
  //     }]
  // }, {
  //     path: '',
  //     children: [ {
  //         path: 'maps',
  //         component: MapsComponent
  //     }]
  // }, {
  //     path: '',
  //     children: [ {
  //         path: 'typography',
  //         component: TypographyComponent
  //     }]
  // }, {
  //     path: '',
  //     children: [ {
  //         path: 'upgrade',
  //         component: UpgradeComponent
  //     }]
  // }
  {
    path: "",
    redirectTo: "dashboard",
    pathMatch: "full",
  },
  {
    path: "",
    component: MainLayoutComponent,
    children: [
      { path: "dashboard", component: DashboardComponent, data: {title: "Dashboard"} },
      { path: "user-list", component: UserListComponent, canActivate: [UserGuard], data: {title: "Lista de Usuarios"} },
      { path: "purchase-request", component: PurchaseRequestComponent, canActivate: [PurchaseRequestGuard], data: {title: "Solicitudes de Compra"} },
      { path: "purchase-request/create", component: PurchaseRequestCreateComponent, canActivate: [PurchaseRequestGuard], data: {title: "Crear Solicitud de Compra"} },
      { path: "purchase-request/view/:id", component: PurchaseRequestViewComponent, canActivate: [PurchaseRequestGuard], data: {title: "Detalle Solicitud de Compra"} },
      { path: "user-profile/:userDataEncoded", component: UserProfileComponent },
      { path: "user-profile", component: UserProfileComponent },
      { path: "sales-process", component: SalesProcessComponent, canActivate: [SalesProcessGuard], data: {title: "Procesos de Venta" }},
      { path: "sales-process/view/:id", component: SalesProcessViewComponent, canActivate: [SalesProcessGuard], data: {title: "Detalle Proceso de Venta"} },

      { path: "typography", component: TypographyComponent },
      { path: "icons", component: IconsComponent },
      { path: "maps", component: MapsComponent },
      { path: "notifications", component: NotificationsComponent },
      { path: "upgrade", component: UpgradeComponent },
    ],
  },
];
