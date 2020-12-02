import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SalesProcessViewComponent } from './sales-process-view.component';

describe('SalesProcessViewComponent', () => {
  let component: SalesProcessViewComponent;
  let fixture: ComponentFixture<SalesProcessViewComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SalesProcessViewComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SalesProcessViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
