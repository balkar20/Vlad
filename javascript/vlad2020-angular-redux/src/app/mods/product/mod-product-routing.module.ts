// //Author Maxim Kuzmin//makc//

import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {AppCoreDeactivatingGuard} from '@app/core/deactivating/core-deactivating.guard';
import {AppHostPartAuthGuard} from '@app/host/parts/auth/host-part-auth.guard';
import {AppSkinModProductComponent} from '@app-skin/mods/product/mod-product.component';
import {AppSkinModProductPageIndexComponent} from '@app-skin/mods/product/pages/index/mod-product-page-index.component';
import {AppSkinModProductPageItemComponent} from '@app-skin/mods/product/pages/item/mod-product-page-item.component';
import {AppSkinModProductPageListComponent} from '@app-skin/mods/product/pages/list/mod-product-page-list.component';
import {appModProductConfigRoutePath} from '@app/mods/product/mod-product-config';
import {
  appModProductPageIndexConfigKey,
  appModProductPageIndexConfigRoutePath
} from '@app/mods/product/pages/index/mod-product-page-index-config';
import {
  appModProductPageItemConfigRoutePath,
  appModProductPageItemCreateConfigKey,
  appModProductPageItemCreateConfigRoutePath,
  appModProductPageItemEditConfigKey,
  appModProductPageItemEditConfigRoutePath,
  appModProductPageItemViewConfigKey,
  appModProductPageItemViewConfigRoutePath
} from './pages/item/mod-product-page-item-config';
import {appModProductPageListConfigKey, appModProductPageListConfigRoutePath} from './pages/list/mod-product-page-list-config';

const routes: Routes = [
  {
    children: [
      {
        canActivateChild: [AppHostPartAuthGuard],
        children: [
          {
            children: [
              {
                canDeactivate: [AppCoreDeactivatingGuard],
                component: AppSkinModProductPageItemComponent,
                data: {page: {key: appModProductPageItemCreateConfigKey}},
                path: appModProductPageItemCreateConfigRoutePath
              },
              {
                canDeactivate: [AppCoreDeactivatingGuard],
                component: AppSkinModProductPageItemComponent,
                data: {page: {key: appModProductPageItemEditConfigKey}},
                path: appModProductPageItemEditConfigRoutePath
              },
              {
                component: AppSkinModProductPageItemComponent,
                data: {page: {key: appModProductPageItemViewConfigKey}},
                path: appModProductPageItemViewConfigRoutePath
              }
            ],
            path: appModProductPageItemConfigRoutePath
          },
          {
            component: AppSkinModProductPageListComponent,
            data: {page: {key: appModProductPageListConfigKey}},
            path: appModProductPageListConfigRoutePath
          },
          {
            component: AppSkinModProductPageIndexComponent,
            data: {page: {key: appModProductPageIndexConfigKey}},
            path: appModProductPageIndexConfigRoutePath
          }
        ],
        path: ''
      }
    ],
    component: AppSkinModProductComponent,
    path: appModProductConfigRoutePath
  }
];

/** Мод "Product". Маршрутизация. Модуль. */
@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AppModProductRoutingModule {
}
