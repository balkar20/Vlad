// //Author Vlad Balkarov//vlad//

import {AppHostLayoutMenuStoreActionClear} from './actions/host-layout-menu-store-action-clear';
import {AppHostLayoutMenuStoreActionLoad} from './actions/host-layout-menu-store-action-load';
import {AppHostLayoutMenuStoreActionLoadSuccess} from './actions/host-layout-menu-store-action-load-success';

/** Хост. Разметка. Меню. Хранилище состояния. Действия. */
export type AppHostLayoutMenuStoreActions =
  | AppHostLayoutMenuStoreActionClear
  | AppHostLayoutMenuStoreActionLoad
  | AppHostLayoutMenuStoreActionLoadSuccess;
