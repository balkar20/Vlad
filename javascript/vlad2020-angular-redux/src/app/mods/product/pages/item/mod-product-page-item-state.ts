// //Author Vlad Balkarov//vlad//

import {AppCoreCommonState} from '@app/core/common/core-common-state';
import {AppModProductJobItemGetInput} from '../../jobs/item/get/mod-product-job-item-get-input';
import {AppModProductJobItemGetOutput} from '../../jobs/item/get/mod-product-job-item-get-output';
import {AppModProductJobItemGetResult} from '../../jobs/item/get/mod-product-job-item-get-result';
import {AppModProductPageItemEnumActions} from './enums/mod-product-page-item-enum-actions';
import {AppModProductJobOptionsProductFeatureGetResult} from '../../jobs/options/product-feature/get/mod-product-job-options-product-feature-get-result';
import {AppModProductJobOptionsProductCategoryGetResult} from '../../jobs/options/product-category/get/mod-product-job-options-product-category-get-result';

/** Мод "Product". Страницы. Элемент. Состояние. */
export class AppModProductPageItemState extends AppCoreCommonState<AppModProductPageItemEnumActions> {

  /**
   * Ввод задания на получение элемента.
   * @type {AppModProductJobItemGetInput}
   */
  jobItemGetInput: AppModProductJobItemGetInput;

  /**
   * Выход задания на получение элемента.
   * @type {AppModProductJobItemGetOutput}
   */
  jobItemGetOutput: AppModProductJobItemGetOutput;

  /**
   * Результат выполнения задания на получение элемента.
   * @type {AppModProductJobItemGetResult}
   */
  jobItemGetResult: AppModProductJobItemGetResult;

  /**
   * Результат выполнения задания на получение вариантов выбора сущности "ProductFeature".
   * @type {AppModProductJobOptionsProductFeatureGetResult}
   */
  jobOptionsProductFeatureGetResult: AppModProductJobOptionsProductFeatureGetResult;

  /**
   * Результат выполнения задания на получение вариантов выбора сущности "ProductCategory".
   * @type {AppModProductJobOptionsProductCategoryGetResult}
   */
  jobOptionsProductCategoryGetResult: AppModProductJobOptionsProductCategoryGetResult;
}
