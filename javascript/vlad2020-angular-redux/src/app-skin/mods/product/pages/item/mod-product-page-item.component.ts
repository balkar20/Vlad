// //Author Maxim Kuzmin//makc//

import {AfterViewInit, Component, OnDestroy, OnInit, ViewChild} from '@angular/core';
import {NgForm} from '@angular/forms';
import {Observable} from 'rxjs';
import {AppCoreDeactivatingAbility} from '@app/core/deactivating/core-deactivating-ability';
import {AppCoreLoggingService} from '@app/core/logging/core-logging.service';
import {appCoreLoggingDiTokenLoggerName} from '@app/core/logging/core-logging-di';
import {AppModProductPageItemModel} from '@app/mods/product/pages/item/mod-product-page-item-model';
import {AppModProductPageItemPresenter} from '@app/mods/product/pages/item/mod-product-page-item-presenter';
import {AppModProductPageItemStore} from '@app/mods/product/pages/item/mod-product-page-item-store';
import {AppSkinCoreProgressSpinnerComponent} from '@app-skin/core/progress/spinner/core-progress-spinner.component';
import {AppSkinCoreProgressSpinnerDirective} from '@app-skin/core/progress/spinner/core-progress-spinner.directive';
import {AppSkinModProductPageItemView} from './mod-product-page-item-view';

/** Мод "Product". Страницы. Элемент. Компонент. */
@Component({
  templateUrl: './mod-product-page-item.component.html',
  styleUrls: ['./mod-product-page-item.component.css'],
  providers: [
    {provide: appCoreLoggingDiTokenLoggerName, useValue: AppSkinModProductPageItemComponent.name},
    AppCoreLoggingService,
    AppModProductPageItemModel,
    AppModProductPageItemStore
  ]
})
export class AppSkinModProductPageItemComponent implements AfterViewInit, OnDestroy, OnInit, AppCoreDeactivatingAbility {

  /** @type {AppSkinCoreProgressSpinnerComponent} */
  @ViewChild('ctrlLoading', {static: false}) private ctrlLoading: AppSkinCoreProgressSpinnerComponent;

  /** @type {AppSkinCoreProgressSpinnerDirective} */
  @ViewChild('ctrlRefresh', {static: true}) private ctrlRefresh: AppSkinCoreProgressSpinnerDirective;

  /** @type {NgForm} */
  @ViewChild('ctrlForm', {static: true}) private ctrlForm: NgForm;

  /**
   * Мой представитель.
   * @type {AppModProductPageItemPresenter}
   */
  myPresenter: AppModProductPageItemPresenter;

  /**
   * Мой вид.
   * @type {AppSkinModProductPageItemView}
   */
  myView: AppSkinModProductPageItemView;

  /**
   * Конструктор.
   * @param {AppModProductPageItemModel} model Модель.
   */
  constructor(
    model: AppModProductPageItemModel
  ) {
    this.myView = new AppSkinModProductPageItemView(
      model.getSettingErrors(),
      model.getSettingFields()
    );

    this.myPresenter = new AppModProductPageItemPresenter(
      model,
      this.myView
    );
  }

  /**
   * @inheritDoc
   * @returns {Observable<boolean> | Promise<boolean> | boolean}
   */
  canDeactivate(): Observable<boolean> | Promise<boolean> | boolean {
    return this.myPresenter.canDeactivate();
  }

  /** @inheritDoc */
  ngAfterViewInit() {
    this.myView.init(
      this.ctrlLoading,
      this.ctrlRefresh,
      this.ctrlForm
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
