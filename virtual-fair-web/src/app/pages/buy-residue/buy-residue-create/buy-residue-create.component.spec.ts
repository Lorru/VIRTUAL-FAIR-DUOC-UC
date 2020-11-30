import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BuyResidueCreateComponent } from './buy-residue-create.component';

describe('BuyResidueCreateComponent', () => {
  let component: BuyResidueCreateComponent;
  let fixture: ComponentFixture<BuyResidueCreateComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BuyResidueCreateComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BuyResidueCreateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
