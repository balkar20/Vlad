// //Author Maxim Kuzmin//makc//

import {Action} from '@ngrx/store';
import {AppCoreExecutionResultWithData} from '@app/core/execution/core-execution-result-with-data';
import {AppModProductJobListGetOutput} from '../../../../jobs/list/get/mod-product-job-list-get-output';
import {AppModProductPageListEnumActions} from '../../enums/mod-product-page-list-enum-actions';
import {AppModProductJobListGetResult} from '@app/mods/product/jobs/list/get/mod-product-job-list-get-result';

/** Мод "Product". Страницы. Список. Хранилище состояния. Действия. Успех загрузки. */
export class AppModProductPageListStoreActionLoadSuccess implements Action {

  /** @inheritDoc */
  readonly type = AppModProductPageListEnumActions.LoadSuccess;

  /**
   * Конструктор.
   * @param {AppModProductJobListGetResult} jobListGetResult
   * Результат выполнения задания на получение списка.
   */
  constructor(
    public jobListGetResult: AppModProductJobListGetResult
  ) { }
}
