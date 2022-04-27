// //Author Vlad Balkarov//vlad//

import {AfterViewInit, Component, OnDestroy, OnInit, ViewChild} from '@angular/core';
import {Paginator} from 'primeng/paginator';
import {Table} from 'primeng/table';
import {AppCoreLoggingService} from '@app/core/logging/core-logging.service';
import {appCoreLoggingDiTokenLoggerName} from '@app/core/logging/core-logging-di';
import {AppModProductPageListPresenter} from '@app/mods/product/pages/list/mod-product-page-list-presenter';
import {AppModProductPageListModel} from '@app/mods/product/pages/list/mod-product-page-list-model';
import {AppModProductPageListStore} from '@app/mods/product/pages/list/mod-product-page-list-store';
import {AppSkinCoreProgressSpinnerComponent} from '@app-skin/core/progress/spinner/core-progress-spinner.component';
import {AppSkinCoreProgressSpinnerDirective} from '@app-skin/core/progress/spinner/core-progress-spinner.directive';
import {AppSkinModProductPageListView} from './mod-product-page-list-view';

/** Мод "Product". Страницы. Список. Компонент. */
@Component({
  templateUrl: './mod-product-page-list.component.html',
  styleUrls: ['./mod-product-page-list.component.css'],
  providers: [
    {provide: appCoreLoggingDiTokenLoggerName, useValue: AppSkinModProductPageListComponent.name},
    AppCoreLoggingService,
    AppModProductPageListModel,
    AppModProductPageListStore
  ]
})
export class AppSkinModProductPageListComponent implements AfterViewInit, OnDestroy, OnInit {

  /** @type {AppSkinCoreProgressSpinnerComponent} */
  @ViewChild('ctrlLoading', {static: false}) private ctrlLoading: AppSkinCoreProgressSpinnerComponent;

  /** @type {Paginator} */
  @ViewChild('ctrlPaginator', {static: true}) private ctrlPaginator: Paginator;

  /** @type {AppSkinCoreProgressSpinnerDirective} */
  @ViewChild('ctrlRefresh', {static: true}) private ctrlRefresh: AppSkinCoreProgressSpinnerDirective;

  /** @type {Table} */
  @ViewChild('ctrlTable', {static: true}) private ctrlTable: Table;

  /**
   * Мой представитель.
   * @type {AppModProductPageListPresenter}
   */
  myPresenter: AppModProductPageListPresenter;

  /**
   * Мой вид.
   * @type {AppSkinModProductPageListView}
   */
  myView: AppSkinModProductPageListView;

  /**
   * Конструктор.
   * @param {AppModProductPageListModel} model Модель.
   */
  constructor(
    model: AppModProductPageListModel
  ) {
    this.myView = new AppSkinModProductPageListView(
      model.resources.columns,
      model.getSettingColumns(),
      model.getSettingPageSizeOptions()
    );

    this.myPresenter = new AppModProductPageListPresenter(
      model,
      this.myView
    );
  }

  /** @inheritDoc */
  ngAfterViewInit() {
    this.myView.init(
      this.ctrlLoading,
      this.ctrlRefresh,
      this.ctrlPaginator,
      this.ctrlTable
    );

    this.myPresenter.onAfterViewInit();
  }

  /** @inheritDoc */
  ngOnDestroy() {
    this.myPresenter.onDestroy();
  }

  /** @inheritDoc */
  ngOnInit() {
    this.myPresenter.onInit();
  }
}
