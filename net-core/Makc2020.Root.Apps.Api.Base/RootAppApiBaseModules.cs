﻿//Author Maxim Kuzmin//makc//

using Vlad2020.Core.Base;
using Vlad2020.Core.Base.Common;
using Vlad2020.Mods.Auth.Base;
using Vlad2020.Mods.Auth.Base.Resources.Errors;
using Vlad2020.Mods.Auth.Base.Resources.Successes;
using Vlad2020.Mods.DummyMain.Base;
using Vlad2020.Mods.DummyMain.Base.Resources.Errors;
using Vlad2020.Mods.DummyMain.Base.Resources.Successes;
using Vlad2020.Root.Base;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace Vlad2020.Root.Apps.Api.Base
{
    /// <summary>
    /// Корень. Приложение "API". Основа. Модули.
    /// </summary>
    public class RootAppApiBaseModules : RootBaseModules
    {
        #region Properties

        /// <summary>
        /// Мод "Auth". Основа.
        /// </summary>
        public ModAuthBaseModule ModAuthBase { get; set; }

        /// <summary>
        /// Мод "DummyMain". Основа.
        /// </summary>
        public ModDummyMainBaseModule ModDummyMainBase { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="commonModules">Обобщённые модули.</param>
        public RootAppApiBaseModules(IEnumerable<ICoreBaseCommonModule> commonModules)
            : base(commonModules)
        {
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public override void ConfigureServices(IServiceCollection services)
        {
            base.ConfigureServices(services);

            ModAuthBase?.ConfigureServices(services);
            ModDummyMainBase?.ConfigureServices(services);
        }

        /// <inheritdoc/>
        public override void InitConfig(CoreBaseEnvironment environment)
        {
            base.InitConfig(environment);

            ModAuthBase?.InitConfig(environment);
            ModDummyMainBase?.InitConfig(environment);
        }

        /// <inheritdoc/>
        public override void InitContext(IServiceProvider serviceProvider, CoreBaseEnvironment environment)
        {
            base.InitContext(serviceProvider, environment);

            ModAuthBase?.InitContext(new ModAuthBaseExternals
            {
                CoreBaseResourceErrors = CoreBase?.Context.Resources.Errors,
                ResourceErrorsLocalizer = GetLocalizer<ModAuthBaseResourceErrors>(serviceProvider),
                ResourceSuccessesLocalizer = GetLocalizer<ModAuthBaseResourceSuccesses>(serviceProvider)
            });

            ModDummyMainBase?.InitContext(new ModDummyMainBaseExternals
            {
                CoreBaseResourceErrors = CoreBase?.Context.Resources.Errors,
                CoreBaseDataProvider = CoreDataSqlServer?.Context.Provider,
                DataBaseSettings = DataBase?.Context.Settings,
                DataEntityDbFactory = DataEntitySqlServer?.Context.DbFactory,
                ResourceErrorsLocalizer = GetLocalizer<ModDummyMainBaseResourceErrors>(serviceProvider),
                ResourceSuccessesLocalizer = GetLocalizer<ModDummyMainBaseResourceSuccesses>(serviceProvider)
            });
        }

        #endregion Public methods

        #region Protected methods

        /// <inheritdoc/>
        protected override bool TrySetModule(ICoreBaseCommonModule commonModule)
        {
            base.TrySetModule(commonModule);

            if (TrySet<ModAuthBaseModule>(x => ModAuthBase = x, commonModule)) return true;
            if (TrySet<ModDummyMainBaseModule>(x => ModDummyMainBase = x, commonModule)) return true;            

            return false;
        }

        #endregion Protected methods
    }
}
