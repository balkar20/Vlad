// //Author Vlad Balkarov//vlad//

import {AppCoreCommonState} from '@app/core/common/core-common-state';
import {AppCoreLocalizationEnumActions} from './enums/core-localization-enum-actions';

/** Хост. Рабочий день. Состояние. */
export class AppCoreLocalizationState extends AppCoreCommonState<AppCoreLocalizationEnumActions> {

  /**
   * Ключ языка.
   * @type {string}
   */
  languageKey: string;
}
