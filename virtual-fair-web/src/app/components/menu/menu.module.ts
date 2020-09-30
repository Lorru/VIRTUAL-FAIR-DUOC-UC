import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

import { MenuRoutingModule } from './menu-routing.module';
import { MenuComponent } from './menu.component';
import { HomeComponent } from '../home/home.component';
import { ReportComponent } from '../report/report.component';
import { UserComponent } from '../user/user.component';
import { TransportAuctionComponent } from '../transport-auction/transport-auction.component';
import { SalesProcessComponent } from '../sales-process/sales-process.component';
import { PurchaseRequestComponent } from '../purchase-request/purchase-request.component';
import { ContractComponent } from '../contract/contract.component';
import { PurchaseRequestModule } from '../purchase-request/purchase-request.module';

@NgModule({
  declarations: [
    MenuComponent,
    HomeComponent,
    SalesProcessComponent,
    TransportAuctionComponent,
    UserComponent,
    ReportComponent,
    ContractComponent
  ],
  exports:[
    MenuComponent,
    HomeComponent,
    PurchaseRequestComponent,
    SalesProcessComponent,
    TransportAuctionComponent,
    UserComponent,
    ReportComponent,
    ContractComponent
  ],
  imports: [
    CommonModule,
    MenuRoutingModule,
    FormsModule,
    PurchaseRequestModule,
    NgbModule.forRoot(),
  ],
  entryComponents:[

  ]
})
export class MenuModule { }
