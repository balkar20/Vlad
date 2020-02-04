import {inject, TestBed} from '@angular/core/testing';

import {AppModProductJobListGetService} from './mod-product-job-list-get.service';

describe('AppModProductJobListGetService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [AppModProductJobListGetService]
    });
  });

  it('should be created', inject([AppModProductJobListGetService], (service: AppModProductJobListGetService) => {
    expect(service).toBeTruthy();
  }));
});
