// //Author Vlad Balkarov//vlad//

import {Injectable} from '@angular/core';
import {BehaviorSubject, Observable, Subject} from 'rxjs';
import {takeUntil} from 'rxjs/operators';
import {AppModProductPageListService} from '@app/mods/product/pages/list/mod-product-page-list.service';
import {AppModProductPageItemLocation} from './mod-product-page-item-location';
import {AppModProductPageItemParameters} from './mod-product-page-item-parameters';
import {AppModProductPageItemSettings} from './mod-product-page-item-settings';

/** Мод "Product". Страницы. Элемент. Сервис. */
@Injectable({
  providedIn: 'root'
})
export class AppModProductPageItemService {

  /** @type {AppModProductPageItemLocation} */
  private location = new AppModProductPageItemLocation();

  /** @type {BehaviorSubject<AppModProductPageItemLocation>} */
  private readonly locationChanged$: BehaviorSubject<AppModProductPageItemLocation>;

  /**
   * Настройки.
   * @type {AppModProductPageItemSettings}
   */
  settings = new AppModProductPageItemSettings();

  /**
   * Конструктор.
   * @param {AppModProductPageListService} appModProductPageList Страница "ModProductPageList".
   */
  constructor(
    private appModProductPageList: AppModProductPageListService
  ) {
    this.locationChanged$ = new BehaviorSubject<AppModProductPageItemLocation>(this.location);
  }

  /**
   * Создать параметры.
   * @param {number} index Индекс.
   * @returns {AppModProductPageItemParameters} Параметры.
   */
  createParameters(index: string): AppModProductPageItemParameters {
    return new AppModProductPageItemParameters(index);
  }

  /**
   * Создать строку запроса.
   * @param {AppModProductPageItemParameters} parameters Параметры.
   * @returns {any} Строка запроса.
   */
  createQueryString(parameters: AppModProductPageItemParameters): any {
    if (!parameters) {
      parameters = this.createParameters('');
    }

    return  parameters.createQueryString();
  }

  /**
   * Создать ссылку маршрутизатора.
   * @param {string} path Путь.
   * @param {AppModProductPageItemParameters} parameters Параметры.
   * @returns {any[]} Ссылка маршрутизатора.
   */
  createRouterLink(path: string = null, parameters: AppModProductPageItemParameters = null): any[] {
    if (!path || !parameters) {
      const location = this.getLocation();

      if (!path) {
        path = location.path;
      }

      if (!parameters) {
        parameters = location.parameters;
      }
    }

    let qs = this.createQueryString(parameters);

    const listLocation = this.appModProductPageList.getLocation();

    const listQs = this.appModProductPageList.createQueryString(listLocation.parameters);

    qs = {...qs, ...listQs};

    return path === this.settings.paths.pathCreate
      ? [path, qs]
      : [path, parameters.paramId.value, qs];
  }

  /**
   * Получить местоположение.
   * @returns {AppModProductPageItemLocation} Текущие параметры.
   */
  getLocation(): AppModProductPageItemLocation {
    return this.location;
  }

  /**
   * Получить поток местоположений.
   * @param {Subject<boolean>} unsubscribe$ Отказ от подписки.
   * @returns {Observable<AppModProductPageItemLocation>} Поток местоположений.
   */
  getLocation$(unsubscribe$: Subject<boolean>): Observable<AppModProductPageItemLocation> {
    return this.locationChanged$.pipe(
      takeUntil(unsubscribe$)
    );
  }

  /**
   * Установить местоположение.
   * @param {AppModProductPageItemLocation} location Местоположение.
   */
  setLocation(location: AppModProductPageItemLocation) {
    this.location = location;

    this.locationChanged$.next(this.location);
  }
}
