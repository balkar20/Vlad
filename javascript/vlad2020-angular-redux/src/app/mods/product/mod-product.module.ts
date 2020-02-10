// //Author Maxim Kuzmin//makc//

import {CommonModule} from '@angular/common';
import {NgModule, Optional, SkipSelf} from '@angular/core';
import {EffectsModule} from '@ngrx/effects';
import {StoreModule} from '@ngrx/store';
import {AppCoreLoggingService} from '@app/core/logging/core-logging.service';
import {appCoreLoggingDiTokenLoggerName} from '@app/core/logging/core-logging-di';
import {AppSkinModProductModule} from '@app-skin/mods/product/mod-product.module';
import {AppModProductRoutingModule} from './mod-product-routing.module';
import {AppModProductPageIndexStoreEffects} from './pages/index/store/mod-product-page-index-store.effects';
import {AppModProductPageItemStoreEffects} from './pages/item/store/mod-product-page-item-store.effects';
import {AppModProductPageListStoreEffects} from './pages/list/store/mod-product-page-list-store.effects';
import {appModProductStoreReducers} from './store/mod-product-store.reducers';
import {appModProductStoreConfigFeatureName} from './store/mod-product-store-config';

/** Мод "Product". Модуль. */
@NgModule({
  imports: [
    CommonModule,
    AppModProductRoutingModule,
    AppSkinModProductModule,
    StoreModule.forFeature(appModProductStoreConfigFeatureName, appModProductStoreReducers),
    EffectsModule.forFeature([
      AppModProductPageIndexStoreEffects,
      AppModProductPageItemStoreEffects,
      AppModProductPageListStoreEffects
    ])
  ],
  declarations: [],
  providers: [
    { provide: appCoreLoggingDiTokenLoggerName, useValue: AppModProductModule.name },
    AppCoreLoggingService
  ]
})
export class AppModProductModule {

  /**
   * Конструктор.
   * @param {AppModProductModule} parentModule Модуль, внедрённый родительским инжектором.
   */
  constructor(
    @Optional() @SkipSelf() parentModule: AppModProductModule
  ) {
    console.log("One ");
    
    if (parentModule) {
      console.log("Two");
      throw new Error(`${AppModProductModule.name} is already loaded.`);
    }
  }
}

