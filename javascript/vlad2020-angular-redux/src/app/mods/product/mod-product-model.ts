// //Author Maxim Kuzmin//makc//

import {AppCoreCommonTitlable} from '@app/core/common/core-common-titlable';
import {AppCoreLocalizationService} from '@app/core/localization/core-localization.service';
import {AppCoreTitleService} from '@app/core/title/core-title.service';
import {AppModProductResources} from './mod-product-resources';
import {AppModProductService} from './mod-product.service';

/** Мод "Product". Модель. */
export class AppModProductModel extends AppCoreCommonTitlable {

  /**
   * Ресурсы.
   * @type {AppModProductResources}
   */
  resources: AppModProductResources;

  /**
   * Конструктор.
   * @param {AppCoreLocalizationService} appLocalizer Локализатор.
   * @param {AppModProductService} appModProduct Страница.
   * @param {AppCoreTitleService} appTitle Заголовок.
   */
  constructor(
    public appLocalizer: AppCoreLocalizationService,
    public appModProduct: AppModProductService,
    appTitle: AppCoreTitleService
  ) {
    super(
      appTitle
    );

    this.resources = new AppModProductResources(
      this.appLocalizer,
      this.appModProduct.settings,
      this.unsubscribe$
    );
  }

  /** Обработчик события после инициализации представления. */
  onAfterViewInit() {
    this.executeTitleActionItemAdd();
  }

  private executeTitleActionItemAdd() {
    this.appTitle.executeActionItemAdd(
      this.appModProduct.settings.titleResourceKey,
      this.resources.titleTranslated$,
      this.unsubscribe$
    );

    this.titleItemsCount = 1;
  }
}
