// //Author Vlad Balkarov//vlad//

import {ActivatedRoute} from '@angular/router';
import {Observable} from 'rxjs';
import {AppCoreCommonPageModel} from '@app/core/common/page/core-common-page-model';
import {AppCoreLocalizationService} from '@app/core/localization/core-localization.service';
import {AppCoreLocalizationState} from '@app/core/localization/core-localization-state';
import {AppCoreLocalizationStore} from '@app/core/localization/core-localization-store';
import {AppCoreLoggingStore} from '@app/core/logging/core-logging-store';
import {AppCoreTitleService} from '@app/core/title/core-title.service';
import {AppHostPartMenuService} from '@app/host/parts/menu/host-part-menu.service';
import {AppHostPartRouteService} from '@app/host/parts/route/host-part-route.service';
import {AppRootPageContactsResources} from './root-page-contacts-resources';
import {AppRootPageContactsService} from './root-page-contacts.service';
import {AppRootPageContactsState} from './root-page-contacts-state';
import {AppRootPageContactsStore} from './root-page-contacts-store';
import {AppRootPageContactsJobContentLoadInput} from './jobs/content/load/host-layout-footer-job-content-load-input';

/** Корень. Страницы. Контакты. Модель. */
export class AppRootPageContactsModel extends AppCoreCommonPageModel {

  /**
   * Ресурсы.
   * @type {AppRootPageContactsResources}
   */
  resources: AppRootPageContactsResources;

  /**
   * Конструктор.
   * @param {AppCoreLocalizationService} appLocalizer Локализатор.
   * @param {AppCoreLocalizationStore} appLocalizerStore Хранилище состояния локализатора.
   * @param {AppCoreLoggingStore} appLoggerStore Хранилище состояния регистратора.
   * @param {AppHostPartMenuService} appMenu Меню.
   * @param {AppRootPageContactsService} appRootPageContacts Страница "RootPageContacts".
   * @param {AppHostPartRouteService} appRoute Маршрут.
   * @param {AppRootPageContactsStore} appStore Хранилище состояния.
   * @param {AppCoreTitleService} appTitle Заголовок.
   * @param {ActivatedRoute} extRoute Маршрут.
   */
  constructor(
    appLocalizer: AppCoreLocalizationService,
    private appLocalizerStore: AppCoreLocalizationStore,
    appLoggerStore: AppCoreLoggingStore,
    private appMenu: AppHostPartMenuService,
    private appRootPageContacts: AppRootPageContactsService,
    appRoute: AppHostPartRouteService,
    private appStore: AppRootPageContactsStore,
    appTitle: AppCoreTitleService,
    extRoute: ActivatedRoute
  ) {
    super(
      appLoggerStore,
      appRoute,
      appTitle,
      extRoute
    );

    this.onGetLocalizerState = this.onGetLocalizerState.bind(this);

    this.resources = new AppRootPageContactsResources(
      appLocalizer,
      this.appRootPageContacts.settings,
      this.unsubscribe$
    );
  }

  /**
   * Получить состояние.
   * @returns {AppRootPageContactsState} Состояние.
   */
  getState(): AppRootPageContactsState {
    return this.appStore.getState();
  }

  /**
   * Получить поток состояния.
   * @returns {Observable<AppRootPageContactsState>} Поток состояния.
   */
  getState$(): Observable<AppRootPageContactsState> {
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

    this.appLocalizerStore.getState$(
      this.unsubscribe$
    ).subscribe(
      this.onGetLocalizerState
    );
  }

  private executeTitleActionItemAdd() {
    this.appTitle.executeActionItemAdd(
      this.appRootPageContacts.settings.titleResourceKey,
      this.resources.titleTranslated$,
      this.unsubscribe$
    );

    this.titleItemsCount = 1;
  }

  private onGetLocalizerState(localizerState: AppCoreLocalizationState) {
    this.appStore.runActionLoad(
      new AppRootPageContactsJobContentLoadInput(localizerState.languageKey)
    );
  }
}
