// //Author Vlad Balkarov//vlad//

import {AfterViewInit, Component, OnDestroy} from '@angular/core';
import {AppCoreLoggingService} from '@app/core/logging/core-logging.service';
import {appCoreLoggingDiTokenLoggerName} from '@app/core/logging/core-logging-di';
import {AppModProductPresenter} from '@app/mods/product/mod-product-presenter';
import {AppModProductModel} from '@app/mods/product/mod-product-model';

/** Мод "Product". Компонент. */
@Component({
  templateUrl: './mod-product.component.html',
  styleUrls: ['./mod-product.component.css'],
  providers: [
    {provide: appCoreLoggingDiTokenLoggerName, useValue: AppSkinModProductComponent.name},
    AppCoreLoggingService,
    AppModProductModel
  ]
})
export class AppSkinModProductComponent implements AfterViewInit, OnDestroy {

  /**
   * Мой представитель.
   * @type {AppModProductPresenter}
   */
  myPresenter: AppModProductPresenter;

  /**
   * Конструктор.
   * @param {AppModProductModel} model Модель.
   */
  constructor(
    private model: AppModProductModel
  ) {
    this.myPresenter = new AppModProductPresenter(
      model
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
}
