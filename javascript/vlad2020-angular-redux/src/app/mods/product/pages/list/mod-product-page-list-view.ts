// //Author Maxim Kuzmin//makc//

import {FormControl} from '@angular/forms';
import {AppModProductPageListDataItem} from './data/mod-product-page-list-data-item';
import {AppModProductJobListGetInput} from '@app/mods/product/jobs/list/get/mod-product-job-list-get-input';
import {AppModProductPageListParameters} from '@app/mods/product/pages/list/mod-product-page-list-parameters';

/** Мод "Product". Страницы. Список. Вид. */
export abstract class AppModProductPageListView {
  /**
   * Элемент управления для ввода имени.
   * @type {FormControl}
   */
  fieldName = new FormControl();

  /**
   * Признак того, что данные загружены.
   * @type {boolean}
   */
  isDataLoaded = false;

  /**
   * Признак того, что данные обновлены.
   * @type {boolean}
   */
  isDataRefreshed = false;

  /**
   * Признак того, что удаление элемента началось.
   * @param {boolean}
   */
  isItemDeleteStarted = false;

  /**
   * Размер страницы.
   * @type {number}
   */
  pageSize = 0;

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
   * Общее количество записей.
   * @type {number}
   */
  totalCount = 0;

  /**
   * Получить номер страницы.
   * @return {number}
   */
  abstract getPageNumber(): number;

  /**
   * Получить размер страницы.
   * @return {number}
   */
  abstract getPageSize(): number;

  /**
   * Получить идентификатор выбранного элемента.
   * @returns {number} Идентификатор выбранного элемента.
   */
  abstract getSelectedItemId(): number;

  /**
   * Получить направление сортировки.
   * @return {string}
   */
  abstract getSortDirection(): string;

  /**
   * Получить поле сортировки.
   * @return {string}
   */
  abstract getSortField(): string;

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
   * Загрузить данные.
   * @param {AppModProductPageListDataItem[]} data Данные.
   * @param {AppModProductPageListParameters} parameters Параметры.
   */
  abstract loadData(
    data: AppModProductPageListDataItem[],
    parameters: AppModProductPageListParameters
  );

  /**
   * Установить номер страницы.
   * @param {number} value Значение.
   */
  abstract setPageNumber(value: number);

  /**
   * Установить идентификатор выбранного элемента.
   * @param {number} value Значение.
   */
  abstract setSelectedItemId(value: number);

  /** Показать спиннер загрузки. */
  abstract showLoadingSpinner();

  /** Показать спиннер обновления. */
  abstract showRefreshSpinner();

  /**
   * Подписаться на событие выбора строки.
   * @param {() => void} callback Функция обратного вызова.
   */
  abstract subscribeOnRowSelect(callback: () => void);

  /**
   * Подписаться на событие изменения сортировки.
   * @param {() => void} callback Функция обратного вызова.
   */
  abstract subscribeOnSortChange(callback: () => void);

  /**
   * Подписаться на событие изменения сортировки или страницы.
   * @param {() => void} callback Функция обратного вызова.
   */
  abstract subscribeOnSortOrPageChange(callback: () => void);
}
