// //Author Vlad Balkarov//vlad//

import {createSelector} from '@ngrx/store';
import {appModProductStoreSelector} from '../../../store/mod-product-store.selectors';

export const appModProductPageListStoreSelector = createSelector(
  appModProductStoreSelector,
  state => state.pageList
);
