// //Author Vlad Balkarov//vlad//

import {async, ComponentFixture, TestBed} from '@angular/core/testing';
import {AppSkinModProductPageListComponent} from './mod-product-page-list.component';

describe('AppSkinModProductPageListComponent', () => {
  let component: AppSkinModProductPageListComponent;
  let fixture: ComponentFixture<AppSkinModProductPageListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AppSkinModProductPageListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AppSkinModProductPageListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
