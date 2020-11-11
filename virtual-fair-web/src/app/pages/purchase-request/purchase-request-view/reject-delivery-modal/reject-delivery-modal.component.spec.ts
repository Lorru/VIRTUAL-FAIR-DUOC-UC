import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RejectDeliveryModalComponent } from './reject-delivery-modal.component';

describe('RejectDeliveryModalComponent', () => {
  let component: RejectDeliveryModalComponent;
  let fixture: ComponentFixture<RejectDeliveryModalComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RejectDeliveryModalComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RejectDeliveryModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
