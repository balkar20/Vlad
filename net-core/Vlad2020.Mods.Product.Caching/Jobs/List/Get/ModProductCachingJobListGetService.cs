//Author Vlad Balkarov//vlad//

using Vlad2020.Core.Base.Resources.Errors;
using Vlad2020.Core.Caching;
using Vlad2020.Core.Caching.Common.Client.Config;
using Vlad2020.Core.Caching.Clients;
using Vlad2020.Core.Caching.Resources.Errors;
using Vlad2020.Data.Base;
using Vlad2020.Mods.Product.Base.Jobs.List.Get;
using System;
using System.Threading.Tasks;

namespace Vlad2020.Mods.Product.Caching.Jobs.List.Get
{
    /// <summary>
    /// Мод "Product". Задания. Список. Получение. Сервис.
    /// </summary>
    public class ModProductCachingJobListGetService : ModProductBaseJobListGetService
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
        public ModProductCachingJobListGetService(
            Func<ModProductBaseJobListGetInput, Task<ModProductBaseJobListGetOutput>> executable,
            CoreBaseResourceErrors coreBaseResourceErrors,
            DataBaseSettings dataBaseSettings,
            ICoreCachingCommonClientConfigSettings cacheSettings,
            ICoreCachingCache cache,
            CoreCachingResourceErrors coreCachingResourceErrors           
            ) : base(executable, coreBaseResourceErrors)
        {
            if (cacheSettings.IsCachingEnabled)
            {
                var client = new CoreCachingClientWithChangeAndRead<ModProductBaseJobListGetOutput>(
                    "List.Get",
                    cacheSettings,
                    cache,
                    coreCachingResourceErrors
                    );

                var tags = new[]
                {
                    dataBaseSettings.Product.DbTableWithSchema
                };

                Executable = input =>
                {
                    var keys = new object[]
                    {
                        input.DataObjectProductCategoryName,
                        input.DataObjectProductCategoryIds,
                        input.DataObjectProductCategoryId,
                        input.DataName,
                        input.DataIds,
                        input.DataPageNumber,
                        input.DataPageSize,
                        input.DataSortField,
                        input.DataSortDirection
                    };

                    return client.Read(() => executable.Invoke(input), keys, tags);
                };
            }
        }

        #endregion Constructors
    }
}
