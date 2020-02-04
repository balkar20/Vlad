// //Author Maxim Kuzmin//makc//

import {AppModProductPageItemEnumActions} from '../enums/mod-product-page-item-enum-actions';
import {AppModProductPageItemState} from '../mod-product-page-item-state';
import {AppModProductPageItemStoreActions} from './mod-product-page-item-store.actions';

/** Мод "Product". Страницы. Вход в систему. Хранилище состояния. Редьюсер. */
export function appModProductPageItemStoreReducer(
  state = new AppModProductPageItemState(),
  action: AppModProductPageItemStoreActions
): AppModProductPageItemState {
  switch (action.type) {
    case AppModProductPageItemEnumActions.Clear:
      return undefined;
    case AppModProductPageItemEnumActions.Load:
      return {
        ...state,
        action: action.type,
        jobItemGetInput: action.jobItemGetInput
      };
    case AppModProductPageItemEnumActions.LoadSuccess:
      return {
        ...state,
        action: action.type,
        jobItemGetResult: action.jobItemGetResult,
        jobOptionsDummyManyToManyGetResult: action.jobOptionsDummyManyToManyGetResult,
        jobOptionsDummyOneToManyGetResult: action.jobOptionsDummyOneToManyGetResult
      };
    case AppModProductPageItemEnumActions.Save:
      return {
        ...state,
        action: action.type,
        jobItemGetOutput: action.jobItemGetOutput
      };
    case AppModProductPageItemEnumActions.SaveSuccess:
      return {
        ...state,
        action: action.type,
        jobItemGetResult: action.jobItemGetResult
      };
    default:
      return state;
  }
}
