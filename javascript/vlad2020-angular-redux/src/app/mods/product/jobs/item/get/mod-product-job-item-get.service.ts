// //Author Vlad Balkarov//vlad//

import {Injectable} from '@angular/core';
import {Observable} from 'rxjs';
import {catchError, map} from 'rxjs/operators';
import {appCoreExecutionMethod} from '@app/core/execution/core-execution-method';
import {AppCoreExecutionService} from '@app/core/execution/core-execution.service';
import {AppCoreHttpService} from '@app/core/http/core-http.service';
import {AppCoreLoggingService} from '@app/core/logging/core-logging.service';
import {AppCoreNavigationService} from '@app/core/navigation/core-navigation.service';
import {AppModProductJobItemGetInput} from './mod-product-job-item-get-input';
import {AppModProductJobItemGetResult} from './mod-product-job-item-get-result';

/** Мод "Product". Задания. Элемент. Получение. Сервис. */
@Injectable({
  providedIn: 'root'
})
export class AppModProductJobItemGetService {

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
   * @returns {Observable<AppModProductJobItemGetResult>} Результирующий поток.
   */
  execute$(
    logger: AppCoreLoggingService,
    input: AppModProductJobItemGetInput
  ): Observable<AppModProductJobItemGetResult> {
    const url = this.appNavigation.createAbsoluteUrlOfApi('product/item');

    const jobName = this.appExecution.createJobName(appCoreExecutionMethod.get, url, input);

    return this.appHttp.get<AppModProductJobItemGetResult>(url, input)
      .pipe(
        map(
          result => this.appExecution.onSuccess<AppModProductJobItemGetResult>(
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
