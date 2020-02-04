import {inject, TestBed} from '@angular/core/testing';
import {AppModProductJobItemUpdateService} from './mod-product-job-item-update.service';

describe('AppModProductJobItemUpdateService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [AppModProductJobItemUpdateService]
    });
  });

  it('should be created', inject([AppModProductJobItemUpdateService], (service: AppModProductJobItemUpdateService) => {
    expect(service).toBeTruthy();
  }));
});
