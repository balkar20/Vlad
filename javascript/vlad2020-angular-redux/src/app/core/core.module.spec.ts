// //Author Vlad Balkarov//vlad//

import {AppCoreModule} from './core.module';

describe('AppCoreModule', () => {
  let module: AppCoreModule;

  beforeEach(() => {
    module = new AppCoreModule(null);
  });

  it('should create an instance', () => {
    expect(module).toBeTruthy();
  });
});
