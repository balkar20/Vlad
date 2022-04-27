// //Author Vlad Balkarov//vlad//

import {NgForm} from '@angular/forms';
import {AppSkinCoreProgressSpinnerComponent} from '@app-skin/core/progress/spinner/core-progress-spinner.component';
import {AppSkinCoreProgressSpinnerDirective} from '@app-skin/core/progress/spinner/core-progress-spinner.directive';
import {AppModProductPageItemView} from '@app/mods/product/pages/item/mod-product-page-item-view';
import {AppModProductPageItemSettingErrors} from '@app/mods/product/pages/item/settings/mod-product-page-item-setting-errors';
import {AppModProductPageItemSettingFields} from '@app/mods/product/pages/item/settings/mod-product-page-item-setting-fields';
import {SelectItem} from 'primeng/api';
import {
  AppModProductCommonJobOptionsGetOutputList,
  appModProductCommonJobOptionsGetOutputListCreate
} from '@app/mods/product/common/jobs/options/get/output/mod-product-common-job-options-get-output-list';

/** Мод "Product". Страницы. Элемент. Представление. */
export class AppSkinModProductPageItemView extends AppModProductPageItemView {

  /** @type {AppSkinCoreProgressSpinnerComponent} */
  private ctrlLoading: AppSkinCoreProgressSpinnerComponent;

  /** @type {AppSkinCoreProgressSpinnerDirective} */
  private ctrlRefresh: AppSkinCoreProgressSpinnerDirective;

  /** @type {NgForm} */
  private ctrlForm: NgForm;

  /**
   * Вырианты выбора "ProductCategory".
   * @type {SelectItem[]}
   */
  selectItemsProductCategory: SelectItem[] = [];

  /**
   * Конструктор.
   * @param {AppModProductPageItemSettingErrors} settingErrors Настройка ошибок.
   * @param {AppModProductPageItemSettingFields} settingFields Настройка полей.
   */
  constructor(
    settingErrors: AppModProductPageItemSettingErrors,
    settingFields: AppModProductPageItemSettingFields
  ) {
    super(
      settingErrors,
      settingFields
    );
  }

  /**
   * Инициализировать.
   * @param {AppSkinCoreProgressSpinnerComponent} ctrlLoading Элемент управления "Спиннер загрузки".
   * @param {AppSkinCoreProgressSpinnerDirective} ctrlRefresh Элемент управления "Спиннер обновления".
   * @param {NgForm} ctrlForm Элемент управления "Форма".
   */
  init(
    ctrlLoading: AppSkinCoreProgressSpinnerComponent,
    ctrlRefresh: AppSkinCoreProgressSpinnerDirective,
    ctrlForm: NgForm
  ) {
    this.ctrlLoading = ctrlLoading;
    this.ctrlRefresh = ctrlRefresh;
    this.ctrlForm = ctrlForm;
  }

  /** @inheritDoc */
  hideLoadingSpinner() {
    this.ctrlLoading.hide();
  }

  /** @inheritDoc */
  hideRefreshSpinner() {
    this.ctrlRefresh.hide();
  }

  /**
   * @inheritDoc
   * @param {() => void} callback
   */
  initLoadingSpinner(callback: () => void) {
    this.ctrlLoading.init(callback);
  }

  /** @inheritDoc */
  initRefreshSpinner() {
    this.ctrlRefresh.init();
  }

  /**
   * @inheritDoc
   * @param {AppModProductCommonJobOptionsGetOutputList} data
   */
  loadOptionsProductCategory(data?: AppModProductCommonJobOptionsGetOutputList) {
    super.loadOptionsProductCategory(data);

    if (this.optionsProductCategory) {
      this.selectItemsProductCategory = this.optionsProductCategory.items.map(option => <SelectItem>{
        label: option.name,
        title: option.name,
        value: option.value
      });
    }
  }

  /** @inheritDoc */
  resetForm() {
    this.ctrlForm.resetForm();
  }

  /** @inheritDoc */
  showLoadingSpinner() {
    this.ctrlLoading.show();
  }

  /** @inheritDoc */
  showRefreshSpinner() {
    this.ctrlRefresh.show();
  }
}
