// //Author Vlad Balkarov//vlad//

import {Injectable} from '@angular/core';
import {BehaviorSubject, Observable, Subject} from 'rxjs';
import {takeUntil} from 'rxjs/operators';
import {AppCoreSettings} from '@app/core/core-settings';
import {AppModProductPageListLocation} from './mod-product-page-list-location';
import {AppModProductPageListParameters} from './mod-product-page-list-parameters';
import {AppModProductPageListSettings} from './mod-product-page-list-settings';
import {AppModProductPageItemParameters} from '@app/mods/product/pages/item/mod-product-page-item-parameters';

/** Мод "Product". Страницы. Список. Сервис. */
@Injectable({
  providedIn: 'root'
})
export class AppModProductPageListService {

  /** @type {Subject} */
  private ensureLoadDataRequest$ = new Subject();

  /** @type {AppModProductPageListLocation} */
  private location = new AppModProductPageListLocation();

  /** @type {BehaviorSubject<AppModProductPageListLocation>} */
  private readonly locationChanged$: BehaviorSubject<AppModProductPageListLocation>;

  /**
   * Настройки.
   * @type {AppModProductPageListSettings}
   */
  settings = new AppModProductPageListSettings();

  /**
   * Конструктор.
   * @param {AppCoreSettings} appSettings Настройки.
   */
  constructor(
    private appSettings: AppCoreSettings
  ) {
    this.locationChanged$ = new BehaviorSubject<AppModProductPageListLocation>(this.location);
  }

  /**
   * Создать параметры.
   * @param {number} index Индекс.
   * @returns {AppModProductPageItemParameters} Параметры.
   */
  createParameters(index: string): AppModProductPageListParameters {
    return new AppModProductPageListParameters(this.appSettings, index);
  }

  /**
   * Создать строку запроса.
   * @param {AppModProductPageListParameters} parameters Параметры.
   * @returns {any} Строка запроса.
   */
  createQueryString(parameters: AppModProductPageListParameters): any {
    if (!parameters) {
      parameters = this.createParameters('');
    }

    const result = parameters.createQueryString();

    const {
      paramIsDataRefreshed,
      paramName,
      paramPageNumber,
      paramPageSize,
      paramSelectedItemId,
      paramSortDirection,
      paramSortField
    } = parameters;

    const byDefault = this.createParameters(parameters.index);

    if (paramIsDataRefreshed.isValueDiffer(byDefault.paramIsDataRefreshed.value)) {
      result[paramIsDataRefreshed.name] = paramIsDataRefreshed.value;
    }

    if (paramName.isValueDiffer(byDefault.paramName.value)) {
      result[paramName.name] = paramName.value;
    }

    if (paramPageNumber.isValueDiffer(byDefault.paramPageNumber.value)) {
      result[paramPageNumber.name] = paramPageNumber.value;
    }

    if (paramPageSize.isValueDiffer(byDefault.paramPageSize.value)) {
      result[paramPageSize.name] = paramPageSize.value;
    }

    if (paramSelectedItemId.isValueDiffer(byDefault.paramSelectedItemId.value)) {
      result[paramSelectedItemId.name] = paramSelectedItemId.value;
    }

    if (paramSortDirection.isValueDiffer(byDefault.paramSortDirection.value)) {
      result[paramSortDirection.name] = paramSortDirection.value;
    }

    if (paramSortField.isValueDiffer(byDefault.paramSortField.value)) {
      result[paramSortField.name] = paramSortField.value;
    }

    return result;
  }

  /**
   * Создать ссылку маршрутизатора.
   * @param {AppModProductPageListParameters} parameters Параметры.
   * @returns {any[]} Ссылка маршрутизатора.
   */
  createRouterLink(parameters: AppModProductPageListParameters = null): any[] {
    if (!parameters) {
      const location = this.getLocation();

      parameters = location.parameters;
    }

    const qs = this.createQueryString(parameters);

    return [this.settings.path, qs];
  }

  /**
   * Получить местоположение.
   * @returns {AppModProductPageListLocation} Текущие параметры.
   */
  getLocation(): AppModProductPageListLocation {
    return this.location;
  }

  /**
   * Получить поток местоположений.
   * @param {Subject<boolean>} unsubscribe$ Отказ от подписки.
   * @returns {Observable<AppModProductPageListLocation>} Поток местоположений.
   */
  getLocation$(unsubscribe$: Subject<boolean>): Observable<AppModProductPageListLocation> {
    return this.locationChanged$.pipe(
      takeUntil(unsubscribe$)
    );
  }

  /**
   * Получить поток запросов на обеспечение загрузки данных.
   * @param {Subject<boolean>} unsubscribe$ Отказ от подписки.
   * @returns {Observable<any>} Поток запросов на обеспечение загрузки данных.
   */
  receiveEnsureLoadDataRequest$(unsubscribe$: Subject<boolean>): Observable<any> {
    return this.ensureLoadDataRequest$.pipe(
      takeUntil(unsubscribe$)
    );
  }

  /** Отправить запрос на обеспечение загрузки данных. */
  sendEnsureLoadDataRequest() {
    this.ensureLoadDataRequest$.next();
  }

  /**
   * Установить местоположение.
   * @param {AppModProductPageListLocation} location Местоположение.
   */
  setLocation(location: AppModProductPageListLocation) {
    this.location = location;

    this.locationChanged$.next(this.location);
  }
}
