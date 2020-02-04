// //Author Maxim Kuzmin//makc//

import {AppCoreExecutionResultWithData} from '@app/core/execution/core-execution-result-with-data';
import {AppModProductJobItemGetOutput} from './mod-product-job-item-get-output';

/** Мод "Product". Задания. Элемент. Получение. Результат. */
export interface AppModProductJobItemGetResult
  extends AppCoreExecutionResultWithData<AppModProductJobItemGetOutput> {
}
