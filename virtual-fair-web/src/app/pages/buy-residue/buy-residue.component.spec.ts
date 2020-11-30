import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BuyResidueComponent } from './buy-residue.component';

describe('TableListComponent', () => {
  let component: BuyResidueComponent;
  let fixture: ComponentFixture<BuyResidueComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BuyResidueComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BuyResidueComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
