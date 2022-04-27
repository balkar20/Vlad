// //Author Vlad Balkarov//vlad//

import {RouterReducerState} from '@ngrx/router-store';

/** Ядро. Хранилище состояния. Состояние. */
export interface AppCoreStoreState {

  /**
   * Маршрутизатор.
   * @type {RouterReducerState}
   */
  router: RouterReducerState;
}
