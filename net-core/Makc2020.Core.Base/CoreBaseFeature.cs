﻿//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Common;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Makc2020.Core.Base
{
    /// <summary>
    /// Ядро. Основа. Функциональность.
    /// </summary>
    public class CoreBaseFeature : ICoreBaseCommonFeature
    {
        #region Properties

        /// <summary>
        /// Контекст.
        /// </summary>
        public CoreBaseContext Context { get; private set; }

        #endregion Properties

        #region Public methods

        /// <summary>
        /// Настроить сервисы.
        /// </summary>
        /// <param name="services">Сервисы.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient(x => GetContext(x).Resources.Converting);
            services.AddTransient(x => GetContext(x).Resources.Errors);
        }

        /// <summary>
        /// Инициализировать контекст.
        /// </summary>
        /// <param name="externals">Внешнее.</param>
        public void InitContext(CoreBaseExternals externals)
        {
            Context = new CoreBaseContext(externals);
        }

        #endregion Public methods

        #region Private methods

        private CoreBaseContext GetContext(IServiceProvider serviceProvider)
        {
            return serviceProvider.GetService<CoreBaseContext>();
        }

        #endregion Private methods
    }
}