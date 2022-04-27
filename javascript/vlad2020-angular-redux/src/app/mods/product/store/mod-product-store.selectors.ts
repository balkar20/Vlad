// //Author Vlad Balkarov//vlad//

import {createFeatureSelector} from '@ngrx/store';
import {AppModProductStoreState} from './mod-product-store.state';
import {AppModProductStoreStates} from './mod-product-store.states';
import {appModProductStoreConfigFeatureName} from './mod-product-store-config';

/** Мод "Product". Хранилище состояния. Селектор. */
export const appModProductStoreSelector = createFeatureSelector<AppModProductStoreState, AppModProductStoreStates>(
  appModProductStoreConfigFeatureName
);
