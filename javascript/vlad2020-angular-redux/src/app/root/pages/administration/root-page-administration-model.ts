// //Author Vlad Balkarov//vlad//

import {ActivatedRoute} from '@angular/router';
import {Observable} from 'rxjs';
import {AppCoreCommonPageModel} from '@app/core/common/page/core-common-page-model';
import {AppCoreLocalizationService} from '@app/core/localization/core-localization.service';
import {AppCoreLoggingStore} from '@app/core/logging/core-logging-store';
import {AppCoreTitleService} from '@app/core/title/core-title.service';
import {AppHostPartMenuService} from '@app/host/parts/menu/host-part-menu.service';
import {AppHostPartRouteService} from '@app/host/parts/route/host-part-route.service';
import {AppModDummyMainPageIndexService} from '@app/mods/dummy-main/pages/index/mod-dummy-main-page-index.service';
import {AppModProductPageIndexService} from '@app/mods/product/pages/index/mod-product-page-index.service';
import {AppRootPageAdministrationResources} from './root-page-administration-resources';
import {AppRootPageAdministrationService} from './root-page-administration.service';
import {AppRootPageAdministrationState} from './root-page-administration-state';
import {AppRootPageAdministrationStore} from './root-page-administration-store';

/** Корень. Страницы. Администрирование. Модель. */
export class AppRootPageAdministrationModel extends AppCoreCommonPageModel {

  /**
   * Ресурсы.
   * @type {AppRootPageAdministrationResources}
   */
  resources: AppRootPageAdministrationResources;

  /**
   * Конструктор.
   * @param {AppCoreLocalizationService} appLocalizer Локализатор.
   * @param {AppCoreLoggingStore} appLoggerStore Хранилище состояния регистратора.
   * @param {AppHostPartMenuService} appMenu Меню.
   * @param {AppModDummyMainPageIndexService} appModDummyMainPageIndex Страница "ModDummyMainPageIndex".
   * @param {AppRootPageAdministrationService} appRootPageAdministration Страница "RootPageAdministration".
   * @param {AppHostPartRouteService} appRoute Маршрут.
   * @param {AppRootPageAdministrationStore} appStore Хранилище состояния.
   * @param {AppCoreTitleService} appTitle Заголовок.
   * @param {ActivatedRoute} extRoute Маршрут.
   */
  constructor(
    appLocalizer: AppCoreLocalizationService,
    appLoggerStore: AppCoreLoggingStore,
    private appMenu: AppHostPartMenuService,
    private appModDummyMainPageIndex: AppModDummyMainPageIndexService,
    private appModProductPageIndex: AppModProductPageIndexService,
    private appRootPageAdministration: AppRootPageAdministrationService,
    appRoute: AppHostPartRouteService,
    private appStore: AppRootPageAdministrationStore,
    appTitle: AppCoreTitleService,
    extRoute: ActivatedRoute
  ) {
    super(
      appLoggerStore,
      appRoute,
      appTitle,
      extRoute
    );

    this.resources = new AppRootPageAdministrationResources(
      appLocalizer,
      this.appRootPageAdministration.settings,
      this.unsubscribe$
    );
  }

  /**
   * Создать ссылку маршрутизатора на страницу "ModDummyMainPageIndex".
   * @returns {any[]} Ссылка маршрутизатора.
   */
  createRouterLinkToModDummyMainPageIndex(): any[] {
    return [this.appModDummyMainPageIndex.settings.path];
  }

  /**
   * Создать ссылку маршрутизатора на страницу "ModProductPageIndex".
   * @returns {any[]} Ссылка маршрутизатора.
   */
  createRouterLinkToModProductPageIndex(): any[] {
    return [this.appModProductPageIndex.settings.path];
  }

  /**
   * Получить состояние.
   * @returns {AppRootPageAdministrationState} Состояние.
   */
  getState(): AppRootPageAdministrationState {
    return this.appStore.getState();
  }

  /**
   * Получить поток состояния.
   * @returns {Observable<AppRootPageAdministrationState>} Поток состояния.
   */
  getState$(): Observable<AppRootPageAdministrationState> {
    return this.appStore.getState$(this.unsubscribe$);
  }

  /** @inheritDoc */
  onDestroy() {
    super.onDestroy();

    this.appStore.runActionClear();
  }

  /**
   * @inheritDoc
   * @param {string} pageKey
   */
  protected onGetPageKeyOverAfterViewInit(pageKey: string) {
    super.onGetPageKeyOverAfterViewInit(pageKey);

    this.appMenu.executeActionSet(this.pageKey);

    this.executeTitleActionItemAdd();
  }

  private executeTitleActionItemAdd() {
    this.appTitle.executeActionItemAdd(
      this.appRootPageAdministration.settings.titleResourceKey,
      this.resources.titleTranslated$,
      this.unsubscribe$
    );

    this.titleItemsCount = 1;
  }
}
