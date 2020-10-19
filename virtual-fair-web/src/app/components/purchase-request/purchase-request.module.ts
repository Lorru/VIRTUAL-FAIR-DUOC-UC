import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { PurchaseRequestRoutingModule } from './purchase-request-routing.module';
import { PurchaseRequestComponent } from './purchase-request.component';
import { PurchaseRequestCreateComponent } from './purchase-request-create/purchase-request-create.component';
import { PurchaseRequestViewComponent } from './purchase-request-view/purchase-request-view.component';

@NgModule({
  declarations: [
    PurchaseRequestComponent,
    PurchaseRequestCreateComponent,
    PurchaseRequestViewComponent
  ],
  exports:[
    PurchaseRequestComponent,
    PurchaseRequestCreateComponent,
    PurchaseRequestViewComponent
  ],
  imports: [
    CommonModule,
    PurchaseRequestRoutingModule,
    FormsModule,
    NgbModule.forRoot(),
  ],
  entryComponents:[

  ]
})
export class PurchaseRequestModule { }
