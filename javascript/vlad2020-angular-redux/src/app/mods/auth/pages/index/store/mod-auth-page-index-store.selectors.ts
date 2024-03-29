// //Author Vlad Balkarov//vlad//

import {createSelector} from '@ngrx/store';
import {appModAuthStoreSelector} from '@app/mods/auth/store/mod-auth-store.selectors';

export const appModAuthPageIndexStoreSelector = createSelector(
  appModAuthStoreSelector,
  state => state.pageIndex
);
