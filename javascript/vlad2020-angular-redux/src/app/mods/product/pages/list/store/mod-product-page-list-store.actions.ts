// //Author Maxim Kuzmin//makc//

import {AppModProductPageListStoreActionClear} from './actions/mod-product-page-list-store-action-clear';
import {AppModProductPageListStoreActionDelete} from './actions/mod-product-page-list-store-action-delete';
import {AppModProductPageListStoreActionDeleteSuccess} from './actions/mod-product-page-list-store-action-delete-success';
import {AppModProductPageListStoreActionLoad} from './actions/mod-product-page-list-store-action-load';
import {AppModProductPageListStoreActionLoadSuccess} from './actions/mod-product-page-list-store-action-load-success';

/** Мод "Product". Страницы. Список. Хранилище состояния. Действия. */
export type AppModProductPageListStoreActions =
  | AppModProductPageListStoreActionClear
  | AppModProductPageListStoreActionDelete
  | AppModProductPageListStoreActionDeleteSuccess
  | AppModProductPageListStoreActionLoad
  | AppModProductPageListStoreActionLoadSuccess;
