// //Author Vlad Balkarov//vlad//

import {Injectable} from '@angular/core';
import {AppModProductSettings} from './mod-product-settings';

/** Мод "Product". Сервис. */
@Injectable({
  providedIn: 'root'
})
export class AppModProductService {

  /**
   * Настройки.
   * @type {AppModProductSettings}
   */
  settings = new AppModProductSettings();
}
