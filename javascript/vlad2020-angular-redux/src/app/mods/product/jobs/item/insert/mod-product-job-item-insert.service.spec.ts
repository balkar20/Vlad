import {inject, TestBed} from '@angular/core/testing';

import {AppModProductJobItemInsertService} from './mod-product-job-item-insert.service';

describe('AppModProductJobItemInsertService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [AppModProductJobItemInsertService]
    });
  });

  it('should be created', inject([AppModProductJobItemInsertService], (service: AppModProductJobItemInsertService) => {
    expect(service).toBeTruthy();
  }));
});
