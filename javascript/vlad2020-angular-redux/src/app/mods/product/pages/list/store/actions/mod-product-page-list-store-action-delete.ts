// //Author Vlad Balkarov//vlad//

import {Action} from '@ngrx/store';
import {AppModProductJobItemGetInput} from '../../../../jobs/item/get/mod-product-job-item-get-input';
import {AppModProductPageListEnumActions} from '../../enums/mod-product-page-list-enum-actions';

/** Мод "Product". Страницы. Список. Хранилище состояния. Действия. Удаление. */
export class AppModProductPageListStoreActionDelete implements Action {

  /** @inheritDoc */
  readonly type = AppModProductPageListEnumActions.Delete;

  /**
   * Конструктор.
   * @param {AppModProductJobItemGetInput} jobItemGetInput
   * Ввод задания на получение элемента.
   */
  constructor(
    public jobItemGetInput: AppModProductJobItemGetInput
  ) { }
}
