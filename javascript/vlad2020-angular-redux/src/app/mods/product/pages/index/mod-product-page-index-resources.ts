// //Author Vlad Balkarov//vlad//

import {BehaviorSubject, Subject} from 'rxjs';
import {takeUntil} from 'rxjs/operators';
import {AppCoreLocalizationService} from '@app/core/localization/core-localization.service';
import {AppModProductPageIndexSettings} from './mod-product-page-index-settings';

/** Мод "Product". Страницы. Начало. Ресурсы. */
export class AppModProductPageIndexResources {

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
   * Заголовок страницы "ModProductPageList".
   * @type {string}
   */
  titleOfModProductPageList = '';

  /**
   * Событие, возникающее после перевода заголовка.
   * @type {Subject<string>}
   */
  titleTranslated$ = new BehaviorSubject<string>('');

  /**
   * Конструктор.
   * @param {AppCoreLocalizationService} appLocalizer Локализатор.
   * @param {AppModProductPageIndexSettings} settings Настройки.
   * @param {Subject<boolean>} unsubscribe$ Отказ от подписки.
   */
  constructor(
    appLocalizer: AppCoreLocalizationService,
    settings: AppModProductPageIndexSettings,
    unsubscribe$: Subject<boolean>
  ) {
    const {
      titleResourceKey,
      titleOfModProductPageItemCreateResourceKey,
      titleOfModProductPageItemEditResourceKey,
      titleOfModProductPageItemViewResourceKey,
      titleOfModProductPageListResourceKey
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
    });

    appLocalizer.createTranslator(
      titleOfModProductPageItemEditResourceKey
    ).translate$().pipe(takeUntil(unsubscribe$)).subscribe(s => {
      this.titleOfModProductPageItemEdit = s;
    });

    appLocalizer.createTranslator(
      titleOfModProductPageItemViewResourceKey
    ).translate$().pipe(takeUntil(unsubscribe$)).subscribe(s => {
      this.titleOfModProductPageItemView = s;
    });

    appLocalizer.createTranslator(
      titleOfModProductPageListResourceKey
    ).translate$().pipe(takeUntil(unsubscribe$)).subscribe(s => {
      this.titleOfModProductPageList = s;
    });
  }
}
