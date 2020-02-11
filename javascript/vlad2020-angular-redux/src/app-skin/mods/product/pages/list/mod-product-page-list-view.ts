// //Author Maxim Kuzmin//makc//

import {Paginator} from 'primeng/paginator';
import {merge} from 'rxjs';
import {AppModProductPageListSettings} from '@app/mods/product/pages/list/mod-product-page-list-settings';
import {AppModProductPageListView} from '@app/mods/product/pages/list/mod-product-page-list-view';
import {AppModProductPageListSettingColumns} from '@app/mods/product/pages/list/settings/mod-product-page-list-setting-columns';
import {AppSkinCoreProgressSpinnerComponent} from '@app-skin/core/progress/spinner/core-progress-spinner.component';
import {AppSkinCoreProgressSpinnerDirective} from '@app-skin/core/progress/spinner/core-progress-spinner.directive';
import {AppModProductPageListDataItem} from '@app/mods/product/pages/list/data/mod-product-page-list-data-item';
import {AppModProductPageListResourceColumns} from '@app/mods/product/pages/list/resources/mod-product-page-list-resource-columns';
import {Table} from 'primeng/table';
import {AppModProductJobListGetInput} from '@app/mods/product/jobs/list/get/mod-product-job-list-get-input';
import {AppModProductPageListParameters} from '@app/mods/product/pages/list/mod-product-page-list-parameters';

/** Мод "Product". Страницы. Список. Вид. */
export class AppSkinModProductPageListView extends AppModProductPageListView {

  /** @type {AppSkinCoreProgressSpinnerComponent} */
  private ctrlLoading: AppSkinCoreProgressSpinnerComponent;

  /** @type {Paginator} */
  private ctrlPaginator: Paginator;

  /** @type {AppSkinCoreProgressSpinnerDirective} */
  private ctrlRefresh: AppSkinCoreProgressSpinnerDirective;

  /** @type {Table} */
  private ctrlTable: Table;

  /** @type {boolean} */
  private isDataLoading = false;

  /**
   * Ключ данных.
   * @type {string}
   */
  dataKey: string;

  /**
   * Отображаемые столбцы.
   * @type {{ field: string, header: string }[]}
   */
  displayedColumns: { field: string, header: string }[];

  /**
   * Выбранный элемент.
   * @type {AppModProductPageListDataItem}
   */
  selectedItem: AppModProductPageListDataItem;

  /**
   * Конструктор.
   * @param {AppModProductPageListResourceColumns} resourceColumns Ресурс столбцов.
   * @param {AppModProductPageListSettings} settingColumns Настройка столбцов.
   * @param {number[]} pageSizeOptions Опции размера страницы.
   */
  constructor(
    resourceColumns: AppModProductPageListResourceColumns,
    settingColumns: AppModProductPageListSettingColumns,
    public pageSizeOptions: number[]
  ) {
    super();

    const {
      columnId: columnIdResource,
      columnName: columnNameResource,
      columnPrice: columnPriceResource,
      columnDescription: columnDescriptionResource,
    } = resourceColumns;

    const {
      columnId: columnIdSetting,
      columnName: columnNameSetting,
      columnPrice: columnPriceSetting,
      columnDescription: columnDescriptionSetting,
    } = settingColumns;

    this.dataKey = columnIdSetting.name;

    this.displayedColumns = [
      {
        field: columnIdSetting.name,
        get header(): string {
          return columnIdResource.label;
        }
      },
      {
        field: columnNameSetting.name,
        get header(): string {
          return columnNameResource.label;
        }
      },
      {
        field: columnPriceSetting.name,
        get header(): string {
          return columnPriceResource.label;
        }
      },
      {
        field: columnDescriptionSetting.name,
        get header(): string {
          return columnDescriptionResource.label;
        }
      }
    ];
  }

  /** @inheritDoc */
  getPageNumber(): number {
    return this.ctrlPaginator.getPage() + 1;
  }

  /** @inheritDoc */
  getPageSize(): number {
    return 10;
  }

  getSelectedItemId(): number {
    return this.selectedItem ? this.selectedItem.id : 0;
  }

  /** @inheritDoc */
  getSortDirection(): string {
    return this.ctrlTable.sortOrder > 0 ? 'asc' : 'desc';
  }

  /** @inheritDoc */
  getSortField(): string {
    return this.ctrlTable.sortField;
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
   * Инициализировать.
   * @param {AppSkinCoreProgressSpinnerComponent} ctrlLoading Элемент управления "Спиннер загрузки".
   * @param {AppSkinCoreProgressSpinnerDirective} ctrlRefresh Элемент управления "Спиннер обновления".
   * @param {Paginator} ctrlPaginator Элемент управления "Пагинатор".
   * @param {Table} ctrlTable Элемент управления "Таблица".
   */
  init(
    ctrlLoading: AppSkinCoreProgressSpinnerComponent,
    ctrlRefresh: AppSkinCoreProgressSpinnerDirective,
    ctrlPaginator: Paginator,
    ctrlTable: Table
  ) {
    this.ctrlLoading = ctrlLoading;
    this.ctrlRefresh = ctrlRefresh;
    this.ctrlPaginator = ctrlPaginator;
    this.ctrlTable = ctrlTable;

    this.ctrlTable.customSort = true;

    this.ctrlTable.sortFunction.subscribe(event => {
    });
  }

  /** @inheritDoc */
  initLoadingSpinner(callback: () => void) {
    this.ctrlLoading.init(callback);
  }

  /** @inheritDoc */
  initRefreshSpinner() {
    this.ctrlRefresh.init();
  }

  /**
   * @inheritDoc
   * @param {AppModProductPageListDataItem[]} data
   * @param {AppModProductPageListParameters} parameters
   */
  loadData(
    data: AppModProductPageListDataItem[],
    parameters: AppModProductPageListParameters
  ) {
    this.isDataLoading = true;

    this.ctrlTable.value = data;

    const {
      paramPageNumber,
      paramSelectedItemId,
      paramSortDirection,
      paramSortField,
      paramPrice
    } = parameters;

    this.setPageNumber(paramPageNumber.value);
    this.setSelectedItemId(paramSelectedItemId.value);
    this.setSelectedItemPrice(paramPrice.value);

    this.ctrlTable.sortField = paramSortField.value;
    this.ctrlTable.sortOrder = paramSortDirection.value === 'asc' ? 1 : -1;

    this.isDataLoading = false;
  }

  /**
   * @inheritDoc
   * @param {number} value
   */
  setPageNumber(value: number) {
    this.ctrlPaginator.first = (value - 1) * this.pageSize;
  }

  /**
   * @inheritDoc
   * @param {number} value
   */
  setSelectedItemId(value: number) {
    this.selectedItem = value > 0
      ? this.ctrlTable.value.find(item => item.id === value)
      : null;
  }

  /**
   * @inheritDoc
   * @param {number} value
   */
  setSelectedItemPrice(value: number) {
    this.selectedItem = value > 0
      ? this.ctrlTable.value.find(item => item.price === value)
      : null;
  }

  /** @inheritDoc */
  showLoadingSpinner() {
    this.ctrlLoading.show();
  }

  /** @inheritDoc */
  showRefreshSpinner() {
    this.ctrlRefresh.show();
  }

  /** @inheritDoc */
  subscribeOnRowSelect(callback: () => void) {
    this.ctrlTable.onRowSelect.subscribe(event => {
      if (!this.isDataLoading) {
        callback();
      }
    });
  }

  /** @inheritDoc */
  subscribeOnSortChange(callback: () => void) {
    this.ctrlTable.onSort.subscribe(event => {
      if (!this.isDataLoading) {
        callback();
      }
    });
  }

  /** @inheritDoc */
  subscribeOnSortOrPageChange(callback: () => void) {
    merge(
      this.ctrlTable.onSort,
      this.ctrlPaginator.onPageChange
    ).subscribe(event => {
      if (!this.isDataLoading) {
        callback();
      }
    });
  }
}
