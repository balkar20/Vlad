// //Author Vlad Balkarov//vlad//

/** Ядро. Общее. Мод. Задания. Список. Получить. Вывод. */
export interface AppCoreCommonModJobOptionsGetOutputItem<TValue> {

  /**
   * Имя.
   * @type {string}
   */
  name: string;

  /**
   * Значение.
   * @type {TValue}
   */
  value: TValue;
}
