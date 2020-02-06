//Author Maxim Kuzmin//makc//

using Vlad2020.Core.Base.Resources.Errors;
using Vlad2020.Core.Caching;
using Vlad2020.Core.Caching.Clients;
using Vlad2020.Core.Caching.Common.Client.Config;
using Vlad2020.Core.Caching.Resources.Errors;
using Vlad2020.Data.Base;
using Vlad2020.Mods.Product.Base.Common.Jobs.Option.List.Get;
using System;
using System.Threading.Tasks;
using Vlad2020.Mods.Product.Base.Jobs.Option.ProductFeature.List.Get;

namespace Vlad2020.Mods.Product.Caching.Jobs.Options.ProductFeature.Get
{
    /// <summary>
    /// Мод "Product". Задания. Варианты выбора. Сущность "ProductFeature". Получение. Сервис.
    /// </summary>
    public class ModProductCachingJobOptionsProductFeatureGetService :
        ModProductBaseJobOptionProductFeatureGetListService
    {
        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="executable">Выполняемое.</param>
        /// <param name="coreBaseResourceErrors">Ядро. Основа. Ресурсы. Ошибки.</param>
        /// <param name="dataBaseSettings">Настройки основы данных.</param>
        /// <param name="cacheSettings">Настройки кэширования.</param>        
        /// <param name="cache">Кэш.</param>      
        /// <param name="coreCachingResourceErrors">Ресурсы ошибок ядра кэширования.</param>
        public ModProductCachingJobOptionsProductFeatureGetService(
            Func<Task<ModProductBaseCommonJobOptionListGetOutput>> executable,
            CoreBaseResourceErrors coreBaseResourceErrors,
            DataBaseSettings dataBaseSettings,
            ICoreCachingCommonClientConfigSettings cacheSettings,
            ICoreCachingCache cache,
            CoreCachingResourceErrors coreCachingResourceErrors
            ) : base(executable, coreBaseResourceErrors)
        {
            if (cacheSettings.IsCachingEnabled)
            {
                var client = new CoreCachingClientWithChangeAndRead<ModProductBaseCommonJobOptionListGetOutput>(
                    "Options.ProductFeature.Get",
                    cacheSettings,
                    cache,
                    coreCachingResourceErrors
                    );

                var tags = new[]
                {
                    dataBaseSettings.ProductFeature.DbTableWithSchema
                };

                Executable = () =>
                {
                    return client.Read(() => executable.Invoke(), null, tags);
                };
            }
        }

        #endregion Constructors
    }
}
