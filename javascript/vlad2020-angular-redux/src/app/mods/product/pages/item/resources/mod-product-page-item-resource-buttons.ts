// //Author Maxim Kuzmin//makc//

import {AppCoreLocalizationService} from '@app/core/localization/core-localization.service';
import {Subject} from 'rxjs';
import {takeUntil} from 'rxjs/operators';
import {AppModProductPageItemSettingButtons} from '../settings/mod-product-page-item-setting-buttons';

/** Мод "Product". Страницы. Элемент. Ресурсы. Кнопки. */
export class AppModProductPageItemResourceButtons {

  /** Кнопка "Отправить". */
  buttonSubmit = {
    title: ''
  };

  /**
   * Конструктор.
   * @param {AppCoreLocalizationService} appLocalizer Локализатор.
   * @param {AppModProductPageItemSettingButtons} settingButtons Настройка кнопок.
   * @param {Subject<boolean>} unsubscribe$ Отказ от подписки.
   */
  constructor(
    appLocalizer: AppCoreLocalizationService,
    settingButtons: AppModProductPageItemSettingButtons,
    unsubscribe$: Subject<boolean>
  ) {
    const {
      buttonSubmit
    } = settingButtons;

    appLocalizer.createTranslator(
      buttonSubmit.titleResourceKey
    ).translate$().pipe(takeUntil(unsubscribe$)).subscribe(s => {
      this.buttonSubmit.title = s;
    });
  }
}
