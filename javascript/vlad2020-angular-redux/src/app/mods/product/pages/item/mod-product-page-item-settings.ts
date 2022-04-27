// //Author Vlad Balkarov//vlad//

import {
  appModProductPageItemConfigKey
} from './mod-product-page-item-config';
import {AppModProductPageItemSettingActions} from './settings/mod-product-page-item-setting-actions';
import {AppModProductPageItemSettingButtons} from './settings/mod-product-page-item-setting-buttons';
import {AppModProductPageItemSettingErrors} from './settings/mod-product-page-item-setting-errors';
import {AppModProductPageItemSettingFields} from './settings/mod-product-page-item-setting-fields';
import {AppModProductPageItemSettingPaths} from '@app/mods/product/pages/item/settings/mod-product-page-item-setting-paths';
import {AppModProductPageItemSettingKeys} from '@app/mods/product/pages/item/settings/mod-product-page-item-setting-keys';

/** Мод "Product". Страницы. Элемент. Настройки. */
export class AppModProductPageItemSettings {

  /**
   * Действия.
   * @type {AppModProductPageItemSettingActions}
   */
  actions = new AppModProductPageItemSettingActions();

  /**
   * Кнопки.
   * @type {AppModProductPageItemSettingButtons}
   */
  buttons = new AppModProductPageItemSettingButtons();

  /**
   * Ошибки.
   * @type {AppModProductPageItemSettingErrors}
   */
  errors = new AppModProductPageItemSettingErrors();

  /**
   * Поля.
   * @type {AppModProductPageItemSettingFields}
   */
  fields = new AppModProductPageItemSettingFields();

  /**
   * Ключ.
   * @type {string}
   */
  get key(): string {
    return appModProductPageItemConfigKey;
  }

  /**
   * Ключи.
   * @type {AppModProductPageItemSettingKeys}
   */
  keys = new AppModProductPageItemSettingKeys();

  /**
   * Пути.
   * @type {AppModProductPageItemSettingPaths}
   */
  paths = new AppModProductPageItemSettingPaths();

  /**
   * Заголовок.
   * @type {string}
   */
  titleResourceKey = 'Элемент';

  /**
   * Заголовок страницы "ModProductPageItemCreate".
   * @type {string}
   */
  titleOfModProductPageItemCreateResourceKey = 'Создать';

  /**
   * Заголовок страницы "ModProductPageItemEdit".
   * @type {string}
   */
  titleOfModProductPageItemEditResourceKey = 'Изменить';

  /**
   * Заголовок страницы "ModProductPageItemView".
   * @type {string}
   */
  titleOfModProductPageItemViewResourceKey = 'Просмотреть';
}
