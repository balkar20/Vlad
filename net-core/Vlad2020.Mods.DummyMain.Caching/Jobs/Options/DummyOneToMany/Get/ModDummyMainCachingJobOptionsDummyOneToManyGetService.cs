//Author Vlad Balkarov//vlad//

using Vlad2020.Core.Base.Resources.Errors;
using Vlad2020.Core.Caching;
using Vlad2020.Core.Caching.Clients;
using Vlad2020.Core.Caching.Common.Client.Config;
using Vlad2020.Core.Caching.Resources.Errors;
using Vlad2020.Data.Base;
using Vlad2020.Mods.DummyMain.Base.Common.Jobs.Option.List.Get;
using Vlad2020.Mods.DummyMain.Base.Jobs.Option.DummyOneToMany.List.Get;
using System;
using System.Threading.Tasks;

namespace Vlad2020.Mods.DummyMain.Caching.Jobs.Options.DummyOneToMany.Get
{
    /// <summary>
    /// Мод "DummyMain". Задания. Варианты выбора. Сущность "DummyOneToMany". Получение. Сервис.
    /// </summary>
    public class ModDummyMainCachingJobOptionsDummyOneToManyGetService :
        ModDummyMainBaseJobOptionDummyOneToManyListGetService
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
        public ModDummyMainCachingJobOptionsDummyOneToManyGetService(
            Func<Task<ModDummyMainBaseCommonJobOptionListGetOutput>> executable,
            CoreBaseResourceErrors coreBaseResourceErrors,
            DataBaseSettings dataBaseSettings,
            ICoreCachingCommonClientConfigSettings cacheSettings,
            ICoreCachingCache cache,
            CoreCachingResourceErrors coreCachingResourceErrors
            ) : base(executable, coreBaseResourceErrors)
        {
            if (cacheSettings.IsCachingEnabled)
            {
                var client = new CoreCachingClientWithChangeAndRead<ModDummyMainBaseCommonJobOptionListGetOutput>(
                    "Options.DummyOneToMany.Get",
                    cacheSettings,
                    cache,
                    coreCachingResourceErrors
                    );

                var tags = new[]
                {
                    dataBaseSettings.DummyOneToMany.DbTableWithSchema
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
