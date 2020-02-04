// //Author Maxim Kuzmin//makc//

import {
  appModProductPageIndexConfigFullPath,
  appModProductPageIndexConfigKey
} from '@app/mods/product/pages/index/mod-product-page-index-config';
import {
  appModProductPageItemCreateConfigTitleResourceKey,
  appModProductPageItemEditConfigTitleResourceKey,
  appModProductPageItemViewConfigTitleResourceKey
} from '@app/mods/product/pages/item/mod-product-page-item-config';
import {appModProductPageListConfigTitleResourceKey} from '@app/mods/product/pages/list/mod-product-page-list-config';

/** Мод "Product". Страницы. Начало. Настройки. */
export class AppModProductPageIndexSettings {

  /**
   * Заголовок.
   * @type {string}
   */
  titleResourceKey = 'Начало';

  /**
   * Ключ.
   * @type {string}
   */
  get key(): string {
    return appModProductPageIndexConfigKey;
  }

  /**
   * Путь.
   * @type {string}
   */
  get path(): string {
    return appModProductPageIndexConfigFullPath;
  }

  /**
   * Заголовок страницы "ModProductPageItemCreate".
   * @type {string}
   */
  get titleOfModProductPageItemCreateResourceKey(): string {
    return appModProductPageItemCreateConfigTitleResourceKey;
  }

  /**
   * Заголовок страницы "ModProductPageItemEdit".
   * @type {string}
   */
  get titleOfModProductPageItemEditResourceKey(): string {
    return appModProductPageItemEditConfigTitleResourceKey;
  }

  /**
   * Заголовок страницы "ModProductPageItemView".
   * @type {string}
   */
  get titleOfModProductPageItemViewResourceKey(): string {
    return appModProductPageItemViewConfigTitleResourceKey;
  }

  /**
   * Заголовок страницы "ModProductPageList".
   * @type {string}
   */
  get titleOfModProductPageListResourceKey(): string {
    return appModProductPageListConfigTitleResourceKey;
  }
}
