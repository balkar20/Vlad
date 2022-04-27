// //Author Vlad Balkarov//vlad//

import {Injectable} from '@angular/core';
import {Observable} from 'rxjs';
import {catchError, map} from 'rxjs/operators';
import {appCoreExecutionMethod} from '@app/core/execution/core-execution-method';
import {AppCoreExecutionService} from '@app/core/execution/core-execution.service';
import {AppCoreHttpService} from '@app/core/http/core-http.service';
import {AppCoreLoggingService} from '@app/core/logging/core-logging.service';
import {AppCoreNavigationService} from '@app/core/navigation/core-navigation.service';
import {AppModDummyMainJobOptionsDummyOneToManyGetResult} from './mod-dummy-main-job-options-dummy-one-to-many-get-result';

/** Мод "DummyMain". Задания. Варианты выбора. Сущность "DummyOneToMany". Получить. Сервис. */
@Injectable({
  providedIn: 'root'
})
export class AppModDummyMainJobOptionsDummyOneToManyGetService {

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
   * @returns {Observable<AppModDummyMainJobOptionsDummyOneToManyGetResult>} Результирующий поток.
   */
  execute$(
    logger: AppCoreLoggingService
  ): Observable<AppModDummyMainJobOptionsDummyOneToManyGetResult> {
    const url = this.appNavigation.createAbsoluteUrlOfApi('dummy-main/options/dummy-one-to-many');

    const jobName = this.appExecution.createJobName(appCoreExecutionMethod.get, url);

    return this.appHttp.get<AppModDummyMainJobOptionsDummyOneToManyGetResult>(url)
      .pipe(
        map(
          result => this.appExecution.onSuccess<AppModDummyMainJobOptionsDummyOneToManyGetResult>(
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
