// //Author Vlad Balkarov//vlad//

import {AppCoreExecutionResultWithData} from '@app/core/execution/core-execution-result-with-data';
import {AppModProductJobListGetOutput} from './mod-product-job-list-get-output';

/** Мод "Product". Задания. Список. Получение. Результат. */
export interface AppModProductJobListGetResult
  extends AppCoreExecutionResultWithData<AppModProductJobListGetOutput> {
}
