import {inject, TestBed} from '@angular/core/testing';

import {AppModProductJobItemGetService} from './mod-product-job-item-get.service';

describe('AppModProductJobItemGetService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [AppModProductJobItemGetService]
    });
  });

  it('should be created', inject([AppModProductJobItemGetService], (service: AppModProductJobItemGetService) => {
    expect(service).toBeTruthy();
  }));
});
