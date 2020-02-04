// //Author Maxim Kuzmin//makc//

import { Action } from '@ngrx/store';
import { AppModProductPageIndexEnumActions } from '../../enums/mod-product-page-index-enum-actions';

/** Мод "Product". Страницы. Начало. Хранилище состояния. Действия. Очистка. */
export class AppModProductPageIndexStoreActionClear implements Action {

  /** @inheritDoc */
  readonly type = AppModProductPageIndexEnumActions.Clear;
}
