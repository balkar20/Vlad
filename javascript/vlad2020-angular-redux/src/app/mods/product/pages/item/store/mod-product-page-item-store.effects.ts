// //Author Maxim Kuzmin//makc//

import {Injectable} from '@angular/core';
import {Actions, Effect, ofType} from '@ngrx/effects';
import {Action} from '@ngrx/store';
import {forkJoin, Observable} from 'rxjs';
import {map, switchMap} from 'rxjs/operators';
import {AppCoreLoggingService} from '@app/core/logging/core-logging.service';
import {AppModProductJobItemGetResult} from '../../../jobs/item/get/mod-product-job-item-get-result';
import {AppModProductJobItemGetService} from '../../../jobs/item/get/mod-product-job-item-get.service';
import {AppModProductJobItemInsertService} from '../../../jobs/item/insert/mod-product-job-item-insert.service';
import {AppModProductJobItemUpdateService} from '../../../jobs/item/update/mod-product-job-item-update.service';
import {AppModProductJobOptionsDummyManyToManyGetResult} from '../../../jobs/options/dummy-many-to-many/get/mod-product-job-options-dummy-many-to-many-get-result';
import {AppModProductJobOptionsDummyManyToManyGetService} from '../../../jobs/options/dummy-many-to-many/get/mod-product-job-options-dummy-many-to-many-get.service';
import {AppModProductJobOptionsProductCategoryGetResult} from '../../../jobs/options/product-category/get/mod-product-job-options-product-category-get-result';
import {AppModProductJobOptionsProductCategoryGetService} from '../../../jobs/options/product-category/get/mod-product-job-options-product-category-get.service';
import {AppModProductPageItemEnumActions} from '../enums/mod-product-page-item-enum-actions';
import {AppModProductPageItemStoreActionLoadSuccess} from './actions/mod-product-page-item-store-action-load-success';
import {AppModProductPageItemStoreActionSaveSuccess} from './actions/mod-product-page-item-store-action-save-success';
import {AppModProductPageItemStoreActions} from './mod-product-page-item-store.actions';

/** Мод "Product". Страницы. Вход в систему. Хранилище состояния. Эффекты. */
@Injectable()
export class AppModProductPageItemStoreEffects {

  /**
   * Получение.
   * @returns {Observable<Action>} Поток действий.
   */
  @Effect()
  load$: Observable<Action> = this.extActions$.pipe(
    ofType(AppModProductPageItemEnumActions.Load),
    switchMap(
      action => {
        const results$: Observable<any>[] = [
          this.appJobOptionsDummyManyToManyGet.execute$(this.appLogger),
          this.appJobOptionsDummyOneToManyGet.execute$(this.appLogger)
        ];

        const {
          jobItemGetInput: input
        } = action;

        if (input && input.isForUpdate) {
          results$.push(this.appJobItemGet.execute$(this.appLogger, input));
        }

        return forkJoin(results$).pipe(
          map(
            results => {
              let jobItemGetResult: AppModProductJobItemGetResult;

              if (results.length > 2) {
                jobItemGetResult = results[2] as AppModProductJobItemGetResult;
              }

              return new AppModProductPageItemStoreActionLoadSuccess(
                jobItemGetResult,
                results[0] as AppModProductJobOptionsDummyManyToManyGetResult,
                results[1] as AppModProductJobOptionsProductCategoryGetResult
              );
            }
          )
        );
      }
    )
  );

  /**
   * Сохранение.
   * @returns {Observable<Action>} Поток действий.
   */
  @Effect()
  save$: Observable<Action> = this.extActions$.pipe(
    ofType(AppModProductPageItemEnumActions.Save),
    switchMap(
      action => {
        const {
          jobItemGetOutput: input
        } = action;

        const {
          id
        } = input.objectProduct;

        const result$ = id > 0
          ? this.appJobItemUpdate.execute$(this.appLogger, input)
          : this.appJobItemInsert.execute$(this.appLogger, input);

        return result$.pipe(
          map(
            result =>
              new AppModProductPageItemStoreActionSaveSuccess(result)
          )
        );
      }
    )
  );

  /**
   * Конструктор.
   * @param {AppModProductJobItemGetService} appJobItemGet
   * Задание на получение элемента.
   * @param {AppModProductJobItemInsertService} appJobItemInsert
   * Задание на вставку элемента.
   * @param {AppModProductJobItemUpdateService} appJobItemUpdate
   * Задание на обновление элемента.
   * @param {AppModProductJobOptionsDummyManyToManyGetService} appJobOptionsDummyManyToManyGet
   * Задание на получение вариантов выбора сущности "DummyManyToMany".
   * @param {AppModProductJobOptionsProductCategoryGetService} appJobOptionsDummyOneToManyGet
   * Задание на получение вариантов выбора сущности "DummyOneToMany".
   * @param {AppCoreLoggingService} appLogger Регистратор.
   * @param {Actions<AppModProductPageItemStoreActions>} extActions$ Поток действий.
   */
  constructor(
    private appJobItemGet: AppModProductJobItemGetService,
    private appJobItemInsert: AppModProductJobItemInsertService,
    private appJobItemUpdate: AppModProductJobItemUpdateService,
    private appJobOptionsDummyManyToManyGet: AppModProductJobOptionsDummyManyToManyGetService,
    private appJobOptionsDummyOneToManyGet: AppModProductJobOptionsProductCategoryGetService,
    private appLogger: AppCoreLoggingService,
    private extActions$: Actions<AppModProductPageItemStoreActions>
  ) {
  }
}
