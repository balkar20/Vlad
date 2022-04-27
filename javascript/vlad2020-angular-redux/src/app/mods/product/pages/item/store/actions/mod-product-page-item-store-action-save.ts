// //Author Vlad Balkarov//vlad//

import {Action} from '@ngrx/store';
import {AppModProductJobItemGetOutput} from '../../../../jobs/item/get/mod-product-job-item-get-output';
import {AppModProductPageItemEnumActions} from '../../enums/mod-product-page-item-enum-actions';

/** Мод "Product". Страницы. Элемент. Хранилище состояния. Действия. Сохранение. */
export class AppModProductPageItemStoreActionSave implements Action {

  /** @inheritDoc */
  readonly type = AppModProductPageItemEnumActions.Save;

  /**
   * Конструктор.
   * @param {AppModProductJobItemGetOutput} jobItemGetOutput
   * Выход задания на получение элемента.
   */
  constructor(
    public jobItemGetOutput: AppModProductJobItemGetOutput
  ) { }
}
