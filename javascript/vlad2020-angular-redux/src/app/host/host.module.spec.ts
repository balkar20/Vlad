// //Author Vlad Balkarov//vlad//

import {AppHostModule} from './host.module';

describe('AppHostModule', () => {
  let module: AppHostModule;

  beforeEach(() => {
    module = new AppHostModule(null);
  });

  it('should create an instance', () => {
    expect(module).toBeTruthy();
  });
});
