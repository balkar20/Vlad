// //Author Vlad Balkarov//vlad//

import {Subject} from 'rxjs';
import {takeUntil} from 'rxjs/operators';
import {AppCoreLocalizationService} from '@app/core/localization/core-localization.service';
import {AppModProductPageListSettingActions} from '../settings/mod-product-page-list-setting-actions';

/** Мод "Product". Страницы. Список. Ресурсы. Действия. */
export class AppModProductPageListResourceActions {

  /** Действие "Добавить". */
  actionAdd = {
    title: ''
  };

  /** Действие "Удалить". */
  actionDelete = {
    confirm: '',
    title: ''
  };

  /** Действие "Изменить". */
  actionEdit = {
    title: ''
  };

  /** Действие "Просмотреть". */
  actionView = {
    title: ''
  };

  /**
   * Конструктор.
   * @param {AppCoreLocalizationService} appLocalizer Локализатор.
   * @param {AppModProductPageListSettingActions} settingActions Настройка действий.
   * @param {Subject<boolean>} unsubscribe$ Отказ от подписки.
   */
  constructor(
    appLocalizer: AppCoreLocalizationService,
    settingActions: AppModProductPageListSettingActions,
    unsubscribe$: Subject<boolean>
  ) {
    const {
      actionAdd,
      actionDelete,
      actionEdit,
      actionView
    } = settingActions;

    appLocalizer.createTranslator(
      actionAdd.titleResourceKey
    ).translate$().pipe(takeUntil(unsubscribe$)).subscribe(s => {
      this.actionAdd.title = s;
    });

    appLocalizer.createTranslator(
      actionDelete.confirmResourceKey
    ).translate$().pipe(takeUntil(unsubscribe$)).subscribe(s => {
      this.actionDelete.confirm = s;
    });

    appLocalizer.createTranslator(
      actionDelete.titleResourceKey
    ).translate$().pipe(takeUntil(unsubscribe$)).subscribe(s => {
      this.actionDelete.title = s;
    });

    appLocalizer.createTranslator(
      actionEdit.titleResourceKey
    ).translate$().pipe(takeUntil(unsubscribe$)).subscribe(s => {
      this.actionEdit.title = s;
    });

    appLocalizer.createTranslator(
      actionView.titleResourceKey
    ).translate$().pipe(takeUntil(unsubscribe$)).subscribe(s => {
      this.actionView.title = s;
    });
  }
}
