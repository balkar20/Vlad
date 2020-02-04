// //Author Maxim Kuzmin//makc//

import {AppCoreCommonPagePresenter} from '@app/core/common/page/core-common-page-presenter';
import {AppModProductPageIndexModel} from './mod-product-page-index-model';
import {AppModProductPageIndexResources} from './mod-product-page-index-resources';
import {AppModProductPageIndexState} from './mod-product-page-index-state';
import {AppModProductPageIndexView} from './mod-product-page-index-view';

/** Мод "Product". Страницы. Начало. Представитель. */
export class AppModProductPageIndexPresenter extends AppCoreCommonPagePresenter<AppModProductPageIndexModel> {

  /**
   * Ресурсы.
   * @type {AppModProductPageIndexResources}
   */
  get resources(): AppModProductPageIndexResources {
    return this.model.resources;
  }

  /**
   * Конструктор.
   * @param {AppModProductPageIndexModel} model Модель.
   * @param {AppModProductPageIndexView} view Вид.
   */
  constructor(
    model: AppModProductPageIndexModel,
    private view: AppModProductPageIndexView
  ) {
    super(model);

    this.onGetState = this.onGetState.bind(this);
  }

  /** @inheritDoc */
  onAfterViewInit() {
    this.model.getState$().subscribe(this.onGetState);

    super.onAfterViewInit();
  }

  /** @inheritDoc */
  onInit() {
    this.view.routerLinkToModProductPageItemCreate = this.model.createRouterLinkToPageItemCreate();
    this.view.routerLinkToModProductPageItemEdit = this.model.createRouterLinkToPageItemEdit();
    this.view.routerLinkToModProductPageItemView = this.model.createRouterLinkToPageItemView();
    this.view.routerLinkToModProductPageList = this.model.createRouterLinkToPageList();

    super.onInit();
  }

  /** @param {AppModProductPageIndexState} state */
  private onGetState(state: AppModProductPageIndexState) {
    if (state) {
      const {
        action
      } = state;
    }
  }
}
