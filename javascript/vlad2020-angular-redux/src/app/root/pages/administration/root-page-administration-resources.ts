// //Author Vlad Balkarov//vlad//

import {BehaviorSubject, Subject} from 'rxjs';
import {takeUntil} from 'rxjs/operators';
import {AppCoreLocalizationService} from '@app/core/localization/core-localization.service';
import {AppRootPageAdministrationSettings} from './root-page-administration-settings';

/** Корень. Страницы. Администрирование. Ресурсы. */
export class AppRootPageAdministrationResources {

  /**
   * Заголовок.
   * @type {string}
   */
  title = '';

  /**
   * Заголовок страницы "ModDummyMainPageIndex".
   * @type {string}
   */
  titleOfModDummyMainPageIndex = '';


  /**
   * Заголовок страницы "ModProductPageIndex".
   * @type {string}
   */
  titleOfModProductPageIndex = '';


  /**
   * Событие, возникающее после перевода заголовка.
   * @type {Subject<string>}
   */
  titleTranslated$ = new BehaviorSubject<string>('');

  /**
   * Конструктор.
   * @param {AppCoreLocalizationService} appLocalizer Локализатор.
   * @param {AppRootPageAdministrationSettings} settings Настройки.
   * @param {Subject<boolean>} unsubscribe$ Отказ от подписки.
   */
  constructor(
    appLocalizer: AppCoreLocalizationService,
    settings: AppRootPageAdministrationSettings,
    unsubscribe$: Subject<boolean>
  ) {
    const {
      titleResourceKey,
      titleOfModDummyMainPageIndexResourceKey, 
      titleOfModProductPageIndexResourceKey
    } = settings;

    appLocalizer.createTranslator(
      titleResourceKey
    ).translate$().pipe(takeUntil(unsubscribe$)).subscribe(s => {
      this.title = s;
      this.titleTranslated$.next(this.title);
    });

    appLocalizer.createTranslator(
      titleOfModDummyMainPageIndexResourceKey
    ).translate$().pipe(takeUntil(unsubscribe$)).subscribe(s => {
      this.titleOfModDummyMainPageIndex = s;
    });
    
    appLocalizer.createTranslator(
      titleOfModProductPageIndexResourceKey
    ).translate$().pipe(takeUntil(unsubscribe$)).subscribe(s => {
      this.titleOfModProductPageIndex = s;
    });
  }
}
