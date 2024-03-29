// //Author Vlad Balkarov//vlad//

import {NgModule} from '@angular/core';
import {PreloadAllModules, RouterModule, Routes} from '@angular/router';
import {appModsConfigModAuthRoutePath, appModsConfigModDummyMainRoutePath, appModsConfigModProductRoutePath, appModsConfigRoutePath} from '@app/mods/mods-config';

const routes: Routes = [
  {
    path: appModsConfigRoutePath,
    children: [
      {
        path: appModsConfigModDummyMainRoutePath,
        loadChildren: () => import('./mods/dummy-main/mod-dummy-main.module').then(m => m.AppModDummyMainModule)
      },
      {
        path: appModsConfigModProductRoutePath,
        loadChildren: () => import('./mods/product/mod-product.module').then(m => m.AppModProductModule)
      },
      {
        path: appModsConfigModAuthRoutePath,
        loadChildren: () => import('./mods/auth/mod-auth.module').then(m => m.AppModAuthModule)
      }
    ]
  }
];

/** Приложение. Маршрутизация. Модуль. */
@NgModule({
  imports: [
    RouterModule.forRoot(
      routes,
      {
        // enableTracing: true, // <-- debugging purposes only
        onSameUrlNavigation: 'reload',
        preloadingStrategy: PreloadAllModules
      }
    )
  ],
  exports: [RouterModule],
  providers: []
})
export class AppRoutingModule {
}
