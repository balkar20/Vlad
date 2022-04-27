// //Author Vlad Balkarov//vlad//

import {createSelector} from '@ngrx/store';
import {appRootStoreSelector} from '../../../store/root-store.selectors';

export const appRootPageIndexStoreSelector = createSelector(
  appRootStoreSelector,
  state => state.pageIndex
);
