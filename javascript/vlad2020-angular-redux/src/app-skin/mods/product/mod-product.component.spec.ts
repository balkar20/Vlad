// //Author Vlad Balkarov//vlad//

import {async, TestBed} from '@angular/core/testing';
import {AppSkinModProductComponent} from './mod-product.component';

describe('AppSkinModProductComponent', () => {
  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [
        AppSkinModProductComponent
      ],
    }).compileComponents();
  }));
  it('should create the component', async(() => {
    const fixture = TestBed.createComponent(AppSkinModProductComponent);
    const component = fixture.debugElement.componentInstance;
    expect(component).toBeTruthy();
  }));
  it(`should have as title 'Product'`, async(() => {
    const fixture = TestBed.createComponent(AppSkinModProductComponent);
    const component = fixture.debugElement.componentInstance;
    expect(component.model.title).toEqual('Product');
  }));
  it('should render title in a h2 tag', async(() => {
    const fixture = TestBed.createComponent(AppSkinModProductComponent);
    fixture.detectChanges();
    const compiled = fixture.debugElement.nativeElement;
    expect(compiled.querySelector('h2').textContent).toContain('Product');
  }));
});
