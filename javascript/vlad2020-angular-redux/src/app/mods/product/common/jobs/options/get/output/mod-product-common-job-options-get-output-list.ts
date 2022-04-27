// //Author Vlad Balkarov//vlad//

import {AppCoreCommonModJobOptionsGetOutputList} from '@app/core/common/mod/jobs/options/get/output/core-common-mod-job-options-get-output-list';
import {AppModProductCommonJobOptionsGetOutputItem} from './mod-product-common-job-options-get-output-item';

/** Мод "Product". Общее. Задания. Варианты выбора. Получение. Вывод. Список. */
export interface AppModProductCommonJobOptionsGetOutputList
  extends AppCoreCommonModJobOptionsGetOutputList<AppModProductCommonJobOptionsGetOutputItem> {
}

/** Мод "Product". Общее. Задания. Варианты выбора. Получение. Вывод. Список. Создать. */
export function appModProductCommonJobOptionsGetOutputListCreate(): AppModProductCommonJobOptionsGetOutputList {
  return {
    items: []
  } as AppModProductCommonJobOptionsGetOutputList;
}
