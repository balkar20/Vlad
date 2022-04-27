// //Author Vlad Balkarov//vlad//

import {inject, TestBed} from '@angular/core/testing';
import {AppCoreLocalizationService} from './core-localization.service';

describe('AppCoreLocalizationService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [AppCoreLocalizationService]
    });
  });

  it('should be created', inject([AppCoreLocalizationService], (service: AppCoreLocalizationService) => {
    expect(service).toBeTruthy();
  }));
});
