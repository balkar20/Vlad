// //Author Vlad Balkarov//vlad//

import {AppModProductPageIndexEnumActions} from '../enums/mod-product-page-index-enum-actions';
import {AppModProductPageIndexState} from '../mod-product-page-index-state';
import {AppModProductPageIndexStoreActions} from './mod-product-page-index-store.actions';

/** Мод "Product". Страницы. Начало. Хранилище состояния. Редьюсер. */
export function appModProductPageIndexStoreReducer(
  state = new AppModProductPageIndexState(),
  action: AppModProductPageIndexStoreActions
): AppModProductPageIndexState {
  switch (action.type) {
    case AppModProductPageIndexEnumActions.Clear:
      return undefined;
    default:
      return state;
  }
}
