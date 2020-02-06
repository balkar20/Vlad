//Author Maxim Kuzmin//makc//

using Vlad2020.Core.Base.Resources.Errors;
using Vlad2020.Core.Caching;
using Vlad2020.Core.Caching.Common.Client.Config;
using Vlad2020.Core.Caching.Resources.Errors;
using Vlad2020.Data.Base;
using Vlad2020.Mods.Product.Base;
using Vlad2020.Mods.Product.Base.Resources.Errors;
using Vlad2020.Mods.Product.Base.Resources.Successes;
using Vlad2020.Mods.Product.Caching.Jobs.Item.Delete;
using Vlad2020.Mods.Product.Caching.Jobs.Item.Get;
using Vlad2020.Mods.Product.Caching.Jobs.Item.Insert;
using Vlad2020.Mods.Product.Caching.Jobs.Item.Update;
using Vlad2020.Mods.Product.Caching.Jobs.List.Get;
using Vlad2020.Mods.Product.Caching.Jobs.Options.ProductFeature.Get;
using Vlad2020.Mods.Product.Caching.Jobs.Options.ProductCategory.Get;

namespace Vlad2020.Mods.Product.Caching
{
    /// <summary>
    /// Мод "Product". Кэширование. Задания.
    /// </summary>
    public class ModProductCachingJobs
    {
        #region Properties

        /// <summary>
        /// Задание на удаление элемента.
        /// </summary>
        public ModProductCachingJobItemDeleteService JobItemDelete { get; private set; }

        /// <summary>
        /// Задание на получение элемента.
        /// </summary>
        public ModProductCachingJobItemGetService JobItemGet { get; private set; }

        /// <summary>
        /// Задание на вставку элемента.
        /// </summary>
        public ModProductCachingJobItemInsertService JobItemInsert { get; private set; }

        /// <summary>
        /// Задание на обновление элемента.
        /// </summary>
        public ModProductCachingJobItemUpdateService JobItemUpdate { get; private set; }

        /// <summary>
        /// Задание на получение списка.
        /// </summary>
        public ModProductCachingJobListGetService JobListGet { get; private set; }

        /// <summary>
        /// Задание на получение вариантов выбора сущности "ProductFeature".
        /// </summary>
        public ModProductCachingJobOptionsProductFeatureGetService JobOptionsProductFeatureGet { get; private set; }

        /// <summary>
        /// Задание на получение вариантов выбора сущности "ProductCategory".
        /// </summary>
        public ModProductCachingJobOptionsProductCategoryGetService JobOptionsProductCategoryGet { get; private set; }

        #endregion Properties

        #region Constructor

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="coreBaseResourceErrors">Ядро. Основа. Ресурсы. Ошибки.</param>
        /// <param name="cache">Кэш.</param>
        /// <param name="cacheSettings">Настройки кэша.</param>
        /// <param name="coreCachingResourceErrors">Ядро. Кэширование. Ресурсы. Ошибки.</param>
        /// <param name="dataBaseSettings">Данные. Основа. Настройки.</param>
        /// <param name="resourceSuccesses">Ресурсы. Успехи.</param>
        /// <param name="resourceErrors">Ресурсы. Ошибки.</param>
        /// <param name="service">Сервис.</param>
        public ModProductCachingJobs(            
            CoreBaseResourceErrors coreBaseResourceErrors,
            ICoreCachingCache cache,
            ICoreCachingCommonClientConfigSettings cacheSettings,            
            CoreCachingResourceErrors coreCachingResourceErrors,
            DataBaseSettings dataBaseSettings,
            ModProductBaseResourceSuccesses resourceSuccesses,
            ModProductBaseResourceErrors resourceErrors,
            ModProductBaseService service
            )
        {
            JobItemDelete = new ModProductCachingJobItemDeleteService(
                service.DeleteItem,
                coreBaseResourceErrors,
                resourceSuccesses,
                dataBaseSettings,
                cacheSettings,
                cache,
                coreCachingResourceErrors
                );

            JobItemGet = new ModProductCachingJobItemGetService(
                service.GetItem,
                coreBaseResourceErrors,
                dataBaseSettings,
                cacheSettings,
                cache,
                coreCachingResourceErrors
                );

            JobItemInsert = new ModProductCachingJobItemInsertService(
                service.SaveItem,
                coreBaseResourceErrors,
                resourceSuccesses,
                resourceErrors,
                dataBaseSettings,
                cacheSettings,
                cache,
                coreCachingResourceErrors
                );

            JobItemUpdate = new ModProductCachingJobItemUpdateService(
                service.SaveItem,
                coreBaseResourceErrors,
                resourceSuccesses,
                resourceErrors,
                dataBaseSettings,
                cacheSettings,
                cache,
                coreCachingResourceErrors
                );

            JobListGet = new ModProductCachingJobListGetService(
                service.GetList,
                coreBaseResourceErrors,
                dataBaseSettings,
                cacheSettings,
                cache,
                coreCachingResourceErrors
                );

            JobOptionsProductFeatureGet = new ModProductCachingJobOptionsProductFeatureGetService(
                service.GetOptionsProductFeature,
                coreBaseResourceErrors,
                dataBaseSettings,
                cacheSettings,
                cache,
                coreCachingResourceErrors
                );

            JobOptionsProductCategoryGet = new ModProductCachingJobOptionsProductCategoryGetService(
                service.GetOptionsProductCategory,
                coreBaseResourceErrors,
                dataBaseSettings,
                cacheSettings,
                cache,
                coreCachingResourceErrors
                );
        }

        #endregion Constructor
    }
}
