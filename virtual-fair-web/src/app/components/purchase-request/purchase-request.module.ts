import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { PurchaseRequestRoutingModule } from './purchase-request-routing.module';
import { PurchaseRequestComponent } from './purchase-request.component';
import { PurchaseRequestCreateComponent } from './purchase-request-create/purchase-request-create.component';

@NgModule({
  declarations: [
    PurchaseRequestComponent,
    PurchaseRequestCreateComponent
  ],
  exports:[
    PurchaseRequestComponent,
    PurchaseRequestCreateComponent
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
