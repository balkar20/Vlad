// //Author Vlad Balkarov//vlad//

import {AppModProductPageListResourceColumns} from './resources/mod-product-page-list-resource-columns';
import {AppCoreLocalizationService} from '@app/core/localization/core-localization.service';
import {BehaviorSubject, Subject} from 'rxjs';
import {AppModProductPageListSettings} from './mod-product-page-list-settings';
import {takeUntil} from 'rxjs/operators';
import {AppModProductPageListResourceActions} from './resources/mod-product-page-list-resource-actions';

/** Мод "Product". Страницы. Список. Ресурсы. */
export class AppModProductPageListResources {

  /**
   * Действия.
   * @type {AppModProductPageListResourceActions}
   */
  actions: AppModProductPageListResourceActions;

  /**
   * Столбцы.
   * @type {AppModProductPageListResourceColumns}
   */
  columns: AppModProductPageListResourceColumns;

  /**
   * Заголовок.
   * @type {string}
   */
  title = '';

  /**
   * Событие, возникающее после перевода заголовка.
   * @type {Subject<string>}
   */
  titleTranslated$ = new BehaviorSubject<string>('');

  /**
   * Конструктор.
   * @param {AppCoreLocalizationService} appLocalizer Локализатор.
   * @param {AppModProductPageListSettings} settings Настройки.
   * @param {Subject<boolean>} unsubscribe$ Отказ от подписки.
   */
  constructor(
    appLocalizer: AppCoreLocalizationService,
    settings: AppModProductPageListSettings,
    unsubscribe$: Subject<boolean>
  ) {
    const {
      titleResourceKey
    } = settings;

    appLocalizer.createTranslator(
      titleResourceKey
    ).translate$().pipe(takeUntil(unsubscribe$)).subscribe(s => {
      this.title = s;
      this.titleTranslated$.next(this.title);
    });

    this.actions = new AppModProductPageListResourceActions(
      appLocalizer,
      settings.actions,
      unsubscribe$
    );

    this.columns = new AppModProductPageListResourceColumns(
      appLocalizer,
      settings.columns,
      unsubscribe$
    );
  }
}
