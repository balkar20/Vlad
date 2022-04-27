// //Author Vlad Balkarov//vlad//

import {
  appModProductPageItemConfigKey,
  appModProductPageItemCreateConfigKey,
  appModProductPageItemEditConfigKey,
  appModProductPageItemViewConfigKey
} from '@app/mods/product/pages/item/mod-product-page-item-config';

/** Мод "Product". Страницы. Элемент. Настройки. Ключи. */
export class AppModProductPageItemSettingKeys {

  /**
   * Ключ страницы "Создание".
   * @type {string}
   */
  get keyCreate(): string {
    return appModProductPageItemCreateConfigKey;
  }

  /**
   * Ключ страницы "Редактирование".
   * @type {string}
   */
  get keyEdit(): string {
   return appModProductPageItemEditConfigKey;
  }

  /**
   * Ключ страницы "Просмотр".
   * @type {string}
   */
  get keyView(): string {
    return appModProductPageItemViewConfigKey;
  }
}
