// //Author Maxim Kuzmin//makc//

import {AppCoreStoreState} from '@app/core/store/core-store.state';
import {AppModProductStoreStates} from './mod-product-store.states';
import {appModProductStoreConfigFeatureName} from '@app/mods/product/store/mod-product-store-config';

/** Мод "Product". Хранилище состояния. Состояние. */
export interface AppModProductStoreState extends AppCoreStoreState {
  [appModProductStoreConfigFeatureName]: AppModProductStoreStates;
}
