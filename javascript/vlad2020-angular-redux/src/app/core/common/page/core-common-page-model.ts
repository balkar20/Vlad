// //Author Vlad Balkarov//vlad//

import {ActivatedRoute} from '@angular/router';
import {BehaviorSubject, Observable} from 'rxjs';
import {filter, takeUntil} from 'rxjs/operators';
import {AppCoreCommonTitlable} from '@app/core/common/core-common-titlable';
import {AppCoreLoggingState} from '@app/core/logging/core-logging-state';
import {AppCoreLoggingStore} from '@app/core/logging/core-logging-store';
import {AppCoreTitleService} from '@app/core/title/core-title.service';
import {AppHostPartRouteService} from '@app/host/parts/route/host-part-route.service';

/** Ядро. Общее. Страница. Модель. */
export abstract class AppCoreCommonPageModel extends AppCoreCommonTitlable {

  /**
   * Ключ страницы.
   * @type {string} */
  protected pageKey = '';

  /**
   * Событие изменения ключа страницы.
   * @type {string}
   */
  protected pageKeyChanged$ = new BehaviorSubject<string>(this.pageKey);

  /**
   * Конструктор.
   * @param {AppCoreLoggingStore} appLoggerStore Хранилище состояния регистратора.
   * @param {AppHostPartRouteService} appRoute Маршрут.
   * @param {AppCoreTitleService} appTitle Заголовок.
   * @param {ActivatedRoute} extRoute Маршрут.
   */
  protected constructor(
    private appLoggerStore: AppCoreLoggingStore,
    protected appRoute: AppHostPartRouteService,
    appTitle: AppCoreTitleService,
    protected extRoute: ActivatedRoute
  ) {
    super(appTitle);

    this.onGetPageKeyOverAfterViewInit = this.onGetPageKeyOverAfterViewInit.bind(this);
    this.onGetPageKeyOverInit = this.onGetPageKeyOverInit.bind(this);
  }

  /**
   * Получить состояние регистратора.
   * @returns {AppCoreLoggingState} Состояние регистратора.
   */
  getLoggerState(): AppCoreLoggingState {
    return this.appLoggerStore.getState();
  }

  /**
   * Получить поток состояния регистратора.
   * @returns {Observable<AppCoreLoggingState>} Поток состояния регистратора.
   */
  getLoggerState$(): Observable<AppCoreLoggingState> {
    return this.appLoggerStore.getState$(this.unsubscribe$);
  }

  /** Обработчик события после инициализации представления. */
  onAfterViewInit() {
    this.pageKeyChanged$.pipe(
      filter(pageKey => !!pageKey),
      takeUntil(this.unsubscribe$)
    ).subscribe(
      this.onGetPageKeyOverAfterViewInit
    );
  }

  /** Обработчик события инициализации. */
  onInit() {
    this.appRoute.getPageKey$(
      this.extRoute,
      this.unsubscribe$
    ).subscribe(
      this.onGetPageKeyOverInit
    );
  }

  /**
   * Обработчик события получения ключа страницы при инициализации.
   * @param {string} pageKey
   */
  protected onGetPageKeyOverInit(pageKey: string) {
    this.pageKey = pageKey;

    this.pageKeyChanged$.next(pageKey);
  }

  /**
   * Обработчик события получения ключа страницы после инициализации представления.
   * @param {string} pageKey
   */
  protected onGetPageKeyOverAfterViewInit(pageKey: string) {
  }
}
