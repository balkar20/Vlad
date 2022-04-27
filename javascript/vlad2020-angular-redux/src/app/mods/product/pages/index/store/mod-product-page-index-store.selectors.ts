// //Author Vlad Balkarov//vlad//

import {createSelector} from '@ngrx/store';
import {appModProductStoreSelector} from '@app/mods/product/store/mod-product-store.selectors';

export const appModProductPageIndexStoreSelector = createSelector(
  appModProductStoreSelector,
  state => state.pageIndex
);
