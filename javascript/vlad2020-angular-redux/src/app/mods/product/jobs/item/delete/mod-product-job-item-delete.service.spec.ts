import {inject, TestBed} from '@angular/core/testing';

import {AppModProductJobItemDeleteService} from './mod-product-job-item-delete.service';

describe('AppModProductJobItemDeleteService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [AppModProductJobItemDeleteService]
    });
  });

  it('should be created', inject([AppModProductJobItemDeleteService], (service: AppModProductJobItemDeleteService) => {
    expect(service).toBeTruthy();
  }));
});
