﻿//Author Maxim Kuzmin//makc//

using Vlad2020.Mods.IdentityServer.Base;
using Vlad2020.Root.Base;
using Microsoft.Extensions.Logging;

namespace Vlad2020.Root.Apps.IdentityServer.Base
{
    /// <summary>
    /// Корень. Приложение "IdentityServer". Основа. Контекст.
    /// </summary>
    /// <typeparam name="TModules">Тип модулей.</typeparam>
    public abstract class RootAppIdentityServerBaseContext<TModules> : RootBaseContext<TModules>
        where TModules: RootAppIdentityServerBaseModules
    {
        #region Properties

        /// <summary>
        /// Мод "IdentityServer". Основа.
        /// </summary>
        public ModIdentityServerBaseContext ModIdentityServerBase => Modules.ModIdentityServerBase.Context;

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="modules">Модули.</param>
        /// <param name="logger">Регистратор.</param>
        public RootAppIdentityServerBaseContext(TModules modules, ILogger logger)
            : base(modules, logger)
        {
        }

        #endregion Constructors
    }
}
