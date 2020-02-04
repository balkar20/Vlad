// //Author Maxim Kuzmin//makc//

import {AppCoreLocalizationService} from '@app/core/localization/core-localization.service';
import {BehaviorSubject, Subject} from 'rxjs';
import {takeUntil} from 'rxjs/operators';
import {AppModProductPageItemResourceButtons} from './resources/mod-product-page-item-resource-buttons';
import {AppModProductPageItemResourceErrors} from './resources/mod-product-page-item-resource-errors';
import {AppModProductPageItemResourceFields} from './resources/mod-product-page-item-resource-fields';
import {AppModProductPageItemSettings} from './mod-product-page-item-settings';
import {AppModProductPageItemResourceActions} from './resources/mod-product-page-item-resource-actions';

/** Мод "Product". Страницы. Список. Ресурсы. */
export class AppModProductPageItemResources {

  /**
   * Действия.
   * @type {AppModProductPageItemResourceActions}
   */
  actions: AppModProductPageItemResourceActions;

  /**
   * Кнопки.
   * @type {AppModProductPageItemResourceButtons}
   */
  buttons: AppModProductPageItemResourceButtons;

  /**
   * Ошибки.
   * @type {AppModProductPageItemResourceErrors}
   */
  errors: AppModProductPageItemResourceErrors;

  /**
   * Поля.
   * @type {AppModProductPageItemResourceFields}
   */
  fields: AppModProductPageItemResourceFields;

  /**
   * Заголовок.
   * @type {string}
   */
  title = '';
  /**
   * Заголовок страницы "ModProductPageItemCreate".
   * @type {string}
   */
  titleOfModProductPageItemCreate = '';

  /**
   * Заголовок страницы "ModProductPageItemEdit".
   * @type {string}
   */
  titleOfModProductPageItemEdit = '';

  /**
   * Заголовок страницы "ModProductPageItemView".
   * @type {string}
   */
  titleOfModProductPageItemView = '';

  /**
   * Событие, возникающее после перевода заголовка.
   * @type {Subject<string>}
   */
  titleTranslated$ = new BehaviorSubject<string>('');

  /**
   * Событие, возникающее после перевода заголовка страницы "ModProductPageItemCreate".
   * @type {Subject<string>}
   */
  titleOfModProductPageItemCreateTranslated$ = new BehaviorSubject<string>('');

  /**
   * Событие, возникающее после перевода заголовка страницы "ModProductPageItemEdit".
   * @type {Subject<string>}
   */
  titleOfModProductPageItemEditTranslated$ = new BehaviorSubject<string>('');

  /**
   * Событие, возникающее после перевода заголовка страницы "ModProductPageItemView".
   * @type {Subject<string>}
   */
  titleOfModProductPageItemViewTranslated$ = new BehaviorSubject<string>('');

  /**
   * Конструктор.
   * @param {AppCoreLocalizationService} appLocalizer Локализатор.
   * @param {AppModProductPageItemSettings} settings Настройки.
   * @param {Subject<boolean>} unsubscribe$ Отказ от подписки.
   */
  constructor(
    appLocalizer: AppCoreLocalizationService,
    settings: AppModProductPageItemSettings,
    unsubscribe$: Subject<boolean>
  ) {
    const {
      titleResourceKey,
      titleOfModProductPageItemCreateResourceKey,
      titleOfModProductPageItemEditResourceKey,
      titleOfModProductPageItemViewResourceKey
    } = settings;

    appLocalizer.createTranslator(
      titleResourceKey
    ).translate$().pipe(takeUntil(unsubscribe$)).subscribe(s => {
      this.title = s;
      this.titleTranslated$.next(this.title);
    });

    appLocalizer.createTranslator(
      titleOfModProductPageItemCreateResourceKey
    ).translate$().pipe(takeUntil(unsubscribe$)).subscribe(s => {
      this.titleOfModProductPageItemCreate = s;
      this.titleOfModProductPageItemCreateTranslated$.next(this.titleOfModProductPageItemCreate);
    });

    appLocalizer.createTranslator(
      titleOfModProductPageItemEditResourceKey
    ).translate$().pipe(takeUntil(unsubscribe$)).subscribe(s => {
      this.titleOfModProductPageItemEdit = s;
      this.titleOfModProductPageItemEditTranslated$.next(this.titleOfModProductPageItemEdit);
    });

    appLocalizer.createTranslator(
      titleOfModProductPageItemViewResourceKey
    ).translate$().pipe(takeUntil(unsubscribe$)).subscribe(s => {
      this.titleOfModProductPageItemView = s;
      this.titleOfModProductPageItemViewTranslated$.next(this.titleOfModProductPageItemView);
    });

    this.actions = new AppModProductPageItemResourceActions(
      appLocalizer,
      settings.actions,
      unsubscribe$
    );

    this.buttons = new AppModProductPageItemResourceButtons(
      appLocalizer,
      settings.buttons,
      unsubscribe$
    );

    this.errors = new AppModProductPageItemResourceErrors(
      appLocalizer,
      settings.errors,
      unsubscribe$
    );

    this.fields = new AppModProductPageItemResourceFields(
      appLocalizer,
      settings.fields,
      unsubscribe$
    );
  }
}
