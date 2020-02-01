//Author Maxim Kuzmin//makc//

using Vlad2020.Core.Base.Common;
using Vlad2020.Mods.Auth.Base;
using Vlad2020.Mods.DummyMain.Base;
using Vlad2020.Root.Base;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using Vlad2020.Mods.Product.Base;

namespace Vlad2020.Root.Apps.Api.Base
{
    /// <summary>
    /// Корень. Приложение "API". Основа. Конфигуратор.
    /// </summary>
    ///<typeparam name="TContext">Тип контекста.</typeparam>
    ///<typeparam name="TModules">Тип модулей.</typeparam>
    public abstract class RootAppApiBaseConfigurator<TContext, TModules> : RootBaseConfigurator<TContext, TModules>
        where TContext: RootAppApiBaseContext<TModules>
        where TModules: RootAppApiBaseModules
    {
        #region Public methods

        /// <inheritdoc/>
        public override void ConfigureServices(IServiceCollection services)
        {
            base.ConfigureServices(services);

            services.AddTransient(x => GetContext(x).ModAuthBase);
            services.AddTransient(x => GetContext(x).ModDummyMainBase);
            services.AddTransient(x => GetContext(x).ModProductBase);
        }

        /// <inheritdoc/>
        public override List<ICoreBaseCommonModule> CreateCommonModuleList()
        {
            var result = base.CreateCommonModuleList();

            var modules = new ICoreBaseCommonModule[]
            {
                new ModAuthBaseModule(),
                new ModDummyMainBaseModule(),
                new ModProductBaseModule(),
            };

            result.AddRange(modules);

            return result;
        }

        #endregion Public methods
    }
}
