// //Author Vlad Balkarov//vlad//

import {
  appModProductPageItemCreateConfigFullPath,
  appModProductPageItemEditConfigFullPath,
  appModProductPageItemViewConfigFullPath
} from '@app/mods/product/pages/item/mod-product-page-item-config';

/** Мод "Product". Страницы. Элемент. Настройки. Пути. */
export class AppModProductPageItemSettingPaths {

  /**
   * Путь страницы "Создание".
   * @type {string}
   */
  get pathCreate(): string {
    return appModProductPageItemCreateConfigFullPath;
  }

  /**
   * Путь страницы "Редактирование".
   * @type {string}
   */
  get pathEdit(): string {
   return appModProductPageItemEditConfigFullPath;
  }

  /**
   * Путь страницы "Просмотр".
   * @type {string}
   */
  get pathView(): string {
    return appModProductPageItemViewConfigFullPath;
  }
}
