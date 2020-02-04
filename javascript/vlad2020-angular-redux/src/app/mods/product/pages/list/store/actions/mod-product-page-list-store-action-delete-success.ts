// //Author Maxim Kuzmin//makc//

import {Action} from '@ngrx/store';
import {AppCoreExecutionResult} from '@app/core/execution/core-execution-result';
import {AppModProductPageListEnumActions} from '../../enums/mod-product-page-list-enum-actions';

/** Мод "Product". Страницы. Список. Хранилище состояния. Действия. Успех удаления. */
export class AppModProductPageListStoreActionDeleteSuccess implements Action {

  /** @inheritDoc */
  readonly type = AppModProductPageListEnumActions.DeleteSuccess;

  /**
   * Конструктор.
   * @param {AppCoreExecutionResult} jobItemDeleteResult
   * Результат выполнения задания на удаление элемента.
   */
  constructor(
    public jobItemDeleteResult: AppCoreExecutionResult
  ) { }
}
