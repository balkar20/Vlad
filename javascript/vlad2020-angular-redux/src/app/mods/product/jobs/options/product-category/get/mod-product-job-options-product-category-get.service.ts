// //Author Vlad Balkarov//vlad//

import {Injectable} from '@angular/core';
import {Observable} from 'rxjs';
import {catchError, map} from 'rxjs/operators';
import {appCoreExecutionMethod} from '@app/core/execution/core-execution-method';
import {AppCoreExecutionService} from '@app/core/execution/core-execution.service';
import {AppCoreHttpService} from '@app/core/http/core-http.service';
import {AppCoreLoggingService} from '@app/core/logging/core-logging.service';
import {AppCoreNavigationService} from '@app/core/navigation/core-navigation.service';
import {AppModProductJobOptionsProductCategoryGetResult} from './mod-product-job-options-product-category-get-result';

/** Мод "Product". Задания. Варианты выбора. Сущность "ProductCategory". Получить. Сервис. */
@Injectable({
  providedIn: 'root'
})
export class AppModProductJobOptionsProductCategoryGetService {

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
   * @returns {Observable<AppModProductJobOptionsProductCategoryGetResult>} Результирующий поток.
   */
  execute$(
    logger: AppCoreLoggingService
  ): Observable<AppModProductJobOptionsProductCategoryGetResult> {
    const url = this.appNavigation.createAbsoluteUrlOfApi('product/options/product-category');

    const jobName = this.appExecution.createJobName(appCoreExecutionMethod.get, url);

    return this.appHttp.get<AppModProductJobOptionsProductCategoryGetResult>(url)
      .pipe(
        map(
          result => this.appExecution.onSuccess<AppModProductJobOptionsProductCategoryGetResult>(
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
