// //Author Maxim Kuzmin//makc//

import {Injectable} from '@angular/core';
import {Observable} from 'rxjs';
import {catchError, map} from 'rxjs/operators';
import {appCoreExecutionMethod} from '@app/core/execution/core-execution-method';
import {AppCoreExecutionService} from '@app/core/execution/core-execution.service';
import {AppCoreHttpService} from '@app/core/http/core-http.service';
import {AppCoreLoggingService} from '@app/core/logging/core-logging.service';
import {AppCoreNavigationService} from '@app/core/navigation/core-navigation.service';
import {AppModProductJobListGetInput} from './mod-product-job-list-get-input';
import {AppModProductJobListGetResult} from './mod-product-job-list-get-result';

/** Мод "Product". Задания. Список. Получить. Сервис. */
@Injectable({
  providedIn: 'root'
})
export class AppModProductJobListGetService {

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
   * @param {AppModProductJobItemGetInput} input Ввод.
   * @returns {Observable<AppModProductJobListGetResult>} Результирующий поток.
   */
  execute$(
    logger: AppCoreLoggingService,
    input: AppModProductJobListGetInput
  ): Observable<AppModProductJobListGetResult> {
    const url = this.appNavigation.createAbsoluteUrlOfApi('product/list');

    const jobName = this.appExecution.createJobName(appCoreExecutionMethod.get, url, input);

    return this.appHttp.get<AppModProductJobListGetResult>(url, input)
      .pipe(
        map(
          result => this.appExecution.onSuccess<AppModProductJobListGetResult>(
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
