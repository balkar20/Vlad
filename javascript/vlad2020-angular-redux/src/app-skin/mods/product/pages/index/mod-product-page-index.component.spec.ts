// //Author Vlad Balkarov//vlad//

import {async, ComponentFixture, TestBed} from '@angular/core/testing';
import {AppSkinModProductPageIndexComponent} from './mod-product-page-index.component';

describe('AppModProductPageIndexComponent', () => {
  let component: AppSkinModProductPageIndexComponent;
  let fixture: ComponentFixture<AppSkinModProductPageIndexComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [AppSkinModProductPageIndexComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AppSkinModProductPageIndexComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
