// //Author Vlad Balkarov//vlad//

import {AppCoreCommonModJobListGetOutput} from '@app/core/common/mod/jobs/list/get/core-common-mod-job-list-get-output';
import {AppModProductJobItemGetOutput} from '../../item/get/mod-product-job-item-get-output';

/** Мод "Product". Задания. Список. Получение. Вывод. */
export interface AppModProductJobListGetOutput
  extends AppCoreCommonModJobListGetOutput<AppModProductJobItemGetOutput> {
}
