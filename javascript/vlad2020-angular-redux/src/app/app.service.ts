// //Author Vlad Balkarov//vlad//

import {Injectable} from '@angular/core';
import {AppSettings} from './app-settings';

/** Приложение. Сервис. */
@Injectable({
  providedIn: 'root'
})
export class AppService {

  /**
   * Настройки.
   * @type {AppSettings}
   */
  settings = new AppSettings();
}
