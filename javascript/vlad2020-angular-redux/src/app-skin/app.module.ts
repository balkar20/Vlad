// //Author Vlad Balkarov//vlad//

import {NgModule} from '@angular/core';
import {appCoreLoggingDiTokenLoggerName} from '@app/core/logging/core-logging-di';
import {AppCoreLoggingService} from '@app/core/logging/core-logging.service';
import {AppSkinComponent} from './app.component';
import {AppSkinBaseModule} from './base/base.module';
import {AppSkinCoreModule} from './core/core.module';
import {AppSkinHostModule} from './host/host.module';
import {AppSkinRootModule} from './root/root.module';

/** Приложение. Модуль. */
@NgModule({
  imports: [
    AppSkinBaseModule.forRoot(),
    AppSkinCoreModule.forRoot(),
    AppSkinHostModule.forRoot(),
    AppSkinRootModule.forRoot()
  ],
  exports: [
    AppSkinComponent
  ],
  declarations: [
    AppSkinComponent
  ],
  providers: [
    {provide: appCoreLoggingDiTokenLoggerName, useValue: AppSkinModule.name},
    AppCoreLoggingService
  ]
})
export class AppSkinModule {
}
