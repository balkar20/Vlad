// //Author Vlad Balkarov//vlad//

import {FormBuilder} from '@angular/forms';
import {ActivatedRoute, ParamMap, Router} from '@angular/router';
import {Observable, of, Subject} from 'rxjs';
import {filter, switchMap, takeUntil} from 'rxjs/operators';
import {AppCoreCommonPageModel} from '@app/core/common/page/core-common-page-model';
import {AppCoreDialogService} from '@app/core/dialog/core-dialog.service';
import {AppCoreLocalizationService} from '@app/core/localization/core-localization.service';
import {AppCoreNavigationService} from '@app/core/navigation/core-navigation.service';
import {AppCoreTitleService} from '@app/core/title/core-title.service';
import {AppHostPartMenuService} from '@app/host/parts/menu/host-part-menu.service';
import {AppHostPartMenuOption} from '@app/host/parts/menu/host-part-menu-option';
import {AppHostPartRouteService} from '@app/host/parts/route/host-part-route.service';
import {AppModProductJobItemGetInput} from '@app/mods/product/jobs/item/get/mod-product-job-item-get-input';
import {AppModProductJobItemGetOutput} from '@app/mods/product/jobs/item/get/mod-product-job-item-get-output';
import {AppModProductPageListService} from '../list/mod-product-page-list.service';
import {AppModProductPageItemResources} from './mod-product-page-item-resources';
import {AppModProductPageItemSettingErrors} from './settings/mod-product-page-item-setting-errors';
import {AppModProductPageItemSettingFields} from './settings/mod-product-page-item-setting-fields';
import {AppModProductPageItemService} from './mod-product-page-item.service';
import {AppModProductPageItemParameters} from './mod-product-page-item-parameters';
import {AppModProductPageItemState} from './mod-product-page-item-state';
import {AppModProductPageItemStore} from './mod-product-page-item-store';
import {appModProductPageItemConfigIndex} from './mod-product-page-item-config';
import {AppCoreLoggingStore} from '@app/core/logging/core-logging-store';

/** Мод "Product". Страницы. Элемент. Модель. */
export class AppModProductPageItemModel extends AppCoreCommonPageModel {

  /** @type {Subject<boolean>} */
  private isDataChangeAllowedChanged$ = new Subject<boolean>();

  /** @type {AppModProductJobItemGetInput} */
  private jobItemGetInput: AppModProductJobItemGetInput;

  /** @type {AppModProductPageItemParameters} */
  private parameters: AppModProductPageItemParameters;

  /**
   * Ресурсы.
   * @type {AppModProductPageItemResources}
   */
  resources: AppModProductPageItemResources;

  /**
   * Конструктор.
   * @param {AppCoreDialogService} appDialog Диалог.
   * @param {AppCoreLocalizationService} appLocalizer Локализатор.
   * @param {AppCoreLoggingStore} appLoggerStore Хранилище состояния регистратора.
   * @param {AppHostPartMenuService} appMenu Меню.
   * @param {AppModProductPageItemService} appModProductPageItem Страница "ModProductPageItem".
   * @param {AppModProductPageListService} appModProductPageList Страница "ModProductPageList".
   * @param {AppCoreNavigationService} appNavigation Навигация.
   * @param {AppHostPartRouteService} appRoute Маршрут.
   * @param {AppModProductPageItemStore} appStore Хранилище состояния.
   * @param {AppCoreTitleService} appTitle Заголовок.
   * @param {FormBuilder} extFormBuilder Построитель форм.
   * @param {ActivatedRoute} extRoute Маршрут.
   * @param {Router} extRouter Маршрутизатор.
   */
  constructor(
    public appDialog: AppCoreDialogService,
    appLocalizer: AppCoreLocalizationService,
    appLoggerStore: AppCoreLoggingStore,
    private appMenu: AppHostPartMenuService,
    private appModProductPageItem: AppModProductPageItemService,
    private appModProductPageList: AppModProductPageListService,
    private appNavigation: AppCoreNavigationService,
    appRoute: AppHostPartRouteService,
    private appStore: AppModProductPageItemStore,
    appTitle: AppCoreTitleService,
    public extFormBuilder: FormBuilder,
    extRoute: ActivatedRoute,
    private extRouter: Router
  ) {
    super(
      appLoggerStore,
      appRoute,
      appTitle,
      extRoute
    );

    this.onGetJobItemGetInput = this.onGetJobItemGetInput.bind(this);
    this.onRouteParamMapSwitchMapToJobItemGetInput = this.onRouteParamMapSwitchMapToJobItemGetInput.bind(this);

    this.resources = new AppModProductPageItemResources(
      appLocalizer,
      this.appModProductPageItem.settings,
      this.unsubscribe$
    );
  }

  /**
   * Создать параметры.
   * @returns {AppModProductPageItemParameters} Параметры.
   */
  createParameters(): AppModProductPageItemParameters {
    return this.appModProductPageItem.createParameters(this.parameters.index);
  }

  /**
   * Получить поток признаков того, что изменение данных разрешено.
   * @returns {Observable<boolean>} Поток признаков того, что изменение данных разрешено.
   */
  getIsDataChangeAllowed$(): Observable<boolean> {
    return this.isDataChangeAllowedChanged$.pipe(
      takeUntil(this.unsubscribe$)
    );
  }

  /**
   * Получить настройку ошибок.
   * @returns {AppModProductPageItemSettingErrors} Настройка ошибок.
   */
  getSettingErrors(): AppModProductPageItemSettingErrors {
    return this.appModProductPageItem.settings.errors;
  }

  /**
   * Получить настройку полей.
   * @returns {AppModProductPageItemSettingFields} Настройка полей.
   */
  getSettingFields(): AppModProductPageItemSettingFields {
    return this.appModProductPageItem.settings.fields;
  }

  /**
   * Получить состояние.
   * @returns {AppModProductPageItemState} Состояние.
   */
  getState(): AppModProductPageItemState {
    return this.appStore.getState();
  }

  /**
   * Получить поток состояния.
   * @returns {Observable<AppModProductPageItemState>} Поток состояния.
   */
  getState$(): Observable<AppModProductPageItemState> {
    return this.appStore.getState$(this.unsubscribe$);
  }

  /**
   * Выполнить действие "Обновление".
   * @param {AppModProductPageItemParameters} parameters Параметры.
   */
  executeActionRefresh(parameters: AppModProductPageItemParameters = null) {
    if (parameters) {
      const location = this.appModProductPageItem.getLocation();

      location.parameters = parameters;

      this.appModProductPageItem.setLocation(location);
    }

    const commands = this.appModProductPageItem.createRouterLink(null, parameters);

    this.extRouter.navigate(commands).catch();
  }

  /**
   * Выполнить действие "Сохранение".
   * @param {AppModProductJobItemGetOutput} input
   */
  executeActionSave(input: AppModProductJobItemGetOutput) {
    this.appModProductPageList.sendEnsureLoadDataRequest();

    this.appStore.runActionSave(input);
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
  protected onGetPageKeyOverInit(pageKey: string) {
    super.onGetPageKeyOverInit(pageKey);

    this.isDataChangeAllowedChanged$.next(pageKey !== this.appModProductPageItem.settings.keys.keyView);

    this.parameters = this.appModProductPageItem.createParameters(appModProductPageItemConfigIndex);
  }

  /**
   * @inheritDoc
   * @param {string} pageKey
   */
  protected onGetPageKeyOverAfterViewInit(pageKey: string) {
    super.onGetPageKeyOverAfterViewInit(pageKey);

    this.extRoute.paramMap.pipe(
      takeUntil(this.unsubscribe$),
      switchMap(this.onRouteParamMapSwitchMapToJobItemGetInput),
      filter(input => !!input)
    ).subscribe(
      this.onGetJobItemGetInput
    );
  }

  private executeTitleActionItemAdd() {
    if (this.titleItemsCount === 0) {
      let isOk = true;
      let titleResourceKey: string;
      let titleTranslated$: Observable<string>;

      const {
        settings
      } = this.appModProductPageItem;

      const {
        keyCreate,
        keyEdit,
        keyView
      } = settings.keys;

      switch (this.pageKey) {
        case keyCreate:
          titleResourceKey = settings.titleOfModProductPageItemCreateResourceKey;
          titleTranslated$ = this.resources.titleOfModProductPageItemCreateTranslated$;
          break;
        case keyEdit:
          titleResourceKey = settings.titleOfModProductPageItemEditResourceKey;
          titleTranslated$ = this.resources.titleOfModProductPageItemEditTranslated$;
          break;
        case keyView:
          titleResourceKey = settings.titleOfModProductPageItemViewResourceKey;
          titleTranslated$ = this.resources.titleOfModProductPageItemViewTranslated$;
          break;
        default:
          isOk = false;
          break;
      }

      if (isOk) {
        this.appTitle.executeActionItemAdd(
          this.appModProductPageItem.settings.titleResourceKey,
          this.resources.titleTranslated$,
          this.unsubscribe$
        );

        this.appTitle.executeActionItemAdd(
          titleResourceKey,
          titleTranslated$,
          this.unsubscribe$
        );

        this.titleItemsCount = 2;      }
    }
  }

  /** @param {AppModProductJobItemGetInput} input */
  private onGetJobItemGetInput(input: AppModProductJobItemGetInput) {
    if (this.pageKey) {
      const {
        settings
      } = this.appModProductPageItem;

      const {
        keyCreate,
        keyEdit,
        keyView
      } = settings.keys;

      const {
        pathCreate,
        pathEdit,
        pathView
      } = settings.paths;

      const lookupOptionByMenuNodeKey = {
        [this.appModProductPageList.settings.key]: <AppHostPartMenuOption>{
          routerLink: this.appModProductPageList.createRouterLink()
        },
        [keyCreate]: <AppHostPartMenuOption>{
          routerLink: this.appModProductPageItem.createRouterLink(pathCreate)
        }
      };

      switch (this.pageKey) {
        case keyCreate: {
          lookupOptionByMenuNodeKey[keyCreate] = <AppHostPartMenuOption>{
            routerLink: this.appModProductPageItem.createRouterLink(pathCreate)
          };

          lookupOptionByMenuNodeKey[keyEdit] = <AppHostPartMenuOption>{
            isNeededToRemove: true
          };

          lookupOptionByMenuNodeKey[keyView] = <AppHostPartMenuOption>{
            isNeededToRemove: true
          };
        }
          break;
        case keyEdit:
        case keyView: {
          lookupOptionByMenuNodeKey[keyEdit] = <AppHostPartMenuOption>{
            routerLink: this.appModProductPageItem.createRouterLink(pathEdit)
          };

          lookupOptionByMenuNodeKey[keyView] = <AppHostPartMenuOption>{
            routerLink: this.appModProductPageItem.createRouterLink(pathView)
          };
        }
          break;
      }

      this.appMenu.executeActionSet(this.pageKey, lookupOptionByMenuNodeKey);

      this.executeTitleActionItemAdd();
    }

    this.appStore.runActionLoad(input);
  }

  /**
   * @param {ParamMap} paramMap
   * @returns {Observable<AppModProductJobItemGetInput>}
   */
  private onRouteParamMapSwitchMapToJobItemGetInput(paramMap: ParamMap): Observable<AppModProductJobItemGetInput> {
    const {
      settings
    } = this.appModProductPageItem;

    const {
      keyCreate,
      keyEdit,
      keyView
    } = settings.keys;

    const {
      pathCreate,
      pathEdit,
      pathView
    } = settings.paths;

    let isOk = true;
    let path: string;

    switch (this.pageKey) {
      case keyCreate:
        path = pathCreate;
        break;
      case keyEdit:
        path = pathEdit;
        break;
      case keyView:
        path = pathView;
        break;
      default:
        isOk = false;
        break;
    }

    let input: AppModProductJobItemGetInput;

    if (isOk) {
      const parameters = this.createParameters();

      const {
        paramId,
        paramName
      } = parameters;

      paramId.value = +paramMap.get(paramId.name);
      paramName.value = paramMap.get(paramName.name);

      const location = this.appModProductPageItem.getLocation();

      location.path = path;
      location.parameters = parameters;
      location.paramMap = paramMap;
      location.pageKey = this.pageKey;

      this.appModProductPageItem.setLocation(location);

      input = parameters.createJobItemGetInput();

      if (input.equals(this.jobItemGetInput)) {
        input = null;
      } else {
        this.jobItemGetInput = input;
      }
    }

    return of(input);
  }
}
