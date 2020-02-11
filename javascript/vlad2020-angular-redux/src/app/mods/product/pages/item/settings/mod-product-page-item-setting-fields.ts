// //Author Maxim Kuzmin//makc//

/** Мод "Product". Страницы. Элемент. Настройки. Поля. */
export class AppModProductPageItemSettingFields {

  /** Поле "Идентификатор". */
  fieldId = {
    name: 'id',
    labelResourceKey: 'Идентификатор'
  };

  /** Поле "Имя". */
  fieldName = {
    name: 'name',
    labelResourceKey: 'Имя',
    placeholderResourceKey: 'Введите имя'
  };

  /** Поле "Цена". */
  fieldPrice = {
    name: 'price',
    labelResourceKey: 'Цена',
    placeholderResourceKey: 'Введите Цену'
  };

  /** Поле "Описание". */
  fieldDescription = {
    name: 'description',
    labelResourceKey: 'Описание',
    placeholderResourceKey: 'Введите Описание'
  };

  /** Поле объект сущности "ProductFeature". */
  fieldObjectProductFeature = {
    name: 'objectProductFeature',
    labelResourceKey: 'Объект сущности "ProductFeature"',
    placeholderResourceKey: 'Выберите объект'
  };

  /** Поле объект сущности "ProductCategory". */
  fieldObjectProductCategory = {
    name: 'objectProductCategory',
    labelResourceKey: 'Объект сущности "ProductCategory"',
    placeholderResourceKey: 'Выберите объект'
  };
}
