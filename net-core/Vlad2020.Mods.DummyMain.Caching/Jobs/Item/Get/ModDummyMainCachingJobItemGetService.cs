﻿//Author Vlad Balkarov//vlad//

using Vlad2020.Core.Base.Resources.Errors;
using Vlad2020.Core.Caching;
using Vlad2020.Core.Caching.Common.Client.Config;
using Vlad2020.Core.Caching.Clients;
using Vlad2020.Core.Caching.Resources.Errors;
using Vlad2020.Data.Base;
using Vlad2020.Mods.DummyMain.Base.Jobs.Item.Get;
using System;
using System.Threading.Tasks;

namespace Vlad2020.Mods.DummyMain.Caching.Jobs.Item.Get
{
    /// <summary>
    /// Мод "DummyMain". Кэширование. Задания. Элемент. Получение. Сервис.
    /// </summary>
    public class ModDummyMainCachingJobItemGetService : ModDummyMainBaseJobItemGetService
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
        public ModDummyMainCachingJobItemGetService(
            Func<ModDummyMainBaseJobItemGetInput, Task<ModDummyMainBaseJobItemGetOutput>> executable,
            CoreBaseResourceErrors coreBaseResourceErrors,
            DataBaseSettings dataBaseSettings,
            ICoreCachingCommonClientConfigSettings cacheSettings,
            ICoreCachingCache cache,
            CoreCachingResourceErrors coreCachingResourceErrors            
            ) : base(executable, coreBaseResourceErrors)
        {
            if (cacheSettings.IsCachingEnabled)
            {
                var client = new CoreCachingClientWithChangeAndRead<ModDummyMainBaseJobItemGetOutput>(
                    "Item.Get",
                    cacheSettings,
                    cache,
                    coreCachingResourceErrors
                    );

                var tags = new[]
                {
                    dataBaseSettings.DummyMain.DbTableWithSchema,
                    dataBaseSettings.DummyManyToMany.DbTableWithSchema,
                    dataBaseSettings.DummyMainDummyManyToMany.DbTableWithSchema,
                    dataBaseSettings.DummyOneToMany.DbTableWithSchema
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
