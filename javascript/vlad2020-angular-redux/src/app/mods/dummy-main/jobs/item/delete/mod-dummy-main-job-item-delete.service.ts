// //Author Vlad Balkarov//vlad//

import {Injectable} from '@angular/core';
import {Observable} from 'rxjs';
import {catchError, map} from 'rxjs/operators';
import {appCoreExecutionMethod} from '@app/core/execution/core-execution-method';
import {AppCoreExecutionResult} from '@app/core/execution/core-execution-result';
import {AppCoreExecutionService} from '@app/core/execution/core-execution.service';
import {AppCoreHttpService} from '@app/core/http/core-http.service';
import {AppCoreLoggingService} from '@app/core/logging/core-logging.service';
import {AppCoreNavigationService} from '@app/core/navigation/core-navigation.service';
import {AppModDummyMainJobItemGetInput} from '../get/mod-dummy-main-job-item-get-input';

/** Мод "DummyMain". Задания. Элемент. Удаление. Сервис. */
@Injectable({
  providedIn: 'root'
})
export class AppModDummyMainJobItemDeleteService {

  /**
   * Конструктор.
   * @param {AppCoreExecutionService} appExecution Выполнение.
   * @param {AppCoreHttpService} appHttp HTTP.
   * @param {AppCoreNavigationService} appNavigation Навигация.
   */
  constructor(
    private appExecution: AppCoreExecutionService,
    private appHttp: AppCoreHttpService,
    private appNavigation: AppCoreNavigationService
  ) { }

  /**
   * Выполнить.
   * @param {AppCoreLoggingService} logger Регистратор.
   * @param {AppModDummyMainJobItemGetInput} input Ввод.
   * @returns {Observable<AppCoreExecutionResult>} Результирующий поток.
   */
  execute$(
    logger: AppCoreLoggingService,
    input: AppModDummyMainJobItemGetInput
  ): Observable<AppCoreExecutionResult> {
    const url = this.appNavigation.createAbsoluteUrlOfApi('dummy-main/item');

    const jobName = this.appExecution.createJobName(appCoreExecutionMethod.delete, url, input);

    return this.appHttp.delete<AppCoreExecutionResult>(url, input)
      .pipe(
        map(
        result => this.appExecution.onSuccess<AppCoreExecutionResult>(
            jobName,
            result,
            logger
          )
        ),
        catchError(
          error => this.appExecution.onError$(
            jobName,
            error,
            logger
          )
        )
      );
  }
}
