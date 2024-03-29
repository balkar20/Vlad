// //Author Vlad Balkarov//vlad//

import {createSelector} from '@ngrx/store';
import {appRootStoreSelector} from '../../../store/root-store.selectors';

export const appRootPageSiteStoreSelector = createSelector(
  appRootStoreSelector,
  state => state.pageSite
);
