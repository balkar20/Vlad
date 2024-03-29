// //Author Vlad Balkarov//vlad//

import {AppCoreCommonState} from '@app/core/common/core-common-state';
import {AppHostPartAuthEnumActions} from './enums/host-part-auth-enum-actions';
import {AppHostPartAuthUser} from './host-part-auth-user';

/** Хост. Часть "Auth". Состояние. */
export class AppHostPartAuthState extends AppCoreCommonState<AppHostPartAuthEnumActions> {

  /**
   * Текущий пользователь.
   * @type {AppHostPartAuthUser}
   */
  currentUser: AppHostPartAuthUser;

  /**
   * Признак успешного входа в систему.
   * @type {boolean}
   */
  isLoggedIn: boolean;

  /**
   * URL входа в систему.
   * @type {string}
   */
  logonUrl: string;

  /**
   * URL для перенаправления просле входа в систему.
   * @type {string}
   */
  redirectUrl: string;

  /**
   * URL регистрации.
   * @type {string}
   */
  registerUrl: string;
}
