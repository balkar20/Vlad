// //Author Vlad Balkarov//vlad//

/** Приложение. Вид. */
export abstract class AppView {

  /**
   * CSS-класс.
   * @type {any}
   */
  cssClass;

  /**
   * Установить режим администрирпования.
   * @param {boolean} isAdminEnabled Признак включения режима администрирования.
   */
  abstract setAdminMode(isAdminEnabled: boolean);
}
