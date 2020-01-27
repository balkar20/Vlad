//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Resources.Errors;
using Makc2020.Core.Caching;
using Makc2020.Core.Caching.Common.Client.Config;
using Makc2020.Core.Caching.Clients;
using Makc2020.Core.Caching.Resources.Errors;
using Makc2020.Data.Base;
using Makc2020.Mods.Product.Base.Jobs.Item.Get;
using System;
using System.Threading.Tasks;

namespace Makc2020.Mods.Product.Caching.Jobs.Item.Get
{
    /// <summary>
    /// Мод "Product". Кэширование. Задания. Элемент. Получение. Сервис.
    /// </summary>
    public class ModProductCachingJobItemGetService : ModProductBaseJobItemGetService
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
        public ModProductCachingJobItemGetService(
            Func<ModProductBaseJobItemGetInput, Task<ModProductBaseJobItemGetOutput>> executable,
            CoreBaseResourceErrors coreBaseResourceErrors,
            DataBaseSettings dataBaseSettings,
            ICoreCachingCommonClientConfigSettings cacheSettings,
            ICoreCachingCache cache,
            CoreCachingResourceErrors coreCachingResourceErrors            
            ) : base(executable, coreBaseResourceErrors)
        {
            if (cacheSettings.IsCachingEnabled)
            {
                var client = new CoreCachingClientWithChangeAndRead<ModProductBaseJobItemGetOutput>(
                    "Item.Get",
                    cacheSettings,
                    cache,
                    coreCachingResourceErrors
                    );

                var tags = new[]
                {
                    dataBaseSettings.Product.DbTableWithSchema,
                    dataBaseSettings.ProductFeature.DbTableWithSchema,
                    dataBaseSettings.ProductCategory.DbTableWithSchema,
                    dataBaseSettings.ProductProductFeature.DbTableWithSchema
                };

                Executable = input =>
                {
                    var keys = new object[]
                    {
                        input.DataId,
                        input.DataName
                    };

                    return client.Read(() => executable.Invoke(input), keys, tags);
                };
            }
        }

        #endregion Constructors
    }
}
