// //Author Maxim Kuzmin//makc//

import {Injectable} from '@angular/core';
import {AppModProductPageIndexSettings} from './mod-product-page-index-settings';

/** Мод "Product". Страницы. Начало. Сервис. */
@Injectable({
  providedIn: 'root'
})
export class AppModProductPageIndexService {

  /**
   * Настройки.
   * @type {AppModProductPageIndexSettings}
   */
  settings = new AppModProductPageIndexSettings();
}
