// //Author Maxim Kuzmin//makc//

import {select, Store} from '@ngrx/store';
import {Observable, Subject} from 'rxjs';
import {map, takeUntil} from 'rxjs/operators';
import {AppModProductJobItemGetInput} from '@app/mods/product/jobs/item/get/mod-product-job-item-get-input';
import {AppModProductJobListGetInput} from '@app/mods/product/jobs/list/get/mod-product-job-list-get-input';
import {AppModProductStoreState} from '@app/mods/product/store/mod-product-store.state';
import {AppModProductPageListState} from './mod-product-page-list-state';
import {AppModProductPageListStoreActionClear} from './store/actions/mod-product-page-list-store-action-clear';
import {AppModProductPageListStoreActionDelete} from './store/actions/mod-product-page-list-store-action-delete';
import {AppModProductPageListStoreActionLoad} from './store/actions/mod-product-page-list-store-action-load';
import {appModProductPageListStoreSelector} from './store/mod-product-page-list-store.selectors';

/** Мод "Product". Страницы. Список. Хранилище состояния. */
export class AppModProductPageListStore {

  /** @type {AppModProductPageListState} */
  private state = new AppModProductPageListState();

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
   * @returns {AppModProductPageListState} Состояние.
   */
  getState(): AppModProductPageListState {
    return this.state;
  }

  /**
   * Получить поток состояния.
   * @param {Subject<boolean>} unsubscribe$ Отказ от подписки.
   * @returns {Observable<AppModProductPageListState>} Поток состояния.
   */
  getState$(unsubscribe$: Subject<boolean>): Observable<AppModProductPageListState> {
    return this.extStore.pipe(
      select(appModProductPageListStoreSelector),
      map(this.onStateMap),
      takeUntil(unsubscribe$)
    );
  }

  /** Запустить действие "Очистка". */
  runActionClear() {
    this.extStore.dispatch(new AppModProductPageListStoreActionClear());
  }

  /**
   * Запустить действие "Удаление".
   * @param {AppModProductJobItemGetInput} input Ввод.
   */
  runActionDelete(input: AppModProductJobItemGetInput) {
    this.extStore.dispatch(new AppModProductPageListStoreActionDelete(input));
  }

  /**
   * Запустить действие "Загрузка".
   * @param {AppModProductJobListGetInput} input Ввод.
   */
  runActionLoad(input: AppModProductJobListGetInput) {
    this.extStore.dispatch(new AppModProductPageListStoreActionLoad(input));
  }

  /**
   * @param {AppModProductPageListState} state
   * @returns {AppModProductPageListState}
   */
  private onStateMap(state: AppModProductPageListState): AppModProductPageListState {
    this.state = state;

    return this.state;
  }
}
