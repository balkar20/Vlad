// //Author Vlad Balkarov//vlad//

import {Injectable} from '@angular/core';
import {Observable} from 'rxjs';
import {catchError, map} from 'rxjs/operators';
import {appCoreExecutionMethod} from '@app/core/execution/core-execution-method';
import {AppCoreExecutionService} from '@app/core/execution/core-execution.service';
import {AppCoreHttpService} from '@app/core/http/core-http.service';
import {AppCoreLoggingService} from '@app/core/logging/core-logging.service';
import {AppCoreNavigationService} from '@app/core/navigation/core-navigation.service';
import {AppModProductJobOptionsProductFeatureGetResult} from './mod-product-job-options-product-feature-get-result';

/** Мод "Product". Задания. Варианты выбора. Сущность "ProductFeature". Получить. Сервис. */
@Injectable({
  providedIn: 'root'
})
export class AppModProductJobOptionsProductFeatureGetService {

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
   * @returns {Observable<AppModProductJobOptionsProductFeatureGetResult>} Результирующий поток.
   */
  execute$(
    logger: AppCoreLoggingService
  ): Observable<AppModProductJobOptionsProductFeatureGetResult> {
    const url = this.appNavigation.createAbsoluteUrlOfApi('product/options/product-feature');

    const jobName = this.appExecution.createJobName(appCoreExecutionMethod.get, url);

    return this.appHttp.get<AppModProductJobOptionsProductFeatureGetResult>(url)
      .pipe(
        map(
          result => this.appExecution.onSuccess<AppModProductJobOptionsProductFeatureGetResult>(
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
