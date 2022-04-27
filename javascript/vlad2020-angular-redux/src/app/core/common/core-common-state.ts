// //Author Vlad Balkarov//vlad//

/**
 * Ядро. Общее. Состояние.
 * @param <TAction> Тип действия.
 */
export abstract class AppCoreCommonState<TAction> {

  /**
   * Действие.
   * @type {TAction}
   */
  action: TAction;
}
