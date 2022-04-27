// //Author Vlad Balkarov//vlad//

import {AppDataObjectProduct} from '@app/data/objects/data-object-product';
import {AppDataObjectProductProductFeature} from '@app/data/objects/data-object-product-product-feature';
import {AppDataObjectProductFeature} from '@app/data/objects/data-object-product-feature';
import {AppDataObjectProductCategory} from '@app/data/objects/data-object-product-category';

/** Мод "Product". Задания. Элемент. Получение. Вывод. */
export interface AppModProductJobItemGetOutput {

  /**
   * Объект, где хранятся данные сущности "Product".
   * @type {?AppDataObjectProduct}
   */
  objectProduct?: AppDataObjectProduct;

  /**
   * Объект, где хранятся данные сущности "ProductFeature".
   * @type {?AppDataObjectProductFeature[]}
   */
  objectsProductFeature?: AppDataObjectProductFeature[];

  /**
   * Объект, где хранятся данные сущности "ProductProductFeature".
   * @type {?AppDataObjectProductProductProductFeature[]}
   */
  objectsProductProductFeature?: AppDataObjectProductProductFeature[];

  /**
   * Объект, где хранятся данные сущности "ProductCategory".
   * @type {?AppDataObjectProductCategory}
   */
  objectProductCategory?: AppDataObjectProductCategory;
}

/** Мод "Product". Задания. Элемент. Получение. Вывод. Создать. */
export function appModProductJobItemGetOutputCreate(): AppModProductJobItemGetOutput {
  return {} as AppModProductJobItemGetOutput;
}
