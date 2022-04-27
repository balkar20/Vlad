// //Author Vlad Balkarov//vlad//

import {Injectable} from '@angular/core';
import {Actions} from '@ngrx/effects';
import {AppModProductPageIndexStoreActions} from './mod-product-page-index-store.actions';

/** Мод "Product". Страницы. Начало. Хранилище состояния. Эффекты. */
@Injectable()
export class AppModProductPageIndexStoreEffects {

  /**
   * Конструктор.
   * @param {Actions<AppModProductPageIndexStoreActions>} extActions$ Поток действий.
   */
  constructor(
    private extActions$: Actions<AppModProductPageIndexStoreActions>
  ) {
  }
}
