// //Author Maxim Kuzmin//makc//

import {Action} from '@ngrx/store';
import {AppModProductPageItemEnumActions} from '../../enums/mod-product-page-item-enum-actions';

/** Мод "Product". Страницы. Элемент. Хранилище состояния. Действия. Очистка. */
export class AppModProductPageItemStoreActionClear implements Action {

  /** @inheritDoc */
  readonly type = AppModProductPageItemEnumActions.Clear;
}
