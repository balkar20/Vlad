﻿//Author Vlad Balkarov//vlad//

using Vlad2020.Core.Base.Resources.Errors;
using Vlad2020.Core.Caching;
using Vlad2020.Core.Caching.Common.Client.Config;
using Vlad2020.Core.Caching.Clients;
using Vlad2020.Core.Caching.Resources.Errors;
using Vlad2020.Data.Base;
using Vlad2020.Mods.DummyMain.Base.Jobs.Item.Get;
using Vlad2020.Mods.DummyMain.Base.Jobs.Item.Update;
using Vlad2020.Mods.DummyMain.Base.Resources.Errors;
using Vlad2020.Mods.DummyMain.Base.Resources.Successes;
using System;
using System.Threading.Tasks;

namespace Vlad2020.Mods.DummyMain.Caching.Jobs.Item.Update
{
    /// <summary>
    /// Мод "DummyMain". Кэширование. Задания. Элемент. Обновление. Сервис.
    /// </summary>
    public class ModDummyMainCachingJobItemUpdateService : ModDummyMainBaseJobItemUpdateService
    {
        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="executable">Выполняемое.</param>
        /// <param name="coreBaseResourceErrors">Ядро. Основа. Ресурсы. Ошибки.</param>
        /// <param name="resourceSuccesses">Ресурсы успехов.</param>
        /// <param name="resourceErrors">Ресурсы ошибок.</param>
        /// <param name="dataBaseSettings">Настройки основы данных.</param>
        /// <param name="cacheSettings">Настройки кэширования.</param>        
        /// <param name="cache">Кэш.</param>    
        /// <param name="coreCachingResourceErrors">Ресурсы ошибок ядра кэширования.</param>
        public ModDummyMainCachingJobItemUpdateService(
            Func<ModDummyMainBaseJobItemGetOutput, Task<ModDummyMainBaseJobItemGetOutput>> executable,
            CoreBaseResourceErrors coreBaseResourceErrors,
            ModDummyMainBaseResourceSuccesses resourceSuccesses,
            ModDummyMainBaseResourceErrors resourceErrors,
            DataBaseSettings dataBaseSettings,
            ICoreCachingCommonClientConfigSettings cacheSettings,
            ICoreCachingCache cache,
            CoreCachingResourceErrors coreCachingResourceErrors
            ) : base(executable, coreBaseResourceErrors, resourceSuccesses, resourceErrors, dataBaseSettings)
        {
            if (cacheSettings.IsCachingEnabled)
            {
                var client = new CoreCachingClientWithChangeAndRead<ModDummyMainBaseJobItemGetOutput>(
                    "Item.Update",
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

                Executable = input => client.ChangeAndRead(() => executable.Invoke(input), tags);                
            }
        }

        #endregion Constructors
    }
}
