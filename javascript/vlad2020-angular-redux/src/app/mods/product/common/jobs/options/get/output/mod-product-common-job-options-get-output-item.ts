// //Author Vlad Balkarov//vlad//

import {AppCoreCommonModJobOptionsGetOutputItem} from '@app/core/common/mod/jobs/options/get/output/core-common-mod-job-options-get-output-item';

/** Мод "Product". Общее. Задания. Варианты выбора. Получение. Вывод. Элемент. */
export interface AppModProductCommonJobOptionsGetOutputItem
  extends AppCoreCommonModJobOptionsGetOutputItem<number> {
}

/** Мод "Product". Общее. Задания. Варианты выбора. Получение. Вывод. Элемент. Создать. */
export function appModProductCommonJobOptionsGetOutputItemCreate(): AppModProductCommonJobOptionsGetOutputItem {
  return {} as AppModProductCommonJobOptionsGetOutputItem;
}
