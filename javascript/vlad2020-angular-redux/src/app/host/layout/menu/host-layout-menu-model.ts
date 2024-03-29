// //Author Vlad Balkarov//vlad//

import {Observable, of} from 'rxjs';
import {switchMap, takeUntil} from 'rxjs/operators';
import {AppCoreCommonUnsubscribable} from '@app/core/common/core-common-unsubscribable';
import {AppCoreLocalizationService} from '@app/core/localization/core-localization.service';
import {AppCoreTreeEnumAxisMany} from '@app/core/tree/enums/core-tree-enum-axis-many';
import {AppHostLayoutMenuDataItem} from '@app/host/layout/menu/data/host-layout-menu-data-item';
import {AppHostPartMenuDataItem} from '@app/host/parts/menu/data/host-part-menu-data-item';
import {AppHostPartMenuJobNodeFindInput} from '@app/host/parts/menu/jobs/node/find/host-part-menu-job-node-find-input';
import {AppHostPartMenuJobNodesFindInput} from '@app/host/parts/menu/jobs/nodes/find/host-part-menu-job-nodes-find-input';
import {AppHostPartMenuState} from '@app/host/parts/menu/host-part-menu-state';
import {AppHostPartMenuStore} from '@app/host/parts/menu/host-part-menu-store';
import {AppHostLayoutMenuState} from './host-layout-menu-state';
import {AppHostLayoutMenuStore} from './host-layout-menu-store';

/** Хост. Разметка. Меню. Модель. */
export class AppHostLayoutMenuModel extends AppCoreCommonUnsubscribable {

  /**
   * Конструктор.
   * @param {AppCoreLocalizationService} appLocalizer Локализатор.
   * @param {AppHostPartMenuStore} appMenuStore Хранилище состояния меню.
   * @param {AppHostLayoutMenuStore} appStore Хранилище состояния.
   */
  constructor(
    private appLocalizer: AppCoreLocalizationService,
    private appMenuStore: AppHostPartMenuStore,
    private appStore: AppHostLayoutMenuStore
  ) {
    super();

    this.onMenuStateSwitchMap = this.onMenuStateSwitchMap.bind(this);
    this.executeActionLoad = this.executeActionLoad.bind(this);
  }

  /**
   * Получить состояние.
   * @returns {AppHostLayoutMenuState} Состояние.
   */
  getState(): AppHostLayoutMenuState {
    return this.appStore.getState();
  }

  /**
   * Получить поток состояния.
   * @param {number} menuLevel Уровень меню.
   * @returns {Observable<AppHostLayoutMenuState>} Поток состояния.
   */
  getState$(menuLevel: number): Observable<AppHostLayoutMenuState> {
    return this.appStore.getState$(menuLevel, this.unsubscribe$);
  }

  /**
   * Локализировать элементы.
   * @param {AppHostPartMenuDataItem[]} items Элементы.
   */
  localizeItems(items: AppHostLayoutMenuDataItem[]) {
    items.forEach(item => {
      this.localizeItem(item.data);
    });
  }

  /** Обработчик события после инициализации вида. */
  onAfterViewInit() {
    this.appMenuStore.getState$(this.unsubscribe$).pipe(
      switchMap(this.onMenuStateSwitchMap)
    ).subscribe(
      this.executeActionLoad
    );
  }

  /** @inheritDoc */
  onDestroy() {
    super.onDestroy();

    this.appStore.runActionClear();
  }

  /** @param {AppHostPartMenuJobNodeFindInput} input */
  private executeActionLoad(input: AppHostPartMenuJobNodesFindInput) {
    if(input.dataKey != "RootPageAdministration" && input.dataKey != "ModAuthPageLogon"  && input){
      console.log(input);
    }
    this.appStore.runActionLoad(input);
  }

  /** @param {AppHostPartMenuDataItem} item */
  private localizeItem(item: AppHostPartMenuDataItem) {
    if(item.titleResourceKey != ""){
      console.log(item);
    }
    
    this.appLocalizer.createTranslator(
      item.titleResourceKey
    ).translate$().pipe(takeUntil(this.unsubscribe$)).subscribe(s => {
      item.title = s;
    });
  }

  /**
   * @param {AppHostPartMenuState} menuState
   * @returns {Observable<AppHostPartMenuJobNodeFindInput>}
   */
  private onMenuStateSwitchMap(menuState: AppHostPartMenuState): Observable<AppHostPartMenuJobNodesFindInput> {
    const input = new AppHostPartMenuJobNodesFindInput(
      menuState.menuNodeKey,
      AppCoreTreeEnumAxisMany.Ancestors,
      1,
      menuState.lookupOptionByMenuNodeKey
    );

    return of(input);
  }
}
