// //Author Maxim Kuzmin//makc//

import {Action} from '@ngrx/store';
import {AppModProductJobItemGetResult} from '../../../../jobs/item/get/mod-product-job-item-get-result';
import {AppModProductJobOptionsProductFeatureGetResult} from '../../../../jobs/options/product-feature/get/mod-product-job-options-product-feature-get-result';
import {AppModProductJobOptionsProductCategoryGetResult} from '../../../../jobs/options/product-category/get/mod-product-job-options-product-category-get-result';
import {AppModProductPageItemEnumActions} from '../../enums/mod-product-page-item-enum-actions';

/** Мод "Product". Страницы. Элемент. Хранилище состояния. Действия. Успех загрузки. */
export class AppModProductPageItemStoreActionLoadSuccess implements Action {

  /** @inheritDoc */
  readonly type = AppModProductPageItemEnumActions.LoadSuccess;

  /**
   * Конструктор.
   * @param {AppModProductJobItemGetResult} jobItemGetResult
   * Результат выполнения задания на получение элемента.
   * @param {AppModProductJobOptionsProductFeatureGetResult} jobOptionsProductFeatureGetResult
   * Результат выполнения задания на получение вариантов выбора сущности "DummyManyToMany".
   * @param {AppModProductJobOptionsProductCategoryGetResult} jobOptionsProductCategoryGetResult
   * Результат выполнения задания на получение вариантов выбора сущности "ProductCategory".
   */
  constructor(
    public jobItemGetResult: AppModProductJobItemGetResult,
    public jobOptionsProductFeatureGetResult: AppModProductJobOptionsProductFeatureGetResult,
    public jobOptionsProductCategoryGetResult: AppModProductJobOptionsProductCategoryGetResult
  ) { }
}
