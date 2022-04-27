// //Author Vlad Balkarov//vlad//

import {NgModule} from '@angular/core';
import {appCoreLoggingDiTokenLoggerName} from '@app/core/logging/core-logging-di';
import {AppCoreLoggingService} from '@app/core/logging/core-logging.service';
import {AppSkinModProductComponent} from './mod-product.component';
import {AppSkinModProductPageIndexComponent} from './pages/index/mod-product-page-index.component';
import {AppSkinModProductPageItemComponent} from './pages/item/mod-product-page-item.component';
import {AppSkinModProductPageListComponent} from './pages/list/mod-product-page-list.component';
import {AppSkinBaseModule} from '../../base/base.module';
import {AppSkinCoreModule} from '../../core/core.module';
import {AppSkinHostModule} from '../../host/host.module';

/** Мод "Product". Модуль. */
@NgModule({
  imports: [
    AppSkinBaseModule,
    AppSkinCoreModule,
    AppSkinHostModule
  ],
  exports: [
    AppSkinModProductComponent,
    AppSkinModProductPageIndexComponent,
    AppSkinModProductPageItemComponent,
    AppSkinModProductPageListComponent
  ],
  declarations: [
    AppSkinModProductComponent,
    AppSkinModProductPageIndexComponent,
    AppSkinModProductPageItemComponent,
    AppSkinModProductPageListComponent
  ],
  providers: [
    {provide: appCoreLoggingDiTokenLoggerName, useValue: AppSkinModProductModule.name},
    AppCoreLoggingService
  ]
})
export class AppSkinModProductModule {
}
