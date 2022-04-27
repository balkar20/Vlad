// //Author Vlad Balkarov//vlad//

import {AbstractControl, FormGroup} from '@angular/forms';
import {AppModProductJobItemGetOutput} from '../../jobs/item/get/mod-product-job-item-get-output';
import {
  AppModProductCommonJobOptionsGetOutputList,
  appModProductCommonJobOptionsGetOutputListCreate
} from '../../common/jobs/options/get/output/mod-product-common-job-options-get-output-list';
import {AppModProductPageItemSettingErrors} from './settings/mod-product-page-item-setting-errors';
import {AppModProductPageItemSettingFields} from './settings/mod-product-page-item-setting-fields';

/** Мод "Product". Страницы. Элемент. Вид. */
export abstract class AppModProductPageItemView {

  /**
   * Данные.
   * @type {AppModProductJobItemGetOutput}
   */
  data: AppModProductJobItemGetOutput;

  /**
   * Группа полей формы.
   * @type {FormGroup}
   */
  formGroup: FormGroup;

  /**
   * Варианты выбора сущности "ProductFeature".
   * @type {AppModProductCommonJobOptionsGetOutputList}
   */
  optionsProductFeature: AppModProductCommonJobOptionsGetOutputList;

  /**
   * Варианты выбора сущности "ProductCategory".
   * @type {AppModProductCommonJobOptionsGetOutputList}
   */
  optionsProductCategory: AppModProductCommonJobOptionsGetOutputList;

  /**
   * Признак того, что данные загружены.
   * @type {boolean}
   */
  isDataLoaded = false;

  /**
   * Признак того, что изменение данных разрешено.
   * @type {boolean}
   */
  isDataChangeAllowed = false;

  /**
   * Сообщения об ошибках отклика.
   * @type {string[]}
   */
  responseErrorMessages: string[] = [];

  /**
   * Сообщения об успехах отклика.
   * @type {string[]}
   */
  responseSuccessMessages: string[] = [];

  /**
   * Значение свойства "disabled" кнопки отправки.
   * @type {boolean}
   */
  get buttonSubmitDisabled(): boolean {
    return !this.formGroup.valid;
  }

  /**
   * Поле ввода идентификатора.
   * @type {AbstractControl}
   */
  get fieldId(): AbstractControl {
    return this.formGroup.get(this.settingFields.fieldId.name);
  }

  /**
   * Поле ввода имени.
   * @type {AbstractControl}
   */
  get fieldName(): AbstractControl {
    return this.formGroup.get(this.settingFields.fieldName.name);
  }

  /**
   * Признак того, что ошибка валидации обязательности ввода имени видима.
   * @type {boolean}
   */
  get fieldNameErrorRequiredVisible() {
    const control = this.fieldName;

    return control.dirty && control.hasError(this.settingErrors.errorRequired.code);
  }
  
  /**
   * Поле ввода цены.
   * @type {AbstractControl}
   */
  get fieldPrice(): AbstractControl {
    return this.formGroup.get(this.settingFields.fieldPrice.name);
  }

  /**
   * Признак того, что ошибка валидации обязательности ввода цены видима.
   * @type {boolean}
   */
  get fieldPriceErrorRequiredVisible() {
    const control = this.fieldPrice;

    return control.dirty && control.hasError(this.settingErrors.errorRequired.code);
  }
  
  /**
   * Поле ввода описания.
   * @type {AbstractControl}
   */
  get fieldDescription(): AbstractControl {
    return this.formGroup.get(this.settingFields.fieldDescription.name);
  }

  /**
   * Признак того, что ошибка валидации обязательности ввода описания видима.
   * @type {boolean}
   */
  get fieldDescriptionErrorRequiredVisible() {
    const control = this.fieldDescription;

    return control.dirty && control.hasError(this.settingErrors.errorRequired.code);
  }

  /**
   * Поле ввода объекта сущности "ProductCategory".
   * @type {AbstractControl}
   */
  get fieldObjectProductCategory(): AbstractControl {
    return this.formGroup.get(this.settingFields.fieldObjectProductCategory.name);
  }

  /**
   * Признак того, что ошибка валидации обязательности ввода объекта сущности "ProductCategory" видима.
   * @type {boolean}
   */
  get fieldObjectProductCategoryErrorRequiredVisible() {
    const control = this.fieldObjectProductCategory;

    return control.dirty && control.hasError(this.settingErrors.errorRequired.code);
  }

  /**
   * Конструктор.
   * @param {AppModProductPageItemSettingErrors} settingErrors Настройка ошибок.
   * @param {AppModProductPageItemSettingFields} settingFields Настройка полей.
   */
  protected constructor(
    private settingErrors: AppModProductPageItemSettingErrors,
    private settingFields: AppModProductPageItemSettingFields
  ) {
    this.loadOptionsProductFeature();
    this.loadOptionsProductCategory();
  }

  /**
   * Построить.
   * @param {FormGroup} formGroup Группа полей формы.
   */
  build(
    formGroup: FormGroup
  ) {
    this.formGroup = formGroup;
  }

  /** Спрятать спиннер загрузки. */
  abstract hideLoadingSpinner();

  /** Спрятать спиннер обновления. */
  abstract hideRefreshSpinner();

  /**
   * Инициализировать спиннер загрузки.
   * @param {() => void} callback Функция обратного вызова.
   */
  abstract initLoadingSpinner(callback: () => void);

  /** Инициализировать спиннер обновления. */
  abstract initRefreshSpinner();

  /**
   * Загрузить сообщения об ошибках отклика.
   * @param {string[]} messages Сообщения.
   */
  loadResponseErrorMessages(messages: string[]) {
    if (messages && messages.length > 0) {
      if (!this.responseErrorMessages) {
        this.responseErrorMessages = [];
      }

      this.responseErrorMessages = this.responseErrorMessages.concat(messages);
    } else {
      this.responseErrorMessages = messages;
    }
  }

  /**
   * Загрузить сообщения об успехах отклика.
   * @param {string[]} messages Сообщения.
   */
  loadResponseSuccessMessages(messages: string[]) {
    if (messages && messages.length > 0) {
      if (!this.responseSuccessMessages) {
        this.responseSuccessMessages = [];
      }

      this.responseSuccessMessages = this.responseSuccessMessages.concat(messages);
    } else {
      this.responseSuccessMessages = messages;
    }
  }

  /**
   * Загрузить варианты выбора сущности "ProductFeature".
   * @param {AppModProductCommonJobOptionsGetOutputList} data Данные.
   */
  loadOptionsProductFeature(data?: AppModProductCommonJobOptionsGetOutputList) {
    this.optionsProductFeature = data
      ? data
      : appModProductCommonJobOptionsGetOutputListCreate();
  }

  /**
   * Загрузить варианты выбора сущности "ProductCategory".
   * @param {AppModProductCommonJobOptionsGetOutputList} data Данные.
   */
  loadOptionsProductCategory(data?: AppModProductCommonJobOptionsGetOutputList) {
    this.optionsProductCategory = data
      ? data
      : appModProductCommonJobOptionsGetOutputListCreate();
  }

  /** Сбросить форму. */
  abstract resetForm();

  /** Показать спиннер загрузки. */
  abstract showLoadingSpinner();

  /** Показать спиннер обновления. */
  abstract showRefreshSpinner();
}
