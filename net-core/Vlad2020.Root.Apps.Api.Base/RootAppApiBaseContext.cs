﻿//Author Maxim Kuzmin//makc//

using Vlad2020.Mods.Auth.Base;
using Vlad2020.Mods.DummyMain.Base;
using Vlad2020.Root.Base;
using Microsoft.Extensions.Logging;

namespace Vlad2020.Root.Apps.Api.Base
{
    /// <summary>
    /// Корень. Приложение "API". Основа. Контекст.
    /// </summary>
    /// <typeparam name="TModules">Тип модулей.</typeparam>
    public class RootAppApiBaseContext<TModules> : RootBaseContext<TModules>
        where TModules: RootAppApiBaseModules
    {
        #region Properties

        /// <summary>
        /// Мод "Auth". Основа.
        /// </summary>
        public ModAuthBaseContext ModAuthBase => Modules.ModAuthBase.Context;

        /// <summary>
        /// Мод "DummyMain". Основа.
        /// </summary>
        public ModDummyMainBaseContext ModDummyMainBase => Modules.ModDummyMainBase.Context;

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="modules">Модули.</param>
        /// <param name="logger">Регистратор.</param>
        public RootAppApiBaseContext(TModules modules, ILogger logger)
            : base(modules, logger)
        {
        }

        #endregion Constructors
    }
}
