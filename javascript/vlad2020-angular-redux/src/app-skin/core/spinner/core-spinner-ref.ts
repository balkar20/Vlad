// //Author Vlad Balkarov//vlad//

import {OverlayRef} from '@angular/cdk/overlay';
import {AppCoreCommonDisposable} from '@app/core/common/core-common-disposable';

/** Ядро. Спиннер. Ссылка. */
export class AppSkinCoreSpinnerRef implements AppCoreCommonDisposable {

  /**
   * Конструктор.
   * @param {OverlayRef} overlayRef Ссылка на наложение.
   */
  constructor(
    private overlayRef: OverlayRef
  ) { }

  /** @inheritDoc */
  dispose() {
    this.overlayRef.dispose();
  }
}
