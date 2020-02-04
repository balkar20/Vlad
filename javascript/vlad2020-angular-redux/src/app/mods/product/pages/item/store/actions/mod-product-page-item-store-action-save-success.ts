// //Author Maxim Kuzmin//makc//

import {Action} from '@ngrx/store';
import {AppModProductJobItemGetResult} from '../../../../jobs/item/get/mod-product-job-item-get-result';
import {AppModProductPageItemEnumActions} from '../../enums/mod-product-page-item-enum-actions';

/** Мод "Product". Страницы. Элемент. Хранилище состояния. Действия. Успех сохранения. */
export class AppModProductPageItemStoreActionSaveSuccess implements Action {

  /** @inheritDoc */
  readonly type = AppModProductPageItemEnumActions.SaveSuccess;

  /**
   * Конструктор.
   * @param {AppModProductJobItemGetResult} jobItemGetResult
   * Результат выполнения задания на получение элемента.
   */
  constructor(
    public jobItemGetResult: AppModProductJobItemGetResult
  ) { }
}
