//Author Maxim Kuzmin//makc//

using Vlad2020.Core.Base.Execution;
using Vlad2020.Core.Web;
using Vlad2020.Mods.Product.Base.Common.Jobs.Option.List.Get;
using Vlad2020.Mods.Product.Base.Jobs.Item.Get;
using Vlad2020.Mods.Product.Base.Jobs.List.Get;
using Vlad2020.Mods.Product.Caching.Jobs.Item.Delete;
using Vlad2020.Mods.Product.Caching.Jobs.Item.Get;
using Vlad2020.Mods.Product.Caching.Jobs.Item.Insert;
using Vlad2020.Mods.Product.Caching.Jobs.Item.Update;
using Vlad2020.Mods.Product.Caching.Jobs.List.Get;
using Vlad2020.Mods.Product.Caching.Jobs.Options.ProductFeature.Get;
using Vlad2020.Mods.Product.Caching.Jobs.Options.ProductCategory.Get;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Vlad2020.Mods.Product.Web.Api
{
    /// <summary>
    /// Мод "Product". Веб. API. Модель.
    /// </summary>
    public class ModProductWebApiModel : CoreWebModel
    {
        #region Properties

        private ModProductCachingJobItemDeleteService AppJobItemDelete { get; set; }

        private ModProductCachingJobItemGetService AppJobItemGet { get; set; }

        private ModProductCachingJobItemInsertService AppJobItemInsert { get; set; }

        private ModProductCachingJobItemUpdateService AppJobItemUpdate { get; set; }

        private ModProductCachingJobListGetService AppJobListGet { get; set; }

        private ModProductCachingJobOptionsProductFeatureGetService AppJobOptionProductFeatureListGet { get; set; }

        private ModProductCachingJobOptionsProductCategoryGetService AppJobOptionProductCategoryListGet { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>        
        /// <param name="appJobItemDelete">Задание на удаление элемента.</param>
        /// <param name="appJobItemGet">Задание на получение элемента.</param>
        /// <param name="appJobItemInsert">Задание на вставку элемента.</param>
        /// <param name="appJobItemUpdate">Задание на обновление элемента.</param>
        /// <param name="appJobListGet">Задание на получение списка.</param>
        /// <param name="appJobOptionProductFeatureListGet">
        /// Задание на получение вариантов выбора сущности "ProductFeature".
        /// </param>
        /// <param name="appJobOptionProductCategoryListGet">
        /// Задание на получение вариантов выбора сущности "ProductCategory".
        /// </param>
        /// <param name="extLogger">Регистратор.</param>
        public ModProductWebApiModel(
            ModProductCachingJobItemDeleteService appJobItemDelete,
            ModProductCachingJobItemGetService appJobItemGet,
            ModProductCachingJobItemInsertService appJobItemInsert,
            ModProductCachingJobItemUpdateService appJobItemUpdate,
            ModProductCachingJobListGetService appJobListGet,
            ModProductCachingJobOptionsProductFeatureGetService appJobOptionProductFeatureListGet,
            ModProductCachingJobOptionsProductCategoryGetService appJobOptionProductCategoryListGet,
            ILogger<ModProductWebApiController> extLogger
            )
            : base(extLogger)
        {
            AppJobItemDelete = appJobItemDelete;
            AppJobItemGet = appJobItemGet;
            AppJobItemInsert = appJobItemInsert;
            AppJobItemUpdate = appJobItemUpdate;
            AppJobListGet = appJobListGet;
            AppJobOptionProductFeatureListGet = appJobOptionProductFeatureListGet;
            AppJobOptionProductCategoryListGet = appJobOptionProductCategoryListGet;
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        /// Построить действие "Список. Получение".
        /// </summary>
        /// <param name="input">Ввод.</param>
        /// <returns>Функции действия.</returns>
        public (
            Func<Task<ModProductBaseJobListGetOutput>> execute,
            Action<ModProductBaseJobListGetResult> onSuccess,
            Action<Exception, ModProductBaseJobListGetResult> onError
            ) BuildActionListGet(ModProductBaseJobListGetInput input)
        {
            var job = AppJobListGet;

            Task<ModProductBaseJobListGetOutput> execute() => job.Execute(input);

            void onSuccess(ModProductBaseJobListGetResult result)
            {
                job.OnSuccess(ExtLogger, result, input);
            }

            void onError(Exception ex, ModProductBaseJobListGetResult result)
            {
                job.OnError(ex, ExtLogger, result);
            }

            return (execute, onSuccess, onError);
        }

        /// <summary>
        /// Построить действие "Элемент. Получение".
        /// </summary>
        /// <param name="input">Ввод.</param>
        /// <returns>Функции действия.</returns>
        public (
            Func<Task<ModProductBaseJobItemGetOutput>> execute,
            Action<ModProductBaseJobItemGetResult> onSuccess,
            Action<Exception, ModProductBaseJobItemGetResult> onError
            ) BuildActionItemGet(ModProductBaseJobItemGetInput input)
        {
            var job = AppJobItemGet;

            Task<ModProductBaseJobItemGetOutput> execute() => job.Execute(input);

            void onSuccess(ModProductBaseJobItemGetResult result)
            {
                job.OnSuccess(ExtLogger, result, input);
            }

            void onError(Exception ex, ModProductBaseJobItemGetResult result)
            {
                job.OnError(ex, ExtLogger, result);
            }

            return (execute, onSuccess, onError);
        }

        /// <summary>
        /// Построить действие "Вариант выбора. Сущность "ProductFeature". Список. Получение".
        /// </summary>
        /// <param name="input">Ввод.</param>
        /// <returns>Функции действия.</returns>
        public (
            Func<Task<ModProductBaseCommonJobOptionListGetOutput>> execute,
            Action<ModProductBaseCommonJobOptionListGetResult> onSuccess,
            Action<Exception, ModProductBaseCommonJobOptionListGetResult> onError
            ) BuildActionOptionProductFeatureListGet()
        {
            var job = AppJobOptionProductFeatureListGet;

            Task<ModProductBaseCommonJobOptionListGetOutput> execute() => job.Execute();

            void onSuccess(ModProductBaseCommonJobOptionListGetResult result)
            {
                job.OnSuccess(ExtLogger, result);
            }

            void onError(Exception ex, ModProductBaseCommonJobOptionListGetResult result)
            {
                job.OnError(ex, ExtLogger, result);
            }

            return (execute, onSuccess, onError);
        }

        /// <summary>
        /// Построить действие "Вариант выбора. Сущность "ProductCategory". Список. Получение".
        /// </summary>
        /// <param name="input">Ввод.</param>
        /// <returns>Функции действия.</returns>
        public (
            Func<Task<ModProductBaseCommonJobOptionListGetOutput>> execute,
            Action<ModProductBaseCommonJobOptionListGetResult> onSuccess,
            Action<Exception, ModProductBaseCommonJobOptionListGetResult> onError
            ) BuildActionOptionProductCategoryListGet()
        {
            var job = AppJobOptionProductCategoryListGet;

            Task<ModProductBaseCommonJobOptionListGetOutput> execute() => job.Execute();

            void onSuccess(ModProductBaseCommonJobOptionListGetResult result)
            {
                job.OnSuccess(ExtLogger, result);
            }

            void onError(Exception ex, ModProductBaseCommonJobOptionListGetResult result)
            {
                job.OnError(ex, ExtLogger, result);
            }

            return (execute, onSuccess, onError);
        }

        /// <summary>
        /// Построить действие "Элемент. Вставка".
        /// </summary>
        /// <param name="input">Ввод.</param>
        /// <returns>Функции действия.</returns>
        public (
            Func<Task<ModProductBaseJobItemGetOutput>> execute,
            Action<ModProductBaseJobItemGetResult> onSuccess,
            Action<Exception, ModProductBaseJobItemGetResult> onError
            ) BuildActionItemInsert(ModProductBaseJobItemGetOutput input)
        {
            var job = AppJobItemInsert;

            Task<ModProductBaseJobItemGetOutput> execute() => job.Execute(input);

            void onSuccess(ModProductBaseJobItemGetResult result)
            {
                job.OnSuccess(ExtLogger, result, input);
            }

            void onError(Exception ex, ModProductBaseJobItemGetResult result)
            {
                job.OnError(ex, ExtLogger, result);
            }

            return (execute, onSuccess, onError);
        }

        /// <summary>
        /// Построить действие "Элемент. Обновление".
        /// </summary>
        /// <param name="input">Ввод.</param>
        /// <returns>Функции действия.</returns>
        public (
            Func<Task<ModProductBaseJobItemGetOutput>> execute,
            Action<ModProductBaseJobItemGetResult> onSuccess,
            Action<Exception, ModProductBaseJobItemGetResult> onError
            ) BuildActionItemUpdate(ModProductBaseJobItemGetOutput input)
        {
            var job = AppJobItemUpdate;

            Task<ModProductBaseJobItemGetOutput> execute() => job.Execute(input);

            void onSuccess(ModProductBaseJobItemGetResult result)
            {
                job.OnSuccess(ExtLogger, result, input);
            }

            void onError(Exception ex, ModProductBaseJobItemGetResult result)
            {
                job.OnError(ex, ExtLogger, result);
            }

            return (execute, onSuccess, onError);
        }

        /// <summary>
        /// Построить действие "Элемент. Удаление".
        /// </summary>
        /// <param name="input">Ввод.</param>
        /// <returns>Функции действия.</returns>
        public (
            Func<Task> execute,
            Action<CoreBaseExecutionResult> onSuccess,
            Action<Exception, CoreBaseExecutionResult> onError
            ) BuildActionItemDelete(ModProductBaseJobItemGetInput input)
        {
            var job = AppJobItemDelete;

            Task execute() => job.Execute(input);

            void onSuccess(CoreBaseExecutionResult result)
            {
                job.OnSuccess(ExtLogger, result, input);
            }

            void onError(Exception ex, CoreBaseExecutionResult result)
            {
                job.OnError(ex, ExtLogger, result);
            }

            return (execute, onSuccess, onError);
        }

        #endregion Public methods    
    }
}