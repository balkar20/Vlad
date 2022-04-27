// //Author Vlad Balkarov//vlad//

import {Subject} from 'rxjs';
import {takeUntil} from 'rxjs/operators';
import {AppCoreLocalizationService} from '@app/core/localization/core-localization.service';
import {AppModProductPageItemSettingActions} from '../settings/mod-product-page-item-setting-actions';

/** Мод "Product". Страницы. Элемнет. Ресурсы. Действия. */
export class AppModProductPageItemResourceActions {

  /** Действие "Деактивировать". */
  actionDeactivate = {
    confirm: ''
  };

  /**
   * Конструктор.
   * @param {AppCoreLocalizationService} appLocalizer Локализатор.
   * @param {AppModProductPageListSettingColumns} settingColumns Настройка столбцов.
   * @param {Subject<boolean>} unsubscribe$ Отказ от подписки.
   */
  constructor(
    appLocalizer: AppCoreLocalizationService,
    settingColumns: AppModProductPageItemSettingActions,
    unsubscribe$: Subject<boolean>
  ) {
    const {
      actionDeactivate
    } = settingColumns;

    appLocalizer.createTranslator(
      actionDeactivate.confirmResourceKey
    ).translate$().pipe(takeUntil(unsubscribe$)).subscribe(s => {
      this.actionDeactivate.confirm = s;
    });
  }
}
