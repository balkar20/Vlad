// //Author Maxim Kuzmin//makc//

import {AppCoreCommonState} from '@app/core/common/core-common-state';
import {AppCoreExecutionResult} from '@app/core/execution/core-execution-result';
import {AppModProductJobItemGetInput} from '../../jobs/item/get/mod-product-job-item-get-input';
import {AppModProductJobListGetInput} from '../../jobs/list/get/mod-product-job-list-get-input';
import {AppModProductPageListEnumActions} from './enums/mod-product-page-list-enum-actions';
import {AppModProductJobListGetResult} from '@app/mods/product/jobs/list/get/mod-product-job-list-get-result';

/** Мод "Product". Страницы. Список. Состояние. */
export class AppModProductPageListState extends AppCoreCommonState<AppModProductPageListEnumActions> {

  /**
   * Ввод задания на получение элемента.
   * @type {AppModProductJobItemGetInput}
   */
  jobItemGetInput: AppModProductJobItemGetInput;

  /**
   * Результат выполнения задания на получение списка.
   * @type {AppCoreExecutionResult}
   */
  jobItemDeleteResult: AppCoreExecutionResult;

  /**
   * Ввод задания на получение списка.
   * @type {AppModProductJobListGetInput}
   */
  jobListGetInput: AppModProductJobListGetInput;

  /**
   * Результат выполнения задания на получение списка.
   * @type {AppModProductJobListGetResult}
   */
  jobListGetResult: AppModProductJobListGetResult;
}
