// //Author Maxim Kuzmin//makc//

/** Мод "Product". Страницы. Список. Данные. Элемент. */
export class AppModProductPageListDataItem {

  /**
   * Конструктор.
   * @param id Идентификатор.
   * @param name Имя.
   * @param price Имя.
   * @param description Имя.
   */
  constructor(
    public id: number,
    public name: string, 
    public price: number,
    public description: string
  ) { }
}
