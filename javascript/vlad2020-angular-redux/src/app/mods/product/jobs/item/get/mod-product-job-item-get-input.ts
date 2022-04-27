// //Author Vlad Balkarov//vlad//

import {AppCoreCommonModJobItemGetInput} from '@app/core/common/mod/jobs/item/get/core-common-mod-job-item-get-input';

/** Мод "Product". Задания. Элемент. Получение. Ввод. */
export class AppModProductJobItemGetInput extends AppCoreCommonModJobItemGetInput {

  /**
   * Имя.
   * @type {?string}
   */
  dataName?: string;

  /**
   * Цена.
   * @type {?number}
   */
  dataPrice?: number;

  /**
   * Описание.
   * @type {?string}
   */
  dataDescription?: string;

  /**
   * Признак предназначенности обновления.
   * @type {boolean}
   */
  get isForUpdate(): boolean {
    return !!(this.dataId > 0 || this.dataName
      ||this.dataPrice > 0 || this.dataDescription);
  }

  /**
   * Конструктор.
   * @param {?number} dataId Идентификатор данных.
   * @param {?string} dataName Имя данных.
   * @param {?number} dataPrice Идентификатор данных.
   * @param {?string} dataDescription Имя данных.
   */
  constructor(dataId?: number, dataName?: string, dataPrice?: number, dataDescription?: string) {
    super(dataId);
    console.log("AppModProductJobItemGetInput constructor");
    console.log("AppModProductJobItemGetInput id:" + dataId);
    console.log("AppModProductJobItemGetInput price:" + dataPrice);
    if (dataName) {
      this.dataName = dataName;
    }

    if (dataPrice) {
      this.dataPrice = dataPrice;
    }

    if (dataDescription) {
      this.dataDescription = dataDescription;
    }
  }

  /**
   * Равно другому.
   * @param {AppModProductPageItemParameters} other Другое.
   * @returns {boolean} Результат сравнения с другим.
   */
  equals(other: AppModProductJobItemGetInput): boolean {
    return other
      && this.dataId === other.dataId
      && this.dataName === other.dataName
      && this.dataPrice === other.dataPrice
      && this.dataDescription === other.dataDescription;
  }
}
