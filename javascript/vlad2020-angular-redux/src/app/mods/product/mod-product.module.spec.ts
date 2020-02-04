// //Author Maxim Kuzmin//makc//

import {AppModProductModule} from './mod-product.module';

describe('AppModProductModule', () => {
  let module: AppModProductModule;

  beforeEach(() => {
    module = new AppModProductModule(null);
  });

  it('should create an instance', () => {
    expect(module).toBeTruthy();
  });
});
