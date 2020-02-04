// //Author Maxim Kuzmin//makc//

import {createSelector} from '@ngrx/store';
import {appModProductStoreSelector} from '../../../store/mod-product-store.selectors';

/** Мод "Product". Страницы. Вход в систему. Хранилище состояния. Селектор. */
export const appModProductPageItemStoreSelector = createSelector(
  appModProductStoreSelector,
  state => state.pageItem
);
