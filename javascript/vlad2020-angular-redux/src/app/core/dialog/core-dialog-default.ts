// //Author Vlad Balkarov//vlad//

/** Ядро. Диалог. Умолчание. */
export abstract class AppCoreDialogDefault {

  /**
   * Предупредить.
   * @param {?string} message Сообщение с предупреждением.
   */
  abstract alert(message?: string);

  /**
   * Подтвердить.
   * @param {?string} message Сообщение, поясняющее, что нужно подтвердить.
   * @returns {boolean} Результат подтверждения.
   */
  abstract confirm(message?: string): boolean;
}
