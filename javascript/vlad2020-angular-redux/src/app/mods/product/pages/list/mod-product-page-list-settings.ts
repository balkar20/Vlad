// //Author Maxim Kuzmin//makc//

import {
  appModProductPageListConfigFullPath,
  appModProductPageListConfigIndex,
  appModProductPageListConfigKey
} from './mod-product-page-list-config';
import {AppModProductPageListSettingActions} from './settings/mod-product-page-list-setting-actions';
import {AppModProductPageListSettingColumns} from './settings/mod-product-page-list-setting-columns';

/** Мод "Product". Страницы. Список. Настройки. */
export class AppModProductPageListSettings {

  /**
   * Действия.
   * @type {AppModProductPageListSettingActions}
   */
  actions = new AppModProductPageListSettingActions();

  /**
   * Столбцы.
   * @type {AppModProductPageListSettingColumns}
   */
  columns = new AppModProductPageListSettingColumns();

  /**
   * Заголовок.
   * @type {string}
   */
  titleResourceKey = 'Список';

  /**
   * Индекс.
   * @type {string}
   */
  get index(): string {
    return appModProductPageListConfigIndex;
  }

  /**
   * Ключ.
   * @type {string}
   */
  get key(): string {
    return appModProductPageListConfigKey;
  }

  /**
   * Путь.
   * @type {string}
   */
  get path(): string {
    return appModProductPageListConfigFullPath;
  }
}
