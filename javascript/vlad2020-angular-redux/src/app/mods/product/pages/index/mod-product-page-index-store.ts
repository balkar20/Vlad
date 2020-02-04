// //Author Maxim Kuzmin//makc//

import {select, Store} from '@ngrx/store';
import {Observable, Subject} from 'rxjs';
import {map, takeUntil} from 'rxjs/operators';
import {AppModProductStoreState} from '@app/mods/product/store/mod-product-store.state';
import {AppModProductPageIndexState} from './mod-product-page-index-state';
import {AppModProductPageIndexStoreActionClear} from './store/actions/mod-product-page-index-store-action-clear';
import {appModProductPageIndexStoreSelector} from './store/mod-product-page-index-store.selectors';

/** Мод "Product". Страницы. Начало. Хранилище состояния. */
export class AppModProductPageIndexStore {

  /** @type {AppModProductPageIndexState} */
  private state = new AppModProductPageIndexState();

  /**
   * Конструктор.
   * @param {Store<AppModProductStoreState>} extStore Хранилище состояния.
   */
  constructor(
    private extStore: Store<AppModProductStoreState>
  ) {
    this.onStateMap = this.onStateMap.bind(this);
  }

  /**
   * Получить состояние.
   * @returns {AppModProductPageIndexState} Состояние.
   */
  getState(): AppModProductPageIndexState {
    return this.state;
  }

  /**
   * Получить поток состояния.
   * @param {Subject<boolean>} unsubscribe$ Отказ от подписки.
   * @returns {Observable<AppModProductPageIndexState>} Поток состояния.
   */
  getState$(unsubscribe$: Subject<boolean>): Observable<AppModProductPageIndexState> {
    return this.extStore.pipe(
      select(appModProductPageIndexStoreSelector),
      map(this.onStateMap),
      takeUntil(unsubscribe$)
    );
  }

  /** Запустить действие "Очистка". */
  runActionClear() {
    this.extStore.dispatch(new AppModProductPageIndexStoreActionClear());
  }

  /**
   * @param {AppModProductPageIndexState} state
   * @returns {AppModProductPageIndexState}
   */
  private onStateMap(state: AppModProductPageIndexState): AppModProductPageIndexState {
    this.state = state;

    return this.state;
  }
}
