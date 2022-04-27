// //Author Vlad Balkarov//vlad//

import {Injectable} from '@angular/core';
import {AppRootPageSiteSettings} from './root-page-site-settings';

/** Корень. Страницы. Сайт. Сервис. */
@Injectable({
  providedIn: 'root'
})
export class AppRootPageSiteService {

  /**
   * Настройки.
   * @type {AppRootPageSiteSettings}
   */
  settings = new AppRootPageSiteSettings();
}
