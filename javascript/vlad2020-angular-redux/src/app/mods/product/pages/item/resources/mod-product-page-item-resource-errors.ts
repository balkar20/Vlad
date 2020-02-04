// //Author Maxim Kuzmin//makc//

import {AppCoreLocalizationService} from '@app/core/localization/core-localization.service';
import {Subject} from 'rxjs';
import {takeUntil} from 'rxjs/operators';
import {AppModProductPageItemSettingErrors} from '../settings/mod-product-page-item-setting-errors';

/** Мод "Product". Страницы. Элемент. Ресурсы. Ошибки. */
export class AppModProductPageItemResourceErrors {

  /** Ошибка "Обязательно". */
  errorRequired = {
    message: ''
  };

  /**
   * Конструктор.
   * @param {AppCoreLocalizationService} appLocalizer Локализатор.
   * @param {AppModProductPageItemSettingErrors} settingErrors Настройка ошибок.
   * @param {Subject<boolean>} unsubscribe$ Отказ от подписки.
   */
  constructor(
    appLocalizer: AppCoreLocalizationService,
    settingErrors: AppModProductPageItemSettingErrors,
    unsubscribe$: Subject<boolean>
  ) {
    const {
      errorRequired
    } = settingErrors;

    appLocalizer.createTranslator(
      errorRequired.messageResourceKey
    ).translate$().pipe(takeUntil(unsubscribe$)).subscribe(s => {
      this.errorRequired.message = s;
    });
  }
}
