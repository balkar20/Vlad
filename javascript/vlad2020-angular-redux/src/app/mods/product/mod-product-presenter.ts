// //Author Vlad Balkarov//vlad//

import {AppModProductResources} from './mod-product-resources';
import {AppModProductModel} from './mod-product-model';

/** Мод "Product". Представитель. */
export class AppModProductPresenter {

  /**
   * Ресурсы.
   * @type {AppModProductResources}
   */
  get resources(): AppModProductResources {
    return this.model.resources;
  }

  /**
   * Конструктор.
   * @param {AppModProductModel} model Модель.
   */
  constructor(
    private model: AppModProductModel
  ) {
  }

  /** Обработчик события после инициализации представления. */
  onAfterViewInit() {
    this.model.onAfterViewInit();
  }

  /** Обработчик события уничтожения. */
  onDestroy() {
    this.model.onDestroy();
  }
}
