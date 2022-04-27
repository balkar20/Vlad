// //Author Vlad Balkarov//vlad//

import {ActionReducerMap} from '@ngrx/store';
import {appModProductPageIndexStoreReducer} from '../pages/index/store/mod-product-page-index-store.reducer';
import {appModProductPageItemStoreReducer} from '../pages/item/store/mod-product-page-item-store.reducer';
import {appModProductPageListStoreReducer} from '../pages/list/store/mod-product-page-list-store.reducer';
import {AppModProductStoreStates} from './mod-product-store.states';

/** Мод "Product". Хранилище состояния. Редьюсеры. */
export const appModProductStoreReducers: ActionReducerMap<AppModProductStoreStates, any> = {
  pageIndex: appModProductPageIndexStoreReducer,
  pageItem: appModProductPageItemStoreReducer,
  pageList: appModProductPageListStoreReducer
};
