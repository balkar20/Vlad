// //Author Vlad Balkarov//vlad//

import {Subject} from 'rxjs';
import {takeUntil} from 'rxjs/operators';
import {AppCoreLocalizationService} from '@app/core/localization/core-localization.service';
import {AppModDummyMainPageListSettingColumns} from '../settings/mod-dummy-main-page-list-setting-columns';

/** Мод "DummyMain". Страницы. Список. Ресурсы. Столбцы. */
export class AppModDummyMainPageListResourceColumns {

  /** Столбец "Действие". */
  columnAction = {
    label: ''
  };

  /** Столбец "Идентификатор". */
  columnId = {
    label: '',
    placeholder: ''
  };

  /** Столбец "Имя". */
  columnName = {
    label: '',
    placeholder: ''
  };

  /**
   * Конструктор.
   * @param {AppCoreLocalizationService} appLocalizer Локализатор.
   * @param {AppModDummyMainPageListSettingColumns} settingColumns Настройка столбцов.
   * @param {Subject<boolean>} unsubscribe$ Отказ от подписки.
   */
  constructor(
    appLocalizer: AppCoreLocalizationService,
    settingColumns: AppModDummyMainPageListSettingColumns,
    unsubscribe$: Subject<boolean>
  ) {
    const {
      columnAction,
      columnId,
      columnName
    } = settingColumns;

    appLocalizer.createTranslator(
      columnAction.labelResourceKey
    ).translate$().pipe(takeUntil(unsubscribe$)).subscribe(s => {
      this.columnAction.label = s;
    });

    appLocalizer.createTranslator(
      columnId.labelResourceKey
    ).translate$().pipe(takeUntil(unsubscribe$)).subscribe(s => {
      this.columnId.label = s;
    });

    appLocalizer.createTranslator(
      columnId.placeholderResourceKey
    ).translate$().pipe(takeUntil(unsubscribe$)).subscribe(s => {
      this.columnId.placeholder = s;
    });

    appLocalizer.createTranslator(
      columnName.labelResourceKey
    ).translate$().pipe(takeUntil(unsubscribe$)).subscribe(s => {
      this.columnName.label = s;
    });

    appLocalizer.createTranslator(
      columnName.placeholderResourceKey
    ).translate$().pipe(takeUntil(unsubscribe$)).subscribe(s => {
      this.columnName.placeholder = s;
    });
  }
}
