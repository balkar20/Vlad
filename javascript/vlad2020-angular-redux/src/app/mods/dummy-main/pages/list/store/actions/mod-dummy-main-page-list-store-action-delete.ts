// //Author Vlad Balkarov//vlad//

import {Action} from '@ngrx/store';
import {AppModDummyMainJobItemGetInput} from '../../../../jobs/item/get/mod-dummy-main-job-item-get-input';
import {AppModDummyMainPageListEnumActions} from '../../enums/mod-dummy-main-page-list-enum-actions';

/** Мод "DummyMain". Страницы. Список. Хранилище состояния. Действия. Удаление. */
export class AppModDummyMainPageListStoreActionDelete implements Action {

  /** @inheritDoc */
  readonly type = AppModDummyMainPageListEnumActions.Delete;

  /**
   * Конструктор.
   * @param {AppModDummyMainJobItemGetInput} jobItemGetInput
   * Ввод задания на получение элемента.
   */
  constructor(
    public jobItemGetInput: AppModDummyMainJobItemGetInput
  ) { }
}
