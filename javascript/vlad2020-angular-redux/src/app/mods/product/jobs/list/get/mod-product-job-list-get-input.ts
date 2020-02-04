// //Author Maxim Kuzmin//makc//

import {AppCoreCommonModJobListGetInput} from '@app/core/common/mod/jobs/list/get/core-common-mod-job-list-get-input';

/** Мод "Product". Задания. Список. Получение. Ввод. */
export class AppModProductJobListGetInput extends AppCoreCommonModJobListGetInput {

  /**
   * Имя объекта, где хранятся данные сущности "ProductCategory".
   * @type {?string}
   */
  dataObjectProductCategoryName?: string;

  /**
   * Идентификатор объекта, где хранятся данные сущности "ProductCategory".
   * @type {?number}
   */
  dataObjectProductCategoryId?: number;

  /**
   * Строка идентификаторов объектов, где хранятся данные сущности "ProductCategory".
   * @type {?string}
   */
  dataObjectProductCategoryIdsString?: string;

  /**
   * Имя.
   * @type {?string}
   */
  dataName?: string;

  /**
   * Строка идентификаторов.
   * @type {?string}
   */
  dataIdsString?: string;

  /**
   * Конструктор.
   * @param {?number} dataPageNumber Номер страницы данных.
   * @param {?number} dataPageSize Размер страницы данных.
   * @param {?string} dataSortField Поле сортировки данных.
   * @param {?string} dataSortDirection Направление сортировки данных.
   * @param {?string} dataObjectProductCategoryName Имя объекта, где хранятся данные сущности "ProductCategory".
   * @param {?number} dataObjectProductCategoryId Идентификатор объекта, где хранятся данные сущности "ProductCategory".
   * @param {?string} dataObjectProductCategoryIdsString Строка идентификаторов объектов, где хранятся данные сущности "ProductCategory".
   * @param {?string} dataName Имя данных.
   * @param {?string} dataIdsString Строка идентификаторов данных.
   */
  constructor(
    dataPageNumber?: number,
    dataPageSize?: number,
    dataSortField?: string,
    dataSortDirection?: string,
    dataObjectProductCategoryName?: string,
    dataObjectProductCategoryId?: number,
    dataObjectProductCategoryIdsString?: string,
    dataName?: string,
    dataIdsString?: string
  ) {
    super(
      dataPageNumber,
      dataPageSize,
      dataSortField,
      dataSortDirection
    );

    if (dataObjectProductCategoryName) {
      this.dataObjectProductCategoryName = dataObjectProductCategoryName;
    }

    if (dataObjectProductCategoryId) {
      this.dataObjectProductCategoryId = dataObjectProductCategoryId;
    }

    if (dataObjectProductCategoryIdsString) {
      this.dataObjectProductCategoryIdsString = dataObjectProductCategoryIdsString;
    }

    if (dataName) {
      this.dataName = dataName;
    }

    if (dataIdsString) {
      this.dataIdsString = dataIdsString;
    }
  }

  /**
   * Равно другому.
   * @param {AppModProductJobListGetInput} other Другое.
   * @returns {boolean} Результат сравнения с другим.
   */
  equals(other: AppModProductJobListGetInput): boolean {
    return other
      && this.dataIdsString === other.dataIdsString
      && this.dataName === other.dataName
      && this.dataObjectProductCategoryId === other.dataObjectProductCategoryId
      && this.dataObjectProductCategoryIdsString === other.dataObjectProductCategoryIdsString
      && this.dataObjectProductCategoryName === other.dataObjectProductCategoryName
      && this.dataPageNumber === other.dataPageNumber
      && this.dataPageSize === other.dataPageSize
      && this.dataSortDirection === other.dataSortDirection
      && this.dataSortField === other.dataSortField;
  }
}
