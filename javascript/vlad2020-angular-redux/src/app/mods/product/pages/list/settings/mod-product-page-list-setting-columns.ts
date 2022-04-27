// //Author Vlad Balkarov//vlad//

/** Мод "Product". Страницы. Список. Настройки. Столбцы. */
export class AppModProductPageListSettingColumns {

  /** Столбец "Действие". */
  columnAction = {
    name: 'action',
    labelResourceKey: '',
  };

  /** Столбец "Идентификатор". */
  columnId = {
    name: 'id',
    labelResourceKey: 'Идентификатор',
    placeholderResourceKey: 'Введите идентификатор'
  };

  /** Столбец "Имя". */
  columnName = {
    name: 'name',
    labelResourceKey: 'Имя',
    placeholderResourceKey: 'Введите имя'
  };

  /** Столбец "Имя". */
  columnPrice = {
    name: 'price',
    labelResourceKey: 'Цена',
    placeholderResourceKey: 'Введите Цену'
  };

  /** Столбец "Описание". */
  columnDescription = {
    name: 'description',
    labelResourceKey: 'Описание',
    placeholderResourceKey: 'Введите Описание'
  };
}
