// //Author Vlad Balkarov//vlad//

import {Action} from '@ngrx/store';
import {AppModProductJobItemGetInput} from '../../../../jobs/item/get/mod-product-job-item-get-input';
import {AppModProductPageItemEnumActions} from '../../enums/mod-product-page-item-enum-actions';

/** Мод "Product". Страницы. Элемент. Хранилище состояния. Действия. Загрузка. */
export class AppModProductPageItemStoreActionLoad implements Action {

  /** @inheritDoc */
  readonly type = AppModProductPageItemEnumActions.Load;

  /**
   * Конструктор.
   * @param {AppModProductJobItemGetInput} jobItemGetInput
   * Ввод задания на получение элемента.
   */
  constructor(
    public jobItemGetInput: AppModProductJobItemGetInput
  ) { }
}
