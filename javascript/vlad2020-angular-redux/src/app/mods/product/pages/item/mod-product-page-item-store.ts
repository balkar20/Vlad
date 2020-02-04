// //Author Maxim Kuzmin//makc//

import {select, Store} from '@ngrx/store';
import {Observable, Subject} from 'rxjs';
import {map, takeUntil} from 'rxjs/operators';
import {AppModProductJobItemGetInput} from '@app/mods/product/jobs/item/get/mod-product-job-item-get-input';
import {AppModProductJobItemGetOutput} from '@app/mods/product/jobs/item/get/mod-product-job-item-get-output';
import {AppModProductStoreState} from '../../store/mod-product-store.state';
import {AppModProductPageItemState} from './mod-product-page-item-state';
import {appModProductPageItemStoreSelector} from './store/mod-product-page-item-store.selectors';
import {AppModProductPageItemStoreActionClear} from './store/actions/mod-product-page-item-store-action-clear';
import {AppModProductPageItemStoreActionLoad} from './store/actions/mod-product-page-item-store-action-load';
import {AppModProductPageItemStoreActionSave} from './store/actions/mod-product-page-item-store-action-save';

/** Мод "Product". Страницы. Элемент. Хранилище состояния. */
export class AppModProductPageItemStore {

  /** @type {AppModProductPageItemState} */
  private state = new AppModProductPageItemState();

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
   * @returns {AppModProductPageItemState} Состояние.
   */
  getState(): AppModProductPageItemState {
    return this.state;
  }

  /**
   * Получить поток состояния.
   * @param {Subject<boolean>} unsubscribe$ Отказ от подписки.
   * @returns {Observable<AppModProductPageItemState>} Поток состояния.
   */
  getState$(unsubscribe$: Subject<boolean>): Observable<AppModProductPageItemState> {
    return this.extStore.pipe(
      select(appModProductPageItemStoreSelector),
      map(this.onStateMap),
      takeUntil(unsubscribe$)
    );
  }

  /** Запустить действие "Очистка". */
  runActionClear() {
    this.extStore.dispatch(new AppModProductPageItemStoreActionClear());
  }

  /**
   * Запустить действие "Загрузка".
   * @param {AppModProductJobListGetInput} input Ввод.
   */
  runActionLoad(input: AppModProductJobItemGetInput) {
    this.extStore.dispatch(new AppModProductPageItemStoreActionLoad(input));
  }

  /**
   * Запустить действие "Сохранение".
   * @param {AppModProductJobItemGetOutput} input Ввод.
   */
  runActionSave(input: AppModProductJobItemGetOutput) {
    this.extStore.dispatch(new AppModProductPageItemStoreActionSave(input));
  }

  /**
   * @param {AppModProductPageItemState} state
   * @returns {AppModProductPageItemState}
   */
  private onStateMap(state: AppModProductPageItemState): AppModProductPageItemState {
    this.state = state;

    return this.state;
  }
}
