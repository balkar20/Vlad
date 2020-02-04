// //Author Maxim Kuzmin//makc//

import {Action} from '@ngrx/store';
import {AppModProductJobListGetInput} from '../../../../jobs/list/get/mod-product-job-list-get-input';
import {AppModProductPageListEnumActions} from '../../enums/mod-product-page-list-enum-actions';

/** Мод "Product". Страницы. Список. Хранилище состояния. Действия. Загрузка. */
export class AppModProductPageListStoreActionLoad implements Action {

  /** @inheritDoc */
  readonly type = AppModProductPageListEnumActions.Load;

  /**
   * Конструктор.
   * @param {AppModProductJobListGetInput} jobListGetInput
   * Ввод задания на получение списка.
   */
  constructor(
    public jobListGetInput: AppModProductJobListGetInput
  ) { }
}
