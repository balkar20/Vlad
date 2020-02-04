// //Author Maxim Kuzmin//makc//

import {appModProductConfigFullPath} from '@app/mods/product/mod-product-config';

/** Мод "Product". Страницы. Элемент. Путь. */
const appModProductPageItemConfigPath = 'item';

/** Мод "Product". Страницы. Элемент. Конфигурация. Индекс. */
export const appModProductPageItemConfigIndex = '1';

/** Мод "Product". Страницы. Элемент. Конфигурация. Маршрут. Путь. */
export const appModProductPageItemConfigRoutePath = appModProductPageItemConfigPath;

/** Мод "Product". Страницы. Элемент. Конфигурация. Полный путь. */
const appModProductPageItemConfigFullPath =
  `${appModProductConfigFullPath}/${appModProductPageItemConfigPath}`;

/** Мод "Product". Страницы. Элемент. Редактирование. Конфигурация. Ключ. */
export const appModProductPageItemConfigKey = 'ModProductPageItem';

// Create

/** Мод "Product". Страницы. Элемент. Создание. Конфигурация. Путь. */
const appModProductPageItemCreateConfigPath = 'create';

/** Мод "Product". Страницы. Элемент. Создание. Конфигурация. Маршрут. Путь. */
export const appModProductPageItemCreateConfigRoutePath = appModProductPageItemCreateConfigPath;

/** Мод "Product". Страницы. Элемент. Создание. Конфигурация. Полный путь. */
export const appModProductPageItemCreateConfigFullPath =
  `${appModProductPageItemConfigFullPath}/${appModProductPageItemCreateConfigPath}`;

/** Мод "Product". Страницы. Элемент. Создание. Конфигурация. Ключ. */
export const appModProductPageItemCreateConfigKey = 'ModProductPageItemCreate';

/** Мод "Product". Страницы. Элемент. Создание. Конфигурация. Заголовок. Ресурс. Ключ. */
export const appModProductPageItemCreateConfigTitleResourceKey = 'Создать';

// Edit

/** Мод "Product". Страницы. Элемент. Редактирование. Конфигурация. Путь. */
const appModProductPageItemEditConfigPath = 'edit';

/** Мод "Product". Страницы. Элемент. Редактирование. Конфигурация. Маршрут. Путь. */
export const appModProductPageItemEditConfigRoutePath =
  `${appModProductPageItemEditConfigPath}/:id${appModProductPageItemConfigIndex}`;

/** Мод "Product". Страницы. Элемент. Редактирование. Конфигурация. Полный путь. */
export const appModProductPageItemEditConfigFullPath =
  `${appModProductPageItemConfigFullPath}/${appModProductPageItemEditConfigPath}`;

/** Мод "Product". Страницы. Элемент. Редактирование. Конфигурация. Ключ. */
export const appModProductPageItemEditConfigKey = 'ModProductPageItemEdit';

/** Мод "Product". Страницы. Элемент. Редактирование. Конфигурация. Заголовок. Ресурс. Ключ. */
export const appModProductPageItemEditConfigTitleResourceKey = 'Изменить';

// View

/** Мод "Product". Страницы. Элемент. Просмотр. Конфигурация. Путь. */
const appModProductPageItemViewConfigPath = 'view';

/** Мод "Product". Страницы. Элемент. Просмотр. Конфигурация. Маршрут. Путь. */
export const appModProductPageItemViewConfigRoutePath =
  `${appModProductPageItemViewConfigPath}/:id${appModProductPageItemConfigIndex}`;

/** Мод "Product". Страницы. Элемент. Просмотр. Конфигурация. Полный путь. */
export const appModProductPageItemViewConfigFullPath =
  `${appModProductPageItemConfigFullPath}/${appModProductPageItemViewConfigPath}`;

/** Мод "Product". Страницы. Элемент. Просмотр. Конфигурация. Ключ. */
export const appModProductPageItemViewConfigKey = 'ModProductPageItemView';

/** Мод "Product". Страницы. Элемент. Просмотр. Конфигурация. Заголовок. Ресурс. Ключ. */
export const appModProductPageItemViewConfigTitleResourceKey = 'Просмотреть';
