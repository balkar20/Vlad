// //Author Maxim Kuzmin//makc//

import {async, ComponentFixture, TestBed} from '@angular/core/testing';
import {AppSkinModProductPageItemComponent} from './mod-product-page-item.component';

describe('AppSkinModProductPageItemComponent', () => {
  let component: AppSkinModProductPageItemComponent;
  let fixture: ComponentFixture<AppSkinModProductPageItemComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AppSkinModProductPageItemComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AppSkinModProductPageItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
