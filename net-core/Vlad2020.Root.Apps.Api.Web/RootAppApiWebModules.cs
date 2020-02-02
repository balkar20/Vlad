//Author Maxim Kuzmin//makc//

using Vlad2020.Core.Base;
using Vlad2020.Core.Base.Common;
using Vlad2020.Core.Caching;
using Vlad2020.Core.Caching.Resources.Errors;
using Vlad2020.Data.Caching;
using Vlad2020.Host.Web.Api.Parts.Auth;
using Vlad2020.Mods.Auth.Web.Api;
using Vlad2020.Mods.DummyMain.Caching;
using Vlad2020.Mods.DummyMain.Web.Api;
using Vlad2020.Root.Apps.Api.Base;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using Vlad2020.Mods.Product.Caching;
using Vlad2020.Mods.Product.Web.Api;

namespace Vlad2020.Root.Apps.Api.Web
{
    /// <summary>
    /// Корень. Приложение "API". Веб. Модули.
    /// </summary>
    public class RootAppApiWebModules : RootAppApiBaseModules
    {
        #region Properties

        /// <summary>
        /// Ядро. Кэширование.
        /// </summary>
        public CoreCachingModule CoreCaching { get; set; }

        /// <summary>
        /// Хост. Beб. API. Часть "Auth". API.
        /// </summary>
        public HostWebApiPartAuthModule HostWebApiPartAuth { get; set; }

        /// <summary>
        /// Мод "Auth". Веб. API.
        /// </summary>
        public ModAuthWebApiModule ModAuthWebApi { get; set; }

        /// <summary>
        /// Мод "DummyMain". Кэширование.
        /// </summary>
        public ModDummyMainCachingModule ModDummyMainCaching { get; set; }

        /// <summary>
        /// Мод "DummyMain". Веб. API.
        /// </summary>
        public ModDummyMainWebApiModule ModDummyMainWebApi { get; set; }
        /// <summary>
        /// Мод "Product". Кэширование.
        /// </summary>
        public ModProductCachingModule ModProductCaching { get; set; }

        /// <summary>
        /// Мод "Product". Веб. API.
        /// </summary>
        public ModProductWebApiModule ModProductWebApi { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="commonModules">Обобщённые модули.</param>
        public RootAppApiWebModules(IEnumerable<ICoreBaseCommonModule> commonModules)
            : base(commonModules)
        {
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public override void ConfigureServices(IServiceCollection services)
        {
            base.ConfigureServices(services);

            CoreCaching?.ConfigureServices(services);
            HostWebApiPartAuth?.ConfigureServices(services);
            ModAuthWebApi?.ConfigureServices(services);
            ModDummyMainCaching?.ConfigureServices(services);
            ModDummyMainWebApi?.ConfigureServices(services);
            ModProductCaching?.ConfigureServices(services);
            ModProductWebApi?.ConfigureServices(services);
        }

        /// <inheritdoc/>
        public sealed override void InitConfig(CoreBaseEnvironment environment)
        {
            base.InitConfig(environment);

            CoreCaching?.InitConfig(environment);
            ModDummyMainCaching?.InitConfig(environment);
            ModProductCaching?.InitConfig(environment);
        }

        /// <inheritdoc/>
        public sealed override void InitContext(IServiceProvider serviceProvider, CoreBaseEnvironment environment)
        {
            base.InitContext(serviceProvider, environment);

            CoreCaching?.InitContext(new CoreCachingExternals
            {
                MemoryCacheOptions = new MemoryCacheOptions(),
                ResourceErrorsLocalizer = GetLocalizer<CoreCachingResourceErrors>(serviceProvider)
            });

            ModDummyMainCaching?.InitContext(new ModDummyMainCachingExternals
            {
                Cache = CoreCaching.Context.Cache,
                CoreBaseResourceErrors = CoreBase.Context.Resources.Errors,
                CoreCachingResourceErrors = CoreCaching.Context.Resources.Errors,
                DataBaseSettings = DataBase.Context.Settings,
                ResourceErrors = ModDummyMainBase.Context.Resources.Errors,
                ResourceSuccesses = ModDummyMainBase.Context.Resources.Successes,
                Service = ModDummyMainBase.Context.Service
            });
            ModProductCaching?.InitContext(new ModProductCachingExternals
            {
                Cache = CoreCaching.Context.Cache,
                CoreBaseResourceErrors = CoreBase.Context.Resources.Errors,
                CoreCachingResourceErrors = CoreCaching.Context.Resources.Errors,
                DataBaseSettings = DataBase.Context.Settings,
                ResourceErrors = ModProductBase.Context.Resources.Errors,
                ResourceSuccesses = ModProductBase.Context.Resources.Successes,
                Service = ModProductBase.Context.Service
            });
        }

        /// <inheritdoc/>
        public sealed override void OnAppStarted()
        {
            DataCachingSerialization.Init();
            ModDummyMainCachingSerialization.Init();
            ModProductCachingSerialization.Init();
        }

        #endregion Public methods

        #region Protected methods

        /// <inheritdoc/>
        protected sealed override bool TrySetModule(ICoreBaseCommonModule commonModule)
        {
            if (base.TrySetModule(commonModule)) return true;

            if (TrySet<CoreCachingModule>(x => CoreCaching = x, commonModule)) return true;
            if (TrySet<HostWebApiPartAuthModule>(x => HostWebApiPartAuth = x, commonModule)) return true;
            if (TrySet<ModAuthWebApiModule>(x => ModAuthWebApi = x, commonModule)) return true;
            if (TrySet<ModDummyMainCachingModule>(x => ModDummyMainCaching = x, commonModule)) return true;
            if (TrySet<ModDummyMainWebApiModule>(x => ModDummyMainWebApi = x, commonModule)) return true;
            if (TrySet<ModProductCachingModule>(x => ModProductCaching = x, commonModule)) return true;
            if (TrySet<ModProductWebApiModule>(x => ModProductWebApi = x, commonModule)) return true;

            return false;
        }

        #endregion Protected methods
    }
}
