﻿//Author Vlad Balkarov//vlad//

using Vlad2020.Core.Base;
using Vlad2020.Core.Base.Common;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Vlad2020.Mods.IdentityServer.Base
{
    /// <summary>
    /// Мод "IdentityServer". Основа. Модуль.
    /// </summary>
    public class ModIdentityServerBaseModule : ICoreBaseCommonModule
    {
        #region Properties

        /// <summary>
        /// Конфигурация.
        /// </summary>
        public ModIdentityServerBaseConfig Config { get; private set; }

        /// <summary>
        /// Контекст.
        /// </summary>
        public ModIdentityServerBaseContext Context { get; private set; }

        #endregion Properties

        #region Public methods

        /// <summary>
        /// Настроить сервисы.
        /// </summary>
        /// <param name="services">Сервисы.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient(x => GetContext(x).Config);
            services.AddTransient(x => GetContext(x).Config.Settings);
            services.AddTransient(x => GetContext(x).Resources.Titles);
            services.AddTransient(x => GetContext(x).Resources.Errors);
            services.AddTransient(x => GetContext(x).Resources.Successes);
        }

        /// <summary>
        /// Инициализировать конфигурацию.
        /// </summary>
        /// <param name="environment">Окружение.</param>
        public void InitConfig(CoreBaseEnvironment environment)
        {
            Config = new ModIdentityServerBaseConfig(environment);
        }

        /// <summary>
        /// Инициализировать контекст.
        /// </summary>
        /// <param name="externals">Внешнее.</param>
        public void InitContext(ModIdentityServerBaseExternals externals)
        {
            Context = new ModIdentityServerBaseContext(Config, externals);
        }

        #endregion Public methods

        #region Private methods

        private ModIdentityServerBaseContext GetContext(IServiceProvider serviceProvider)
        {
            return serviceProvider.GetService<ModIdentityServerBaseContext>();
        }

        #endregion Private methods
    }
}