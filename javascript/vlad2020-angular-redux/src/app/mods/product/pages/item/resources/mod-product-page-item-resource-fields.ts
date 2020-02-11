// //Author Maxim Kuzmin//makc//

import {AppCoreLocalizationService} from '@app/core/localization/core-localization.service';
import {Subject} from 'rxjs';
import {takeUntil} from 'rxjs/operators';
import {AppModProductPageItemSettingFields} from '../settings/mod-product-page-item-setting-fields';

/** Мод "Product". Страницы. Элемент. Ресурсы. Поля. */
export class AppModProductPageItemResourceFields {

  /** Поле "Идентификатор". */
  fieldId = {
    label: ''
  };

  /** Поле "Имя". */
  fieldName = {
    label: '',
    placeholder: ''
  };

  /** Поле "Цена". */
  fieldPrice = {
    label: '',
    placeholder: ''
  };

  /** Поле "Описание". */
  fieldDescription = {
    label: '',
    placeholder: ''
  };

  /** Поле объект сущности "ProductFeature". */
  fieldObjectProductFeature = {
    label: '',
    placeholder: ''
  };

  /** Поле объект сущности "ProductCategory". */
  fieldObjectProductCategory = {
    label: '',
    placeholder: ''
  };

  /**
   * Конструктор.
   * @param {AppCoreLocalizationService} appLocalizer Локализатор.
   * @param {AppModProductPageItemSettingFields} settingFields Настройка кнопок.
   * @param {Subject<boolean>} unsubscribe$ Отказ от подписки.
   */
  constructor(
    appLocalizer: AppCoreLocalizationService,
    settingFields: AppModProductPageItemSettingFields,
    unsubscribe$: Subject<boolean>
  ) {
    const {
      fieldId,
      fieldName,
      fieldPrice,
      fieldDescription,
      fieldObjectProductFeature,
      fieldObjectProductCategory
    } = settingFields;

    appLocalizer.createTranslator(
      fieldId.labelResourceKey
    ).translate$().pipe(takeUntil(unsubscribe$)).subscribe(s => {
      this.fieldId.label = s;
    });

    appLocalizer.createTranslator(
      fieldName.labelResourceKey
    ).translate$().pipe(takeUntil(unsubscribe$)).subscribe(s => {
      this.fieldName.label = s;
    });

    appLocalizer.createTranslator(
      fieldName.placeholderResourceKey
    ).translate$().pipe(takeUntil(unsubscribe$)).subscribe(s => {
      this.fieldName.placeholder = s;
    });

    appLocalizer.createTranslator(
      fieldPrice.labelResourceKey
    ).translate$().pipe(takeUntil(unsubscribe$)).subscribe(s => {
      this.fieldPrice.label = s;
    });

    appLocalizer.createTranslator(
      fieldPrice.placeholderResourceKey
    ).translate$().pipe(takeUntil(unsubscribe$)).subscribe(s => {
      this.fieldPrice.placeholder = s;
    });

    appLocalizer.createTranslator(
      fieldDescription.labelResourceKey
    ).translate$().pipe(takeUntil(unsubscribe$)).subscribe(s => {
      this.fieldDescription.label = s;
    });

    appLocalizer.createTranslator(
      fieldDescription.placeholderResourceKey
    ).translate$().pipe(takeUntil(unsubscribe$)).subscribe(s => {
      this.fieldDescription.placeholder = s;
    });

    appLocalizer.createTranslator(
      fieldObjectProductFeature.labelResourceKey
    ).translate$().pipe(takeUntil(unsubscribe$)).subscribe(s => {
      this.fieldObjectProductFeature.label = s;
    });

    appLocalizer.createTranslator(
      fieldObjectProductFeature.placeholderResourceKey
    ).translate$().pipe(takeUntil(unsubscribe$)).subscribe(s => {
      this.fieldObjectProductFeature.placeholder = s;
    });

    appLocalizer.createTranslator(
      fieldObjectProductCategory.labelResourceKey
    ).translate$().pipe(takeUntil(unsubscribe$)).subscribe(s => {
      this.fieldObjectProductCategory.label = s;
    });

    appLocalizer.createTranslator(
      fieldObjectProductCategory.placeholderResourceKey
    ).translate$().pipe(takeUntil(unsubscribe$)).subscribe(s => {
      this.fieldObjectProductCategory.placeholder = s;
    });
  }
}
