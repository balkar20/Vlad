// //Author Maxim Kuzmin//makc//

import {Validators} from '@angular/forms';
import {Observable, of} from 'rxjs';
import {AppCoreCommonPagePresenter} from '@app/core/common/page/core-common-page-presenter';
import {AppCoreExecutableAsync} from '@app/core/executable/core-executable-async';
import {appDataObjectProductCreate} from '@app/data/objects/data-object-product';
import {
  AppModProductJobItemGetOutput,
  appModProductJobItemGetOutputCreate
} from '../../jobs/item/get/mod-product-job-item-get-output';
import {AppModProductPageItemEnumActions} from './enums/mod-product-page-item-enum-actions';
import {AppModProductPageItemModel} from './mod-product-page-item-model';
import {AppModProductPageItemResources} from './mod-product-page-item-resources';
import {AppModProductPageItemState} from './mod-product-page-item-state';
import {AppModProductPageItemView} from './mod-product-page-item-view';

/** Мод "Product". Страницы. Элемент. Представитель. */
export class AppModProductPageItemPresenter extends AppCoreCommonPagePresenter<AppModProductPageItemModel> {

  /** @type {AppCoreExecutableAsync} */
  private onActionsDataChangedAsync: AppCoreExecutableAsync;

  /** @type {AppCoreExecutableAsync} */
  private onActionsDataChangingAsync: AppCoreExecutableAsync;

  /**
   * Ресурсы.
   * @type {AppModProductPageItemResources}
   */
  get resources(): AppModProductPageItemResources {
    return this.model.resources;
  }

  /**
   * Конструктор.
   * @param {AppModProductPageItemModel} model Модель.
   * @param {AppModProductPageItemView} view Вид.
   */
  constructor(
    model: AppModProductPageItemModel,
    private view: AppModProductPageItemView
  ) {
    super(model);

    this.onActionsDataChanged = this.onActionsDataChanged.bind(this);
    this.onActionsDataChangedAsync = new AppCoreExecutableAsync(this.onActionsDataChanged);

    this.onActionsDataChanging = this.onActionsDataChanging.bind(this);
    this.onActionsDataChangingAsync = new AppCoreExecutableAsync(this.onActionsDataChanging);

    this.onDataLoaded = this.onDataLoaded.bind(this);
    this.onGetIsDataChangeAllowed = this.onGetIsDataChangeAllowed.bind(this);
    this.onGetState = this.onGetState.bind(this);

    this.buildView();
  }

  /**
   * Получение разрешения на деактивацию.
   * @returns {Observable<boolean>} True - если деактивация разрешена, False - в противном случае.
   */
  canDeactivate(): Observable<boolean> {
    const {
      appDialog
    } = this.model;

    const {
      actionDeactivate
    } = this.resources.actions;

    return this.view.formGroup.dirty ? appDialog.confirm$(actionDeactivate.confirm) : of(true);
  }

  /** @inheritDoc */
  onAfterViewInit() {
    this.view.initLoadingSpinner(this.onDataLoaded);
    this.view.initRefreshSpinner();

    this.model.getState$().subscribe(this.onGetState);

    super.onAfterViewInit();
  }

  /**
   * @inheritDoc
   * @param {string} errorMessage Сообщение об ошибке.
   * @param {any} errorData Данные ошибки.
   */
  protected onError(errorMessage: string, errorData: any) {
    this.hideSpinners();

    super.onError(errorMessage, errorData);
  }

  /** @inheritDoc */
  onInit() {
    this.model.getIsDataChangeAllowed$().subscribe(this.onGetIsDataChangeAllowed);

    super.onInit();
  }

  /** Обработчик события отправки. */
  onSubmit() {
    if (!this.view.formGroup.valid) {
      return;
    }

    const input = appModProductJobItemGetOutputCreate();

    let {
      data
    } = this.view;

    const {
      fieldName,
      fieldPrice,
      fieldDescription,
      fieldObjectProductCategory
    } = this.view;

    if (!data) {
      data = appModProductJobItemGetOutputCreate();
    }

    input.objectProduct = data.objectProduct
      ? data.objectProduct
      : appDataObjectProductCreate();

    const {
      objectProduct
    } = input;

    objectProduct.name = fieldName.value;
    objectProduct.price = fieldPrice.value;
    objectProduct.description = fieldDescription.value;
    objectProduct.objectProductCategoryId = fieldObjectProductCategory.value;

    this.model.executeActionSave(input);
  }

  /** Обработчик события окончания загрузки данных. */
  protected onDataLoaded() {
    this.view.isDataLoaded = true;
  }

  private buildView() {
    const {
      extFormBuilder
    } = this.model;

    const {
      fieldId,
      fieldName,
      fieldPrice,
      fieldDescription,
      fieldObjectProductCategory
    } = this.model.getSettingFields();

    const formGroup = extFormBuilder.group({
      [fieldId.name]: [{value: '', disabled: true}, Validators.required],
      [fieldName.name]: [{value: '', disabled: true}, Validators.required],
      [fieldPrice.name]: [{value: '', disabled: true}, Validators.required],
      [fieldDescription.name]: [{value: '', disabled: true}, Validators.required],
      [fieldObjectProductCategory.name]: [{value: '', disabled: true}, Validators.required]
    });

    this.view.build(formGroup);
  }

  private hideSpinners() {
    const {
      isDataLoaded
    } = this.view;

    if (isDataLoaded) {
      this.view.hideRefreshSpinner();
    } else {
      this.view.hideLoadingSpinner();
    }
  }

  /** @param {AppModProductJobItemGetOutput} data */
  private loadData(data: AppModProductJobItemGetOutput) {
    if (data) {
      this.view.data = data;

      const {
        objectProduct
      } = this.view.data;

      const {
        fieldId,
        fieldName,
        fieldPrice,
        fieldDescription,
        fieldObjectProductCategory
      } = this.view;

      if (objectProduct) {
        fieldId.setValue(objectProduct.id, {emitEvent: false});
        fieldName.setValue(objectProduct.name, {emitEvent: false});
        fieldPrice.setValue(objectProduct.price, {emitEvent: false});
        fieldDescription.setValue(objectProduct.description, {emitEvent: false});
        fieldObjectProductCategory.setValue(objectProduct.objectProductCategoryId, {emitEvent: false});
      }
    } else {
      this.view.data = appModProductJobItemGetOutputCreate();
    }

    this.view.formGroup.markAsPristine();
  }

  /** @returns {boolean} */
  private loadJobItemGetResult(): boolean {
    const {
      jobItemGetInput: input,
      jobItemGetResult: result
    } = this.model.getState();

    if (result) {
      const {
        isOk,
        errorMessages,
        successMessages
      } = result;

      this.view.loadResponseErrorMessages(errorMessages);
      this.view.loadResponseSuccessMessages(successMessages);

      if (isOk) {
        let {
          data
        } = result;

        if (!input.isForUpdate) {
          data = null;
        }

        this.loadData(data);
      }

      return isOk;
    }

    return false;
  }

  private loadJobOptionsProductFeatureGetResult() {
    const {
      jobOptionsProductFeatureGetResult: result
    } = this.model.getState();

    if (result) {
      const {
        data,
        errorMessages,
        successMessages
      } = result;

      this.view.loadResponseErrorMessages(errorMessages);
      this.view.loadResponseSuccessMessages(successMessages);

      this.view.loadOptionsProductFeature(data);
    }
  }

  private loadJobOptionsProductCategoryGetResult() {
    const {
      jobOptionsProductCategoryGetResult: result
    } = this.model.getState();

    if (result) {
      const {
        data,
        errorMessages,
        successMessages
      } = result;

      this.view.loadResponseErrorMessages(errorMessages);
      this.view.loadResponseSuccessMessages(successMessages);

      this.view.loadOptionsProductCategory(data);
    }
  }

  private onActionsDataChanging() {
    const {
      isDataLoaded
    } = this.view;

    if (isDataLoaded) {
      this.view.showRefreshSpinner();
    } else {
      this.view.showLoadingSpinner();
    }
  }

  private onActionsDataChanged() {
    const {
      action
    } = this.model.getState();


    switch (action) {
      case AppModProductPageItemEnumActions.LoadSuccess:
        this.onDataChangedByLoadSuccess();
        break;
      case AppModProductPageItemEnumActions.SaveSuccess:
        this.onDataChangedBySaveSuccess();
        break;
    }

    this.hideSpinners();
  }

  private onDataChangedByLoadSuccess() {
    this.loadJobItemGetResult();
    this.loadJobOptionsProductFeatureGetResult();
    this.loadJobOptionsProductCategoryGetResult();
  }

  private onDataChangedBySaveSuccess() {
    if (this.loadJobItemGetResult()) {
      const {
        jobItemGetInput: input
      } = this.model.getState();

      const {
        formGroup
      } = this.view;

      if (!input.isForUpdate) {
        this.resetForm();
      }

      this.refresh();
    }
  }

  /** @param {boolean} isDataChangeAllowed */
  private onGetIsDataChangeAllowed(isDataChangeAllowed: boolean) {
    this.view.isDataChangeAllowed = isDataChangeAllowed;

    if (this.view.isDataChangeAllowed) {
      this.view.fieldName.enable();
      this.view.fieldPrice.enable();
      this.view.fieldDescription.enable();
      this.view.fieldObjectProductCategory.enable();
    }
  }

  /** @param {AppModProductPageItemState} state */
  private onGetState(state: AppModProductPageItemState) {
    if (state) {
      const {
        action
      } = state;

      this.view.responseErrorMessages = [];
      this.view.responseSuccessMessages = [];

      switch (action) {
        case AppModProductPageItemEnumActions.Load:
        case AppModProductPageItemEnumActions.Save:
          this.onActionsDataChangingAsync.execute();
          break;
        case AppModProductPageItemEnumActions.LoadSuccess:
        case AppModProductPageItemEnumActions.SaveSuccess:
          this.onActionsDataChangedAsync.execute();
          break;
      }
    }
  }

  private refresh() {
    const parameters = this.model.createParameters();

    const {
      paramId,
    } = parameters;

    paramId.value = this.view.fieldId.value;

    this.model.executeActionRefresh(parameters);
  }

  private resetForm() {
    this.view.resetForm();
    this.view.formGroup.reset();
  }
}
