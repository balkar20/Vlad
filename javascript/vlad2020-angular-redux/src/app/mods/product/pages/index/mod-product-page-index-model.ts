// //Author Vlad Balkarov//vlad//

import {ActivatedRoute} from '@angular/router';
import {Observable} from 'rxjs';
import {AppCoreCommonPageModel} from '@app/core/common/page/core-common-page-model';
import {AppCoreLocalizationService} from '@app/core/localization/core-localization.service';
import {AppCoreLoggingStore} from '@app/core/logging/core-logging-store';
import {AppCoreTitleService} from '@app/core/title/core-title.service';
import {AppHostPartMenuOption} from '@app/host/parts/menu/host-part-menu-option';
import {AppHostPartMenuService} from '@app/host/parts/menu/host-part-menu.service';
import {AppHostPartRouteService} from '@app/host/parts/route/host-part-route.service';
import {AppModProductPageItemService} from '../item/mod-product-page-item.service';
import {AppModProductPageListService} from '../list/mod-product-page-list.service';
import {AppModProductPageIndexResources} from './mod-product-page-index-resources';
import {AppModProductPageIndexService} from './mod-product-page-index.service';
import {AppModProductPageIndexState} from './mod-product-page-index-state';
import {AppModProductPageIndexStore} from './mod-product-page-index-store';

/** Мод "Product". Страницы. Начало. Модель. */
export class AppModProductPageIndexModel extends AppCoreCommonPageModel {

  /**
   * Ресурсы.
   * @type {AppModProductPageIndexResources}
   */
  resources: AppModProductPageIndexResources;

  /**
   * Конструктор.
   * @param {AppCoreLocalizationService} appLocalizer Локализатор.
   * @param {AppCoreLoggingStore} appLoggerStore Хранилище состояния регистратора.
   * @param {AppHostPartMenuService} appMenu Меню.
   * @param {AppModProductPageIndexService} appModProductPageIndex Страница "ModProductPageIndex".
   * @param {AppModProductPageItemService} appModProductPageItem Страница "ModProductPageItem".
   * @param {AppModProductPageListService} appModProductPageList Страница "ModProductPageList".
   * @param {AppHostPartRouteService} appRoute Маршрут.
   * @param {AppModProductPageIndexStore} appStore Хранилище состояния.
   * @param {AppCoreTitleService} appTitle Заголовок.
   * @param {ActivatedRoute} extRoute Маршрут.
   */
  constructor(
    appLocalizer: AppCoreLocalizationService,
    appLoggerStore: AppCoreLoggingStore,
    private appMenu: AppHostPartMenuService,
    private appModProductPageIndex: AppModProductPageIndexService,
    private appModProductPageItem: AppModProductPageItemService,
    private appModProductPageList: AppModProductPageListService,
    appRoute: AppHostPartRouteService,
    private appStore: AppModProductPageIndexStore,
    appTitle: AppCoreTitleService,
    extRoute: ActivatedRoute
  ) {
    super(
      appLoggerStore,
      appRoute,
      appTitle,
      extRoute
    );

    this.resources = new AppModProductPageIndexResources(
      appLocalizer,
      this.appModProductPageIndex.settings,
      this.unsubscribe$
    );
  }

  /**
   * Создать ссылку маршрутизатора на страницу создания элемента.
   * @returns {any[]} Ссылка маршрутизатора.
   */
  createRouterLinkToPageItemCreate(): any[] {
    return [this.appModProductPageItem.settings.paths.pathCreate];
  }

  /**
   * Создать ссылку маршрутизатора на страницу редактирования элемента.
   * @returns {any[]} Ссылка маршрутизатора.
   */
  createRouterLinkToPageItemEdit(): any[] {
    return [this.appModProductPageItem.settings.paths.pathEdit, 1];
  }

  /**
   * Создать ссылку маршрутизатора на страницу просмотра элемента.
   * @returns {any[]} Ссылка маршрутизатора.
   */
  createRouterLinkToPageItemView(): any[] {
    return [this.appModProductPageItem.settings.paths.pathView, 1];
  }

  /**
   * Создать ссылку маршрутизатора на страницу списка.
   * @returns {any[]} Ссылка маршрутизатора.
   */
  createRouterLinkToPageList(): any[] {
    return [this.appModProductPageList.settings.path];
  }

  /**
   * Получить состояние.
   * @returns {AppModProductPageIndexState} Состояние.
   */
  getState(): AppModProductPageIndexState {
    return this.appStore.getState();
  }

  /**
   * Получить поток состояния.
   * @returns {Observable<AppModProductPageIndexState>} Поток состояния.
   */
  getState$(): Observable<AppModProductPageIndexState> {
    return this.appStore.getState$(this.unsubscribe$);
  }

  /** @inheritDoc */
  onDestroy() {
    super.onDestroy();

    this.appStore.runActionClear();
  }

  /** @param {string} pageKey */
  protected onGetPageKeyOverAfterViewInit(pageKey: string) {
    super.onGetPageKeyOverAfterViewInit(pageKey);

    const {
      keyEdit,
      keyView
    } = this.appModProductPageItem.settings.keys;

    const lookupOptionByMenuNodeKey = {
      [keyEdit]: <AppHostPartMenuOption>{
        isNeededToRemove: true
      },
      [keyView]: <AppHostPartMenuOption>{
        isNeededToRemove: true
      }
    };

    this.appMenu.executeActionSet(this.pageKey, lookupOptionByMenuNodeKey);

    this.executeTitleActionItemAdd();
  }

  private executeTitleActionItemAdd() {
    this.appTitle.executeActionItemAdd(
      this.appModProductPageIndex.settings.titleResourceKey,
      this.resources.titleTranslated$,
      this.unsubscribe$
    );

    this.titleItemsCount = 1;
  }
}
