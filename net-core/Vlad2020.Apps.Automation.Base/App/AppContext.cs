﻿//Author Vlad Balkarov//vlad//

using Vlad2020.Root.Apps.Automation.Base;
using Microsoft.Extensions.Logging;

namespace Vlad2020.Apps.Automation.Base.App
{
    /// <summary>
    /// Приложение. Контекст.
    /// </summary>    
    public class AppContext : RootAppAutomationBaseContext<RootAppAutomationBaseModules>
    {
        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="modules">Модули.</param>
        /// <param name="logger">Регистратор.</param>
        public AppContext(RootAppAutomationBaseModules modules, ILogger logger)
            : base(modules, logger)
        {
        }

        #endregion Constructors
    }
}
