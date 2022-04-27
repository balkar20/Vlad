//Author Vlad Balkarov//vlad//

using Vlad2020.Core.Base.Resources.Errors;
using Vlad2020.Core.Caching;
using Vlad2020.Core.Caching.Common.Client.Config;
using Vlad2020.Core.Caching.Clients;
using Vlad2020.Core.Caching.Resources.Errors;
using Vlad2020.Data.Base;
using Vlad2020.Mods.DummyMain.Base.Jobs.Item.Delete;
using Vlad2020.Mods.DummyMain.Base.Jobs.Item.Get;
using Vlad2020.Mods.DummyMain.Base.Resources.Successes;
using System;
using System.Threading.Tasks;

namespace Vlad2020.Mods.DummyMain.Caching.Jobs.Item.Delete
{
    /// <summary>
    /// Мод "DummyMain". Кэширование. Задания. Элемент. Удаление. Сервис.
    /// </summary>
    public class ModDummyMainCachingJobItemDeleteService : ModDummyMainBaseJobItemDeleteService
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
        public ModDummyMainCachingJobItemDeleteService(
            Func<ModDummyMainBaseJobItemGetInput, Task> executable,
            CoreBaseResourceErrors coreBaseResourceErrors,
            ModDummyMainBaseResourceSuccesses resourceSuccesses,
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
                    dataBaseSettings.DummyMain.DbTableWithSchema,
                    dataBaseSettings.DummyManyToMany.DbTableWithSchema,
                    dataBaseSettings.DummyMainDummyManyToMany.DbTableWithSchema,
                    dataBaseSettings.DummyOneToMany.DbTableWithSchema
                };

                Executable = input => client.Change(() => executable.Invoke(input), tags);
            }
        }

        #endregion Constructors
    }
}