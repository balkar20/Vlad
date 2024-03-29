// //Author Vlad Balkarov//vlad//

import {BehaviorSubject, Subject} from 'rxjs';
import {takeUntil} from 'rxjs/operators';
import {AppCoreLocalizationService} from '@app/core/localization/core-localization.service';
import {AppModDummyMainPageIndexSettings} from './mod-dummy-main-page-index-settings';

/** Мод "DummyMain". Страницы. Начало. Ресурсы. */
export class AppModDummyMainPageIndexResources {

  /**
   * Заголовок.
   * @type {string}
   */
  title = '';

  /**
   * Заголовок страницы "ModDummyMainPageItemCreate".
   * @type {string}
   */
  titleOfModDummyMainPageItemCreate = '';

  /**
   * Заголовок страницы "ModDummyMainPageItemEdit".
   * @type {string}
   */
  titleOfModDummyMainPageItemEdit = '';

  /**
   * Заголовок страницы "ModDummyMainPageItemView".
   * @type {string}
   */
  titleOfModDummyMainPageItemView = '';

  /**
   * Заголовок страницы "ModDummyMainPageList".
   * @type {string}
   */
  titleOfModDummyMainPageList = '';

  /**
   * Событие, возникающее после перевода заголовка.
   * @type {Subject<string>}
   */
  titleTranslated$ = new BehaviorSubject<string>('');

  /**
   * Конструктор.
   * @param {AppCoreLocalizationService} appLocalizer Локализатор.
   * @param {AppModDummyMainPageIndexSettings} settings Настройки.
   * @param {Subject<boolean>} unsubscribe$ Отказ от подписки.
   */
  constructor(
    appLocalizer: AppCoreLocalizationService,
    settings: AppModDummyMainPageIndexSettings,
    unsubscribe$: Subject<boolean>
  ) {
    const {
      titleResourceKey,
      titleOfModDummyMainPageItemCreateResourceKey,
      titleOfModDummyMainPageItemEditResourceKey,
      titleOfModDummyMainPageItemViewResourceKey,
      titleOfModDummyMainPageListResourceKey
    } = settings;

    appLocalizer.createTranslator(
      titleResourceKey
    ).translate$().pipe(takeUntil(unsubscribe$)).subscribe(s => {
      this.title = s;
      this.titleTranslated$.next(this.title);
    });

    appLocalizer.createTranslator(
      titleOfModDummyMainPageItemCreateResourceKey
    ).translate$().pipe(takeUntil(unsubscribe$)).subscribe(s => {
      this.titleOfModDummyMainPageItemCreate = s;
    });

    appLocalizer.createTranslator(
      titleOfModDummyMainPageItemEditResourceKey
    ).translate$().pipe(takeUntil(unsubscribe$)).subscribe(s => {
      this.titleOfModDummyMainPageItemEdit = s;
    });

    appLocalizer.createTranslator(
      titleOfModDummyMainPageItemViewResourceKey
    ).translate$().pipe(takeUntil(unsubscribe$)).subscribe(s => {
      this.titleOfModDummyMainPageItemView = s;
    });

    appLocalizer.createTranslator(
      titleOfModDummyMainPageListResourceKey
    ).translate$().pipe(takeUntil(unsubscribe$)).subscribe(s => {
      this.titleOfModDummyMainPageList = s;
    });
  }
}
