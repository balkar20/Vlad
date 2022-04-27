// //Author Vlad Balkarov//vlad//

import {AppCoreCommonPagePresenter} from '@app/core/common/page/core-common-page-presenter';
import {AppCoreExecutableAsync} from '@app/core/executable/core-executable-async';
import {AppModProductJobListGetOutput} from '../../jobs/list/get/mod-product-job-list-get-output';
import {AppModProductPageListDataItem} from './data/mod-product-page-list-data-item';
import {AppModProductPageListEnumActions} from './enums/mod-product-page-list-enum-actions';
import {AppModProductPageListModel} from './mod-product-page-list-model';
import {AppModProductPageListResources} from './mod-product-page-list-resources';
import {AppModProductPageListState} from './mod-product-page-list-state';
import {AppModProductPageListView} from './mod-product-page-list-view';

/** Мод "Product". Страницы. Список. Представитель. */
export class AppModProductPageListPresenter extends AppCoreCommonPagePresenter<AppModProductPageListModel> {

  /** @type {AppCoreExecutableAsync} */
  private onActionsDataChangedAsync: AppCoreExecutableAsync;

  /** @type {AppCoreExecutableAsync} */
  private onActionsDataChangingAsync: AppCoreExecutableAsync;

  /**
   * Ресурсы.
   * @type {AppModProductPageListResources}
   */
  get resources(): AppModProductPageListResources {
    return this.model.resources;
  }

  /**
   * Конструктор.
   * @param {AppModProductPageListModel} model Модель.
   * @param {AppModProductPageListView} view Вид.
   */
  constructor(
    model: AppModProductPageListModel,
    private view: AppModProductPageListView
  ) {
    super(model);

    this.onActionsDataChanged = this.onActionsDataChanged.bind(this);
    this.onActionsDataChangedAsync = new AppCoreExecutableAsync(this.onActionsDataChanged);

    this.onActionsDataChanging = this.onActionsDataChanging.bind(this);
    this.onActionsDataChangingAsync = new AppCoreExecutableAsync(this.onActionsDataChanging);

    this.onDataLoaded = this.onDataLoaded.bind(this);
    this.onFilterChange = this.onFilterChange.bind(this);
    this.onGetIsDataRefreshed = this.onGetIsDataRefreshed.bind(this);
    this.onGetIsItemDeleteStarted = this.onGetIsItemDeleteStarted.bind(this);
    this.onGetState = this.onGetState.bind(this);
    this.onRowSelect = this.onRowSelect.bind(this);
    this.onSortChange = this.onSortChange.bind(this);
    this.onSortOrPageChange = this.onSortOrPageChange.bind(this);
  }

  /** @inheritDoc */
  onAfterViewInit() {
    this.view.subscribeOnRowSelect(this.onRowSelect);
    this.view.subscribeOnSortChange(this.onSortChange);
    this.view.subscribeOnSortOrPageChange(this.onSortOrPageChange);

    this.view.initLoadingSpinner(this.onDataLoaded);
    this.view.initRefreshSpinner();

    this.model.getState$().subscribe(this.onGetState);
    this.model.subscribeToEventDelayedDistinct(this.view.fieldName.valueChanges, this.onFilterChange);

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
    this.model.getIsDataRefreshed$().subscribe(this.onGetIsDataRefreshed);
    this.model.getIsItemDeleteStarted$().subscribe(this.onGetIsItemDeleteStarted);

    super.onInit();
  }

  /**
   * Обработчик события удаления элемента.
   * @param {number} id Идентификатор.
   */
  onItemDelete(id: number) {
    if (this.view.isItemDeleteStarted) {
      return;
    }

    this.view.setSelectedItemId(id);

    this.model.executeActionItemDelete(id);
  }

  /**
   * Обработчик события нажатия на кнопку редактирования.
   * @param {number} id Идентификатор.
   */
  onItemEdit(id: number) {
    this.view.setSelectedItemId(id);

    this.model.executeActionItemEdit(id);
  }

  /** Обработчик события вставки элемента. */
  onItemInsert() {
    this.model.executeActionItemInsert();
  }

  /**
   * Обработчик события нажатия на кнопку просмотра.
   * @param {number} id Идентификатор.
   */
  onItemView(id: number) {
    this.view.setSelectedItemId(id);

    this.model.executeActionItemView(id);
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

  /** @param {AppModProductJobListGetOutput} data */
  private loadData(data: AppModProductJobListGetOutput) {
    console.log("loadData");
    const {
      jobListGetInput
    } = this.model.getState();

    this.view.pageSize = jobListGetInput
      ? this.model.getRealPageSize(jobListGetInput.dataPageSize)
      : this.model.getRealPageSize();

    let totalCount = 0;
    let items: AppModProductPageListDataItem[];

    const {
      isDataLoaded,
      isDataRefreshed
    } = this.view;

    if ((!isDataLoaded || !isDataRefreshed) && jobListGetInput) {
      this.view.fieldName.setValue(jobListGetInput.dataName, {emitEvent: false});
    }

    if (data) {
      totalCount = data.totalCount;
      console.log(data.items);
      items = data.items.map(
        x => new AppModProductPageListDataItem(
          x.objectProduct.id,
          x.objectProduct.name,
          x.objectProduct.price,
          x.objectProduct.description
        )
      );
    }

    if (!items) {
      items = [];
    }

    this.view.totalCount = totalCount;
    console.log("loadData params:");
    console.log(items);
    console.log(this.model.getParameters());
    this.view.loadData(items, this.model.getParameters());
    console.log("/loadData");
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

    let isCompleted = false;

    switch (action) {
      case AppModProductPageListEnumActions.DeleteSuccess:
        isCompleted = this.onDataChangedByDeleteSuccess();
        break;
      case AppModProductPageListEnumActions.LoadSuccess:
        isCompleted = this.onDataChangedByLoadSuccess();
        break;
    }

    if (isCompleted) {
      this.view.isItemDeleteStarted = false;

      this.hideSpinners();
    }
  }

  /** @returns {boolean} */
  private onDataChangedByDeleteSuccess(): boolean {
    const {
      jobItemDeleteResult
    } = this.model.getState();

    if (jobItemDeleteResult) {
      const {
        isOk,
        errorMessages,
        successMessages
      } = jobItemDeleteResult;

      this.view.responseErrorMessages = errorMessages;
      this.view.responseSuccessMessages = successMessages;

      if (isOk) {
        if (!this.model.onAfterActionItemDeleteSuccess()) {
          this.view.setSelectedItemId(0);

          this.model.onReceiveEnsureLoadDataRequest();

          this.refresh();
        }
      }
    }

    return true;
  }

  /** @returns {boolean} */
  private onDataChangedByLoadSuccess(): boolean {
    console.log("onDataChangedByLoadSuccess");
    const {
      jobListGetResult: result
    } = this.model.getState();
    console.log(result);
    if (result) {
      const {
        data,
        errorMessages,
        successMessages
      } = result;

      this.view.responseErrorMessages = errorMessages;
      this.view.responseSuccessMessages = successMessages;

      
      console.log(data);
      console.log("/onDataChangedByLoadSuccess");
      this.loadData(data);
    }

    return true;
  }

  private onDataLoaded() {
    this.view.isDataLoaded = true;
  }

  private onFilterChange() {
    console.log("onFilterChange");
    if (this.view.getPageNumber() > 1) {
      this.view.setPageNumber(1);
    }

    this.model.onReceiveEnsureLoadDataRequest();

    this.refresh();
  }

  private onGetIsDataRefreshed(isDataRefreshed: boolean) {
    this.view.isDataRefreshed = isDataRefreshed;
  }

  private onGetIsItemDeleteStarted() {
    this.view.isItemDeleteStarted = true;
  }

  /** @param {AppModProductPageListState} state */
  private onGetState(state: AppModProductPageListState) {
    if (state) {
      const {
        action
      } = state;

      this.view.responseErrorMessages = [];
      this.view.responseSuccessMessages = [];

      switch (action) {
        case AppModProductPageListEnumActions.Delete:
        case AppModProductPageListEnumActions.Load:
          this.onActionsDataChangingAsync.execute();
          break;
        case AppModProductPageListEnumActions.DeleteSuccess:
        case AppModProductPageListEnumActions.LoadSuccess:
          this.onActionsDataChangedAsync.execute();
          break;
      }
    }
  }

  private onRowSelect() {
    this.refresh();
  }

  private onSortChange() {
    console.log("onSortChange");
    if (this.view.getPageNumber() > 1) {
      this.view.setPageNumber(1);
    }
  }

  private onSortOrPageChange() {
    console.log("onSortOrPageChange");
    this.model.onReceiveEnsureLoadDataRequest();

    this.refresh();
  }

  private refresh() {
    const parameters = this.model.createParameters();
    console.log("refresh");
    const {
      paramIsDataRefreshed,
      paramName,
      paramPageNumber,
      paramPageSize,
      paramSelectedItemId,
      paramSortDirection,
      paramSortField
    } = parameters;

    paramIsDataRefreshed.value = true;
    paramName.value = this.view.fieldName.value;
    paramPageNumber.value = this.view.getPageNumber();
    paramPageSize.value = this.view.getPageSize();
    paramSelectedItemId.value = this.view.getSelectedItemId();
    paramSortField.value = this.view.getSortField();
    console.log(paramSortField.value);
    paramSortDirection.value = this.view.getSortDirection();

    this.model.executeActionRefresh(parameters);
    console.log("end refresh");
  }
}
