// //Author Maxim Kuzmin//makc//

import {AppModProductPageIndexState} from '../pages/index/mod-product-page-index-state';
import {AppModProductPageItemState} from '../pages/item/mod-product-page-item-state';
import {AppModProductPageListState} from '../pages/list/mod-product-page-list-state';

/** Мод "Product". Хранилище состояния. Состояния. */
export interface AppModProductStoreStates {

  /**
   * Страница. Начало.
   * @type {AppModProductPageIndexState}
   */
  pageIndex: AppModProductPageIndexState;

  /**
   * Страница. Элемент.
   * @type {AppModProductPageItemState}
   */
  pageItem: AppModProductPageItemState;

  /**
   * Страница. Список.
   * @type {AppModProductPageListState}
   */
  pageList: AppModProductPageListState;
}
