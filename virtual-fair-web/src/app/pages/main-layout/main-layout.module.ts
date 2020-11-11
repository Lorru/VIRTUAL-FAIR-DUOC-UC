import { NgModule } from "@angular/core";
import { RouterModule } from "@angular/router";
import { CommonModule } from "@angular/common";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { DashboardComponent } from "../../pages/dashboard/dashboard.component";
import { UserProfileComponent } from "../../pages/user-profile/user-profile.component";
import { TableListComponent } from "../../table-list/table-list.component";
import { TypographyComponent } from "../../typography/typography.component";
import { IconsComponent } from "../../icons/icons.component";
import { MapsComponent } from "../../maps/maps.component";
import { NotificationsComponent } from "../../notifications/notifications.component";
import { UpgradeComponent } from "../../upgrade/upgrade.component";
import { MatButtonModule } from "@angular/material/button";
import { MatInputModule } from "@angular/material/input";
import { MatRippleModule } from "@angular/material/core";
import { MatFormFieldModule } from "@angular/material/form-field";
import { MatTooltipModule } from "@angular/material/tooltip";
import { MatSelectModule } from "@angular/material/select";
import { UserListComponent } from "../../pages/user-list/user-list.component";
import { MatIconModule } from "@angular/material/icon";
import { MatDialogModule } from "@angular/material/dialog";
import { UserRegisterComponent } from "app/pages/user-register/user-register.component";
import { UtilsService } from "app/utils/utils.service";
import { ResultModalComponent } from "app/utils/result-modal/result-modal.component";
import { MatProgressSpinnerModule } from "@angular/material/progress-spinner";
import { MatCheckboxModule } from "@angular/material/checkbox";
import { PurchaseRequestComponent } from "../../pages/purchase-request/purchase-request.component";
import { PurchaseRequestCreateComponent } from "../../pages/purchase-request/purchase-request-create/purchase-request-create.component";
import { PurchaseRequestViewComponent } from "../../pages/purchase-request/purchase-request-view/purchase-request-view.component";
import { RejectDeliveryModalComponent } from "../../pages/purchase-request/purchase-request-view/reject-delivery-modal/reject-delivery-modal.component";
import { MainLayoutRoutes } from "./main-layout.routing";
import { SalesProcessComponent } from "../sales-process/sales-process.component";
import { SalesProcessCreateComponent } from "../sales-process/sales-process-create/sales-process-create.component";
import { SalesProcessViewComponent } from "../sales-process/sales-process-view/sales-process-view.component";

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(MainLayoutRoutes),
    FormsModule,
    ReactiveFormsModule,
    MatButtonModule,
    MatRippleModule,
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule,
    MatTooltipModule,
    MatIconModule,
    MatDialogModule,
    MatProgressSpinnerModule,
    MatCheckboxModule,
  ],
  declarations: [
    DashboardComponent,
    UserProfileComponent,
    TableListComponent,
    TypographyComponent,
    IconsComponent,
    MapsComponent,
    NotificationsComponent,
    UpgradeComponent,
    UserListComponent,
    UserRegisterComponent,
    ResultModalComponent,
    PurchaseRequestComponent,
    PurchaseRequestCreateComponent,
    PurchaseRequestViewComponent,
    RejectDeliveryModalComponent,
    SalesProcessComponent,
    SalesProcessCreateComponent,
    SalesProcessViewComponent
  ],
  providers: [UtilsService],
})
export class MainLayoutModule {}
