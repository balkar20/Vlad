//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Resources.Errors;
using Makc2020.Core.Caching;
using Makc2020.Core.Caching.Common.Client.Config;
using Makc2020.Core.Caching.Clients;
using Makc2020.Core.Caching.Resources.Errors;
using Makc2020.Data.Base;
using Makc2020.Mods.Product.Base.Jobs.Item.Delete;
using Makc2020.Mods.Product.Base.Jobs.Item.Get;
using Makc2020.Mods.Product.Base.Resources.Successes;
using System;
using System.Threading.Tasks;

namespace Makc2020.Mods.Product.Caching.Jobs.Item.Delete
{
    /// <summary>
    /// Мод "Product". Кэширование. Задания. Элемент. Удаление. Сервис.
    /// </summary>
    public class ModProductCachingJobItemDeleteService : ModProductBaseJobItemDeleteService
    {
        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="executable">Выполняемое.</param>
        /// <param name="coreBaseResourceErrors">Ядро. Основа. Ресурсы. Ошибки.</param>
        /// <param name="resourceSuccesses">Ресурсы успехов.</param>
        /// <param name="dataBaseSettings">Настройки основы данных.</param>
        /// <param name="cacheSettings">Настройки кэширования.</param>        
        /// <param name="cache">Кэш.</param>     
        /// <param name="coreCachingResourceErrors">Ресурсы ошибок ядра кэширования.</param>        
        public ModProductCachingJobItemDeleteService(
            Func<ModProductBaseJobItemGetInput, Task> executable,
            CoreBaseResourceErrors coreBaseResourceErrors,
            ModProductBaseResourceSuccesses resourceSuccesses,
            DataBaseSettings dataBaseSettings,
            ICoreCachingCommonClientConfigSettings cacheSettings,
            ICoreCachingCache cache,
            CoreCachingResourceErrors coreCachingResourceErrors            
            ) : base(executable, coreBaseResourceErrors, resourceSuccesses)
        {
            if (cacheSettings.IsCachingEnabled)
            {
                var client = new CoreCachingClientWithChange(cache, coreCachingResourceErrors);

                var tags = new[]
                {
                    dataBaseSettings.Product.DbTableWithSchema,
                    dataBaseSettings.ProductFeature.DbTableWithSchema,
                    dataBaseSettings.ProductCategory.DbTableWithSchema,
                };

                Executable = input => client.Change(() => executable.Invoke(input), tags);
            }
        }

        #endregion Constructors
    }
}