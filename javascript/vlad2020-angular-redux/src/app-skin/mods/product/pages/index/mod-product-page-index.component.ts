// //Author Maxim Kuzmin//makc//

import {AfterViewInit, Component, OnDestroy, OnInit} from '@angular/core';
import {AppCoreLoggingService} from '@app/core/logging/core-logging.service';
import {appCoreLoggingDiTokenLoggerName} from '@app/core/logging/core-logging-di';
import {AppModProductPageIndexModel} from '@app/mods/product/pages/index/mod-product-page-index-model';
import {AppModProductPageIndexPresenter} from '@app/mods/product/pages/index/mod-product-page-index-presenter';
import {AppModProductPageIndexStore} from '@app/mods/product/pages/index/mod-product-page-index-store';
import {AppModProductPageIndexView} from '@app/mods/product/pages/index/mod-product-page-index-view';

/** Мод "Product". Страницы. Начало. Компонент. */
@Component({
  templateUrl: './mod-product-page-index.component.html',
  styleUrls: ['./mod-product-page-index.component.css'],
  providers: [
    {provide: appCoreLoggingDiTokenLoggerName, useValue: AppSkinModProductPageIndexComponent.name},
    AppCoreLoggingService,
    AppModProductPageIndexModel,
    AppModProductPageIndexStore
  ]
})
export class AppSkinModProductPageIndexComponent implements AfterViewInit, OnDestroy, OnInit {

  /**
   * Мой представитель.
   * @type {AppModProductPageIndexPresenter}
   */
  myPresenter: AppModProductPageIndexPresenter;

  /**
   * Мой вид.
   * @type {AppModProductPageIndexView}
   */
  myView: AppModProductPageIndexView;

  /**
   * Конструктор.
   * @param {AppModProductPageIndexModel} model Модель.
   */
  constructor(
    model: AppModProductPageIndexModel
  ) {
    this.myView = new AppModProductPageIndexView();

    this.myPresenter = new AppModProductPageIndexPresenter(
      model,
      this.myView
    );
  }

  /** @inheritDoc */
  ngAfterViewInit() {
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
