// //Author Maxim Kuzmin//makc//

import {AppModProductPageItemStoreActionClear} from './actions/mod-product-page-item-store-action-clear';
import {AppModProductPageItemStoreActionLoad} from './actions/mod-product-page-item-store-action-load';
import {AppModProductPageItemStoreActionLoadSuccess} from './actions/mod-product-page-item-store-action-load-success';
import {AppModProductPageItemStoreActionSave} from './actions/mod-product-page-item-store-action-save';
import {AppModProductPageItemStoreActionSaveSuccess} from './actions/mod-product-page-item-store-action-save-success';

/** Мод "Product". Страницы. Элемент. Хранилище состояния. Действия. */
export type AppModProductPageItemStoreActions =
  | AppModProductPageItemStoreActionClear
  | AppModProductPageItemStoreActionLoad
  | AppModProductPageItemStoreActionLoadSuccess
  | AppModProductPageItemStoreActionSave
  | AppModProductPageItemStoreActionSaveSuccess;
