// //Author Maxim Kuzmin//makc//

import {AppModProductPageListEnumActions} from '../enums/mod-product-page-list-enum-actions';
import {AppModProductPageListState} from '../mod-product-page-list-state';
import {AppModProductPageListStoreActions} from './mod-product-page-list-store.actions';

/** Мод "Product". Страницы. Список. Хранилище состояния. Редьюсер. */
export function appModProductPageListStoreReducer(
  state = new AppModProductPageListState(),
  action: AppModProductPageListStoreActions
): AppModProductPageListState {
  switch (action.type) {
    case AppModProductPageListEnumActions.Clear:
      return undefined;
    case AppModProductPageListEnumActions.Delete:
      return {
        ...state,
        action: action.type,
        jobItemGetInput: action.jobItemGetInput
      };
    case AppModProductPageListEnumActions.DeleteSuccess:
      return {
        ...state,
        action: action.type,
        jobItemDeleteResult: action.jobItemDeleteResult
      };
    case AppModProductPageListEnumActions.Load:
      return {
        ...state,
        action: action.type,
        jobListGetInput: action.jobListGetInput
      };
    case AppModProductPageListEnumActions.LoadSuccess:
      return {
        ...state,
        action: action.type,
        jobListGetResult: action.jobListGetResult
      };
    default:
      return state;
  }
}
