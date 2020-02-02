//Author Maxim Kuzmin//makc//

using Vlad2020.Core.Base.Common;
using Vlad2020.Core.Caching;
using Vlad2020.Host.Web.Api.Parts.Auth;
using Vlad2020.Mods.Auth.Base.Config;
using Vlad2020.Mods.Auth.Web.Api;
using Vlad2020.Mods.Auth.Web.Ext;
using Vlad2020.Mods.DummyMain.Caching;
using Vlad2020.Mods.DummyMain.Web.Api;
using Vlad2020.Root.Apps.Api.Base;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using Vlad2020.Mods.Product.Caching;
using Vlad2020.Mods.Product.Web.Api;

namespace Vlad2020.Root.Apps.Api.Web
{
    /// <summary>
    /// Корень. Приложение "API". Веб. Конфигуратор.
    /// </summary>
    ///<typeparam name="TContext">Тип контекста.</typeparam>
    ///<typeparam name="TModules">Тип модулей.</typeparam>
    public abstract class RootAppApiWebConfigurator<TContext, TModules> : RootAppApiBaseConfigurator<TContext, TModules>
        where TContext : RootAppApiWebContext<TModules>
        where TModules : RootAppApiWebModules
    {
        #region Properties

        private IModAuthBaseConfigSettings ModAuthBaseConfigSettings { get; set; }

        private bool ModAuthWebAuthenticationIsEnabled
        {
            get
            {
                return ModAuthBaseConfigSettings != null;
            }
        }

        #endregion Properties

        #region Public methods

        /// <inheritdoc/>
        public override void ConfigureServices(IServiceCollection services)
        {
            base.ConfigureServices(services);

            services.AddTransient(x => GetContext(x).CoreCaching);
            services.AddTransient(x => GetContext(x).ModDummyMainCaching);
            services.AddTransient(x => GetContext(x).ModProductCaching);

            if (ModAuthWebAuthenticationIsEnabled)
            {
                services.ModAuthWebExtConfigureAuthentication(ModAuthBaseConfigSettings);
            }
        }

        /// <inheritdoc/>
        public sealed override List<ICoreBaseCommonModule> CreateCommonModuleList()
        {
            var result = base.CreateCommonModuleList();

            var modules = new ICoreBaseCommonModule[]
            {
                new CoreCachingModule(),
                new HostWebApiPartAuthModule(),
                new ModAuthWebApiModule(),
                new ModDummyMainCachingModule(),
                new ModDummyMainWebApiModule(),
                new ModProductCachingModule(),
                new ModProductWebApiModule()
            };

            result.AddRange(modules);

            return result;
        }

        /// <summary>
        /// Хост. Веб. Часть "Auth". Отключить.
        /// </summary>
        public void HostWebPartAuthenticationDisable()
        {
            ModAuthBaseConfigSettings = null;
        }

        /// <summary>
        /// Хост. Веб. Часть "Auth". Включить.
        /// </summary>
        /// <param name="configSettings">Конфигурационные настройки.</param>
        public void HostWebPartAuthenticationEnable(IModAuthBaseConfigSettings configSettings)
        {
            ModAuthBaseConfigSettings = configSettings;
        }

        #endregion Public methods
    }
}
