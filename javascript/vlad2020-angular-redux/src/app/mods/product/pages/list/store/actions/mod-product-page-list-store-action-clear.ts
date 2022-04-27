// //Author Vlad Balkarov//vlad//

import { Action } from '@ngrx/store';
import { AppModProductPageListEnumActions } from '../../enums/mod-product-page-list-enum-actions';

/** Мод "Product". Страницы. Список. Хранилище состояния. Действия. Очистка. */
export class AppModProductPageListStoreActionClear implements Action {

  /** @inheritDoc */
  readonly type = AppModProductPageListEnumActions.Clear;
}
