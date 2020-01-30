﻿//Author Maxim Kuzmin//makc//

using Vlad2020.Core.Caching;
using Vlad2020.Core.Web;
using Vlad2020.Mods.DummyMain.Caching;
using Vlad2020.Root.Apps.Api.Base;
using Microsoft.Extensions.Logging;

namespace Vlad2020.Root.Apps.Api.Web
{
    /// <summary>
    /// Корень. Приложение "API". Веб. Контекст.
    /// </summary>
    /// <typeparam name="TModules">Тип модулей.</typeparam>
    public class RootAppApiWebContext<TModules> : RootAppApiBaseContext<TModules>
        where TModules: RootAppApiWebModules
    {
        #region Properties

        /// <summary>
        /// Ядро. Кэширование.
        /// </summary>
        public CoreCachingContext CoreCaching => Modules.CoreCaching.Context;

        /// <summary>
        /// Мод "DummyMain". Кэширование.
        /// </summary>
        public ModDummyMainCachingContext ModDummyMainCaching => Modules.ModDummyMainCaching.Context;

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="modules">Модули.</param>
        /// <param name="logger">Регистратор.</param>
        public RootAppApiWebContext(TModules modules, ILogger logger)
            : base(modules, logger)
        {
        }

        #endregion Constructors
    }
}