// //Author Vlad Balkarov//vlad//

import {Injectable} from '@angular/core';
import {appCoreExecutionMethod} from '@app/core/execution/core-execution-method';
import {AppCoreAuthTypeOidcService} from '@app/core/auth/types/oidc/core-auth-type-oidc.service';
import {AppCoreExecutionService} from '@app/core/execution/core-execution.service';
import {AppCoreLoggingService} from '@app/core/logging/core-logging.service';

/** Ядро. Аутентификация. Типы. OIDC. Задания. Вход в систему. Сервис. */
@Injectable({
  providedIn: 'root'
})
export class AppCoreAuthTypeOidcJobLoginService {

  /**
   * Конструктор.
   * @param {AppCoreAuthTypeOidcService} appAuthTypeOidc Аутентификация типа OIDC.
   * @param {AppCoreExecutionService} appExecution Выполнение.
   */
  constructor(
    private appAuthTypeOidc: AppCoreAuthTypeOidcService,
    private appExecution: AppCoreExecutionService
  ) {
  }

  /**
   * Выполнить.
   * @param {AppCoreLoggingService} logger Регистратор.
   */
  execute(
    logger: AppCoreLoggingService
  ) {
    const url = 'AppCoreAuthTypeOidcService.login';

    const jobName = this.appExecution.createJobName(appCoreExecutionMethod.get, url);

    try {
      this.appAuthTypeOidc.login();
    } catch (error) {
      this.appExecution.onError(
        jobName,
        error,
        logger
      );
    }
  }
}
