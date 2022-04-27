// //Author Vlad Balkarov//vlad//

import {AppCoreCommonPageParameter} from '@app/core/common/page/core-common-page-parameter';
import {AppCoreCommonPageParameters} from '@app/core/common/page/core-common-page-parameters';
import {AppCoreSettings} from '@app/core/core-settings';
import {AppModProductJobListGetInput} from '@app/mods/product/jobs/list/get/mod-product-job-list-get-input';

/** Мод "Product". Страницы. Список. Параметры. */
export class AppModProductPageListParameters extends AppCoreCommonPageParameters {

  /**
   * Параметр "Признак того, что данные обновлены".
   * @type {boolean}
   */
  paramIsDataRefreshed = new AppCoreCommonPageParameter<boolean>('r', this.index);

  /**
   * Параметр "Номер страницы".
   * @type {AppCoreCommonPageParameter<number>}
   */
  paramPageNumber = new AppCoreCommonPageParameter<number>('pn', this.index);

  /**
   * Параметр "Размер страницы".
   * @type {AppCoreCommonPageParameter<number>}
   */
  paramPageSize = new AppCoreCommonPageParameter<number>('ps', this.index);

  /**
   * Параметр "Индекс выбранного элемента".
   * @type {AppCoreCommonPageParameter<number>}
   */
  paramSelectedItemId = new AppCoreCommonPageParameter<number>('sid', this.index);

  /**
   * Параметр "Поле сортировки".
   * @type {AppCoreCommonPageParameter<string>}
   */
  paramSortField = new AppCoreCommonPageParameter<string>('sf', this.index);

  /**
   * Параметр "Направление сортировки".
   * @type {AppCoreCommonPageParameter<string>}
   */
  paramSortDirection = new AppCoreCommonPageParameter<string>('sd', this.index);

  /**
   * Параметр "Имя объекта, где хранятся данные сущности "ProductCategory".
   * @type {AppCoreCommonPageParameter<string>}
   */
  paramObjectProductCategoryName = new AppCoreCommonPageParameter<string>('obj-product-category-name', this.index);

  /**
   * Параметр "Идентификатор объекта, где хранятся данные сущности "ProductCategory".
   * @type {AppCoreCommonPageParameter<number>}
   */
  paramObjectProductCategoryId = new AppCoreCommonPageParameter<number>('obj-product-category-id', this.index);

  /**
   * Параметр "Строка идентификаторов объектов, где хранятся данные сущности "ProductCategory".
   * @type {AppCoreCommonPageParameter<string>}
   */
  paramObjectProductCategoryIdsString = new AppCoreCommonPageParameter<string>('obj-product-category-ids', this.index);

  /**
   * Параметр "Имя".
   * @type {AppCoreCommonPageParameter<string>}
   */
  paramName = new AppCoreCommonPageParameter<string>('name', this.index);

  /**
   * Параметр "Цена".
   * @type {AppCoreCommonPageParameter<number>}
   */
  paramPrice = new AppCoreCommonPageParameter<number>('price', this.index);

  
  /**
   * Параметр "Описание".
   * @type {AppCoreCommonPageParameter<string>}
   */
  paramDescription = new AppCoreCommonPageParameter<string>('description', this.index);

  /**
   * Параметр "Строка идентификаторов".
   * @type {AppCoreCommonPageParameter<string>}
   */
  paramIdsString = new AppCoreCommonPageParameter<string>('ids', this.index);

  /**
   * Конструктор.
   * @param {AppCoreSettings} appSettings Настройки.
   * @param {string} index Индекс.
   */
  constructor(appSettings: AppCoreSettings, index: string) {
    super(index);

    const {
      pageSize,
      sortDirection
    } = appSettings;

    this.paramIsDataRefreshed.value = false;
    this.paramPageNumber.value = 1;
    this.paramPageSize.value = pageSize;
    this.paramSelectedItemId.value = 0;
    this.paramSortDirection.value = sortDirection;
    this.paramSortField.value = 'id';
  }

  /**
   * Создать ввод для задания на получение списка.
   * @returns {AppModProductJobListGetInput} Ввод.
   */
  createJobListGetInput(): AppModProductJobListGetInput {
    return new AppModProductJobListGetInput(
      this.paramPageNumber.value,
      this.paramPageSize.value,
      this.paramSortField.value,
      this.paramSortDirection.value,
      this.paramObjectProductCategoryName.value,
      this.paramObjectProductCategoryId.value,
      this.paramObjectProductCategoryIdsString.value,
      this.paramName.value,
      this.paramIdsString.value,
      this.paramPrice.value,
      this.paramDescription.value
    );
  }
}
