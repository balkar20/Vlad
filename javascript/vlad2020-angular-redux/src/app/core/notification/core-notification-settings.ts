// //Author Vlad Balkarov//vlad//

/** Ядро. Извещение. Настройки. */
export class AppCoreNotificationSettings {

  /**
   * Кнопка "Закрыть.".
   * @type {string}
   */
  buttonClose = {
    titleResourceKey: 'Закрыть'
  };

  /**
   * Конструктор.
   * @param {string} titleResourceKey Заголовок.
   */
  constructor(
    public titleResourceKey: string
  ) {
  }
}
