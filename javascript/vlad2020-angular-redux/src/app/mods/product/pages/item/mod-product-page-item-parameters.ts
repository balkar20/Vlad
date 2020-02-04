// //Author Maxim Kuzmin//makc//

import {AppCoreCommonPageParameter} from '@app/core/common/page/core-common-page-parameter';
import {AppCoreCommonPageParameters} from '@app/core/common/page/core-common-page-parameters';
import {AppModProductJobItemGetInput} from '@app/mods/product/jobs/item/get/mod-product-job-item-get-input';

/** Мод "Product". Страницы. Список. Параметры. */
export class AppModProductPageItemParameters extends AppCoreCommonPageParameters {

  /**
   * Параметр "Идентификатор".
   * @type {AppCoreCommonPageParameter<number>}
   */
  paramId = new AppCoreCommonPageParameter<number>('id', this.index);

  /**
   * Параметр "Имя".
   * @type {AppCoreCommonPageParameter<string>}
   */
  paramName = new AppCoreCommonPageParameter<string>('name', this.index);

  /**
   * Конструктор.
   * @param {number} index Индекс.
   */
  constructor(index: string) {
    super(index);
  }

  /**
   * Создать ввод для задания на получение элемента.
   * @returns {AppModProductJobItemGetInput} Ввод.
   */
  createJobItemGetInput(): AppModProductJobItemGetInput {
    return new AppModProductJobItemGetInput(
      this.paramId.value,
      this.paramName.value
    );
  }
}
