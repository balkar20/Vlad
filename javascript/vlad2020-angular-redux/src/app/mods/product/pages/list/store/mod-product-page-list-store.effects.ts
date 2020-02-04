// //Author Maxim Kuzmin//makc//

import {Injectable} from '@angular/core';
import {Actions, Effect, ofType} from '@ngrx/effects';
import {Action} from '@ngrx/store';
import {Observable} from 'rxjs';
import {map, switchMap} from 'rxjs/operators';
import {AppCoreLoggingService} from '@app/core/logging/core-logging.service';
import {AppModProductJobListGetService} from '../../../jobs/list/get/mod-product-job-list-get.service';
import {AppModProductPageListEnumActions} from '../enums/mod-product-page-list-enum-actions';
import {AppModProductPageListStoreActionLoadSuccess} from './actions/mod-product-page-list-store-action-load-success';
import {AppModProductPageListStoreActions} from './mod-product-page-list-store.actions';
import {AppModProductPageListStoreActionDeleteSuccess} from './actions/mod-product-page-list-store-action-delete-success';
import {AppModProductJobItemDeleteService} from '../../../jobs/item/delete/mod-product-job-item-delete.service';

/** Мод "Product". Страницы. Список. Хранилище состояния. Эффекты. */
@Injectable()
export class AppModProductPageListStoreEffects {

  /**
   * Загрузка.
   * @returns {Observable<Action>} Поток действий.
   */
  @Effect()
  load$: Observable<Action> = this.extActions$.pipe(
    ofType(AppModProductPageListEnumActions.Load),
    switchMap(
      action =>
        this.appJobListGet.execute$(
          this.appLogger,
          action.jobListGetInput
        ).pipe(
          map(
            result =>
              new AppModProductPageListStoreActionLoadSuccess(result)
          )
        )
    )
  );

  /**
   * Удаление.
   * @returns {Observable<Action>} Поток действий.
   */
  @Effect()
  delete$: Observable<Action> = this.extActions$.pipe(
    ofType(AppModProductPageListEnumActions.Delete),
    switchMap(
      action =>
        this.appJobItemDelete.execute$(
          this.appLogger,
          action.jobItemGetInput
        ).pipe(
          map(
            result =>
              new AppModProductPageListStoreActionDeleteSuccess(result)
          )
        )
    )
  );

  /**
   * Конструктор.
   * @param {AppModProductJobItemDeleteService} appJobItemDelete Задание на удаление элемента.
   * @param {AppModProductJobListGetService} appJobListGet Задание на получение списка.
   * @param {AppCoreLoggingService} appLogger Регистратор.
   * @param {Actions<AppModProductPageListStoreActions>} extActions$ Поток действий.
   */
  constructor(
    protected appJobItemDelete: AppModProductJobItemDeleteService,
    protected appJobListGet: AppModProductJobListGetService,
    private appLogger: AppCoreLoggingService,
    private extActions$: Actions<AppModProductPageListStoreActions>
  ) {
  }
}
