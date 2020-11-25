import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SalesProcessProdWinnersComponent } from './sales-process-prod-winners.component';

describe('SalesProcessProdWinnersComponent', () => {
  let component: SalesProcessProdWinnersComponent;
  let fixture: ComponentFixture<SalesProcessProdWinnersComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SalesProcessProdWinnersComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SalesProcessProdWinnersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
