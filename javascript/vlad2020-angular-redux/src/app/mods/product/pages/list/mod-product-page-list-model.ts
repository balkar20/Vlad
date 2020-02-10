// //Author Maxim Kuzmin//makc//

import {ActivatedRoute, ParamMap, Router} from '@angular/router';
import {merge, Observable, of, Subject, Subscription} from 'rxjs';
import {debounceTime, distinctUntilChanged, filter, switchMap, takeUntil} from 'rxjs/operators';
import {AppCoreCommonPageModel} from '@app/core/common/page/core-common-page-model';
import {AppCoreDialogService} from '@app/core/dialog/core-dialog.service';
import {AppCoreLocalizationService} from '@app/core/localization/core-localization.service';
import {AppCoreLoggingStore} from '@app/core/logging/core-logging-store';
import {AppCoreTitleService} from '@app/core/title/core-title.service';
import {AppCoreSettings} from '@app/core/core-settings';
import {AppHostPartMenuService} from '@app/host/parts/menu/host-part-menu.service';
import {AppHostPartMenuOption} from '@app/host/parts/menu/host-part-menu-option';
import {AppHostPartRouteService} from '@app/host/parts/route/host-part-route.service';
import {AppModProductJobItemGetInput} from '@app/mods/product/jobs/item/get/mod-product-job-item-get-input';
import {AppModProductJobListGetInput} from '@app/mods/product/jobs/list/get/mod-product-job-list-get-input';
import {AppModProductPageItemLocation} from '@app/mods/product/pages/item/mod-product-page-item-location';
import {AppModProductPageItemService} from '../item/mod-product-page-item.service';
import {AppModProductPageListParameters} from './mod-product-page-list-parameters';
import {AppModProductPageListResources} from './mod-product-page-list-resources';
import {AppModProductPageListService} from './mod-product-page-list.service';
import {AppModProductPageListSettingColumns} from './settings/mod-product-page-list-setting-columns';
import {AppModProductPageListState} from './mod-product-page-list-state';
import {AppModProductPageListStore} from './mod-product-page-list-store';

/** Мод "Product". Страницы. Список. Модель. */
export class AppModProductPageListModel extends AppCoreCommonPageModel {

  /** @type {Subject<boolean>} */
  private isDataRefreshed$ = new Subject<boolean>();

  /** @type {Subject<boolean>} */
  private isItemDeleteStarted$ = new Subject<boolean>();

  /** @type {AppModProductJobListGetInput} */
  private jobListGetInput: AppModProductJobListGetInput;

  /** @type {AppModProductPageListParameters} */
  private parameters: AppModProductPageListParameters;

  /**
   * Ресурсы.
   * @type {AppModProductPageListResources}
   */
  resources: AppModProductPageListResources;

  /**
   * Конструктор.
   * @param {AppCoreDialogService} appDialog Диалог.
   * @param {AppCoreLocalizationService} appLocalizer Локализатор.
   * @param {AppCoreLoggingStore} appLoggerStore Хранилище состояния регистратора.
   * @param {AppHostPartMenuService} appMenu Меню.
   * @param {AppModProductPageItemService} appModProductPageItem Страница "ModProductPageItem".
   * @param {AppModProductPageListService} appModProductPageList Страница "ModProductPageList".
   * @param {AppHostPartRouteService} appRoute Маршрут.
   * @param {AppModProductPageListStore} appStore Хранилище состояния.
   * @param {AppCoreSettings} appSettings Настройки.
   * @param {AppCoreTitleService} appTitle Заголовок.
   * @param {ActivatedRoute} extRoute Маршрут.
   * @param {Router} extRouter Маршрутизатор.
   */
  constructor(
    private appDialog: AppCoreDialogService,
    appLocalizer: AppCoreLocalizationService,
    appLoggerStore: AppCoreLoggingStore,
    private appMenu: AppHostPartMenuService,
    private appModProductPageItem: AppModProductPageItemService,
    private appModProductPageList: AppModProductPageListService,
    appRoute: AppHostPartRouteService,
    private appStore: AppModProductPageListStore,
    private appSettings: AppCoreSettings,
    appTitle: AppCoreTitleService,
    extRoute: ActivatedRoute,
    private extRouter: Router
  ) {
    super(
      appLoggerStore,
      appRoute,
      appTitle,
      extRoute
    );

    this.onReceiveEnsureLoadDataRequest = this.onReceiveEnsureLoadDataRequest.bind(this);
    this.onGetJobListGetInput = this.onGetJobListGetInput.bind(this);
    this.onItemLocationFilter = this.onItemLocationFilter.bind(this);
    this.onRouteParamMapSwitchMapToJobListGetInput = this.onRouteParamMapSwitchMapToJobListGetInput.bind(this);

    this.resources = new AppModProductPageListResources(
      appLocalizer,
      appModProductPageList.settings,
      this.unsubscribe$
    );

    this.appModProductPageList.receiveEnsureLoadDataRequest$(
      this.unsubscribe$
    ).subscribe(
      this.onReceiveEnsureLoadDataRequest
    );
  }

  /**
   * Создать параметры.
   * @returns {AppModProductPageListParameters} Параметры.
   */
  createParameters(): AppModProductPageListParameters {
    return this.appModProductPageList.createParameters(this.parameters.index);
  }

    /**
   * Выполнить действие "Элемент. Удаление".
   * @param {number} id Идентификатор.
   */
  executeActionItemDelete(id: number) {
    this.appDialog.confirm$(
      this.resources.actions.actionDelete.confirm
    ).subscribe(isOk => {
      if (isOk) {
        this.isItemDeleteStarted$.next();

        this.appStore.runActionDelete(new AppModProductJobItemGetInput(id));
      }
    });
  }

  /**
   * Выполнить действие "Элемент. Редактирование".
   * @param {number} id Идентификатор.
   */
  executeActionItemEdit(id: number) {
    this.setSelectedItemId(id);

    const {
      pathEdit
    } = this.appModProductPageItem.settings.paths;

    const parameters = this.appModProductPageItem.createParameters(this.parameters.index);

    parameters.paramId.value = id;

    const commands = this.appModProductPageItem.createRouterLink(pathEdit, parameters);

    this.extRouter.navigate(commands).catch();
  }

  /** Выполнить действие "Элемент. Вставка". */
  executeActionItemInsert() {
    const {
      pathCreate
    } = this.appModProductPageItem.settings.paths;

    const commands = this.appModProductPageItem.createRouterLink(pathCreate);

    this.extRouter.navigate(commands).catch();
  }

  /**
   * Выполнить действие "Элемент. Просмотр".
   * @param {number} id Идентификатор.
   */
  executeActionItemView(id: number) {
    this.setSelectedItemId(id);

    const {
      pathView
    } = this.appModProductPageItem.settings.paths;

    const parameters = this.appModProductPageItem.createParameters(this.parameters.index);

    parameters.paramId.value = id;

    const commands = this.appModProductPageItem.createRouterLink(pathView, parameters);

    this.extRouter.navigate(commands).catch();
  }

  /**
   * Выполнить действие "Обновление".
   * @param {AppModProductPageListParameters} parameters Параметры.
   */
  executeActionRefresh(parameters: AppModProductPageListParameters) {
    if (parameters) {
      const location = this.appModProductPageList.getLocation();

      location.parameters = parameters;

      this.appModProductPageList.setLocation(location);
    }

    let commands: any[];

    switch (this.pageKey) {
      case this.appModProductPageItem.settings.key: {
        const itemLocation = this.appModProductPageItem.getLocation();

        itemLocation.pageKey = this.pageKey;

        this.appModProductPageItem.setLocation(itemLocation);

        commands = this.appModProductPageItem.createRouterLink();
      }
        break;
      case this.appModProductPageList.settings.key:
        commands = this.appModProductPageList.createRouterLink(parameters);
        break;
    }

    if (commands) {
      this.extRouter.navigate(commands).catch();
    }
  }

  getIsDataRefreshed$(): Observable<boolean> {
    return this.isDataRefreshed$.pipe(
      takeUntil(this.unsubscribe$)
    );
  }

  getIsItemDeleteStarted$(): Observable<boolean> {
    return this.isItemDeleteStarted$.pipe(
      takeUntil(this.unsubscribe$)
    );
  }

  getParameters(): AppModProductPageListParameters {
    return this.appModProductPageList.getLocation().parameters;
  }

  /**
   * Получить действительный номер страницы.
   * @param {?number} value Значение.
   * @returns {number} Номер страницы.
   */
  getRealPageNumber(value?: number): number {
    return value > 0 ? value : this.parameters.paramPageNumber.value;
  }

  /**
   * Получить действительный размер страницы.
   * @param {?number} value Значение.
   * @returns {number} Размер страницы.
   */
  getRealPageSize(value?: number): number {
    return value > 0 ? value : this.parameters.paramPageSize.value;
  }

  /**
   * Получить действительный идентификатор выбранного элемента.
   * @param {?number} value Значение.
   * @returns {number} Идентификатор выбранного элемента.
   */
  getRealSelectedItemId(value?: number): number {
    return value > 0 ? value : this.parameters.paramSelectedItemId.value;
  }

  /**
   * Получить действительное направление сортировки.
   * @param {?number} value Значение.
   * @returns {number} Направление сортировки.
   */
  getRealSortDirection(value?: string): string {
    return value ? value : this.parameters.paramSortDirection.value;
  }

  /**
   * Получить действительное поле сортировки.
   * @param {?number} value Значение.
   * @returns {number} Поле сортировки.
   */
  getRealSortField(value?: string): string {
    return value ? value : this.parameters.paramSortField.value;
  }

  /**
   * Получить настройку колонок.
   * @returns {AppModProductPageListSettingColumns} Настройка колонок.
   */
  getSettingColumns(): AppModProductPageListSettingColumns {
    return this.appModProductPageList.settings.columns;
  }

  /**
   * Получить настройку вариантов размеров страницы.
   * @returns {number[]} Настройка вариантов размеров страницы.
   */
  getSettingPageSizeOptions(): number[] {
    return this.appSettings.pageSizeOptions;
  }

  /**
   * Получить состояние.
   * @returns {AppModProductPageListState} Состояние.
   */
  getState(): AppModProductPageListState {
    return this.appStore.getState();
  }

  /**
   * Получить поток состояния.
   * @returns {Observable<AppModProductPageListState>} Поток состояния.
   */
  getState$(): Observable<AppModProductPageListState> {
    return this.appStore.getState$(this.unsubscribe$);
  }

  setSelectedItemId(selectedItemId: number) {
    const location = this.appModProductPageList.getLocation();

    const {
      paramSelectedItemId
    } = location.parameters;

    paramSelectedItemId.value = selectedItemId;

    this.appModProductPageList.setLocation(location);
  }

  /**
   * Обработчик события после действия "Элемент. Удаление. Успех".
   * @returns {boolean} Результат обработки.
   */
  onAfterActionItemDeleteSuccess(): boolean {
    if (this.pageKey === this.appModProductPageItem.settings.key) {
      this.setSelectedItemId(0);

      this.onReceiveEnsureLoadDataRequest();

      this.executeActionItemInsert();

      return true;
    }

    return false;
  }

  /** @inheritDoc */
  onDestroy() {
    super.onDestroy();

    this.appStore.runActionClear();
  }

  /** Обработчик события получения запроса на загрузку данных. */
  onReceiveEnsureLoadDataRequest() {
    this.jobListGetInput = null;
  }

  /**
   * Подписаться на событие.
   * @param {Observable<T>} event$ Событие.
   * @param {(T) => void} eventHandler Обработчик события.
   */
  subscribeToEvent<T>(event$: Observable<T>, eventHandler: (T) => void): Subscription {
    return event$.pipe(
      takeUntil(this.unsubscribe$)
    ).subscribe(
      eventHandler
    );
  }

  /**
   * Подписаться на событие, возникшее после задержки со значением, отличающемся от предыдущего.
   * @param {Observable<T>} event$ Событие.
   * @param {(T) => void} eventHandler Обработчик события.
   */
  subscribeToEventDelayedDistinct<T>(
    event$: Observable<T>,
    eventHandler: (T) => void
  ): Subscription {
    const {
      searchDelayMilliseconds
    } = this.appSettings;

    return this.subscribeToEvent(
      event$.pipe(
        debounceTime(searchDelayMilliseconds),
        distinctUntilChanged()
      ),
      eventHandler
    );
  }

  /** @param {string} pageKey */
  protected onGetPageKeyOverInit(pageKey: string) {
    super.onGetPageKeyOverInit(pageKey);

    const {
      index
    } = this.appModProductPageList.settings;

    this.parameters = this.appModProductPageList.createParameters(index);
  }

  /** @param {string} pageKey */
  protected onGetPageKeyOverAfterViewInit(pageKey: string) {
    super.onGetPageKeyOverAfterViewInit(pageKey);

    merge(
      this.extRoute.paramMap.pipe(
        takeUntil(this.unsubscribe$),
        switchMap(this.onRouteParamMapSwitchMapToJobListGetInput)
      ),
      this.appModProductPageItem.getLocation$(this.unsubscribe$).pipe(
        filter(this.onItemLocationFilter),
        switchMap(location => of(location.paramMap)),
        switchMap(this.onRouteParamMapSwitchMapToJobListGetInput)
      )
    ).pipe(
      filter(input => !!input)
    ).subscribe(
      this.onGetJobListGetInput
    );
  }

  private executeTitleActionItemAdd() {
    if (this.titleItemsCount === 0) {
      this.appTitle.executeActionItemAdd(
        this.appModProductPageList.settings.titleResourceKey,
        this.resources.titleTranslated$,
        this.unsubscribe$
      );

      this.titleItemsCount = 1;
    }
  }

  /** @param {AppModProductJobListGetInput} input */
  private onGetJobListGetInput(input: AppModProductJobListGetInput) {
    if (this.pageKey === this.appModProductPageList.settings.key) {
      const {
        keyCreate,
        keyEdit,
        keyView
      } = this.appModProductPageItem.settings.keys;

      const {
        pathCreate
      } = this.appModProductPageItem.settings.paths;

      const lookupOptionByMenuNodeKey = {
        [keyCreate]: <AppHostPartMenuOption>{
          routerLink: this.appModProductPageItem.createRouterLink(pathCreate)
        },
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

    this.appStore.runActionLoad(input);
  }

  /**
   * @param {AppModProductPageItemLocation} location
   * @returns {boolean}
   */
  private onItemLocationFilter(location: AppModProductPageItemLocation): boolean {
    const {
      key
    } = this.appModProductPageItem.settings;

    return this.pageKey === key && this.pageKey !== location.pageKey && !!location.paramMap;
  }

  private onRouteParamMapSwitchMapToJobListGetInput(paramMap: ParamMap): Observable<AppModProductJobListGetInput> {
    const parameters = this.createParameters();
    const {
      paramPageNumber,
      paramPageSize,
      paramSelectedItemId,
      paramSortDirection,
      paramSortField,
      paramObjectProductCategoryName,
      paramObjectProductCategoryId,
      paramObjectProductCategoryIdsString,
      paramName,
      paramIdsString,
      paramIsDataRefreshed
    } = parameters;

    paramIdsString.value = paramMap.get(paramIdsString.name);
    paramName.value = paramMap.get(paramName.name);
    paramPageNumber.value = this.getRealPageNumber(+paramMap.get(paramPageNumber.name));
    paramPageSize.value = this.getRealPageSize(+paramMap.get(paramPageSize.name));
    paramSelectedItemId.value = this.getRealSelectedItemId(+paramMap.get(paramSelectedItemId.name));
    paramSortField.value = this.getRealSortField(paramMap.get(paramSortField.name));
    paramSortDirection.value = this.getRealSortDirection(paramMap.get(paramSortDirection.name));
    paramObjectProductCategoryName.value = paramMap.get(paramObjectProductCategoryName.name);
    paramObjectProductCategoryId.value = +paramMap.get(paramObjectProductCategoryId.name);
    paramObjectProductCategoryIdsString.value = paramMap.get(paramObjectProductCategoryIdsString.name);

    this.isDataRefreshed$.next(paramMap.get(paramIsDataRefreshed.name) === 'true');

    const location = this.appModProductPageList.getLocation();

    location.path = this.appModProductPageList.settings.path;
    location.parameters = parameters;
    location.paramMap = paramMap;
    location.pageKey = this.pageKey;

    this.appModProductPageList.setLocation(location);

    let input = parameters.createJobListGetInput();

    if (input.equals(this.jobListGetInput)) {
      input = null;
    } else {
      this.jobListGetInput = input;
    }
    return of(input);
  }
}
