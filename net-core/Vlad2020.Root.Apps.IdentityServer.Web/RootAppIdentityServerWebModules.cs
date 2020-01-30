//Author Maxim Kuzmin//makc//

using Vlad2020.Core.Base;
using Vlad2020.Core.Base.Common;
using Vlad2020.Mods.IdentityServer.Web.Mvc;
using Vlad2020.Mods.IdentityServer.Web.Mvc.Parts.Account;
using Vlad2020.Mods.IdentityServer.Web.Mvc.Parts.External;
using Vlad2020.Root.Apps.IdentityServer.Base;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace Vlad2020.Root.Apps.IdentityServer.Web
{
    /// <summary>
    /// Корень. Приложение "IdentityServer". Веб. Модули.
    /// </summary>
    public class RootAppIdentityServerWebModules : RootAppIdentityServerBaseModules
    {
        #region Properties

        /// <summary>
        /// Мод "IdentityServer". Веб. MVC.
        /// </summary>
        public ModIdentityServerWebMvcModule ModIdentityServerWebMvc { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="commonModules">Обобщённые модули.</param>
        public RootAppIdentityServerWebModules(IEnumerable<ICoreBaseCommonModule> commonModules)
            : base(commonModules)
        {
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public override void ConfigureServices(IServiceCollection services)
        {
            base.ConfigureServices(services);

            ModIdentityServerWebMvc?.ConfigureServices(services);
        }

        /// <inheritdoc/>
        public sealed override void InitConfig(CoreBaseEnvironment environment)
        {
            base.InitConfig(environment);

            ModIdentityServerWebMvc?.InitConfig(environment);
        }

        /// <inheritdoc/>
        public sealed override void InitContext(IServiceProvider serviceProvider, CoreBaseEnvironment environment)
        {
            base.InitContext(serviceProvider, environment);

            ModIdentityServerWebMvc?.InitContext(new ModIdentityServerWebMvcExternals
            {
                PartAccount = new ModIdentityServerWebMvcPartAccountExternals
                {
                    CoreBaseResourceErrors = CoreBase.Context.Resources.Errors,
                    ResourceErrors = ModIdentityServerBase.Context.Resources.Errors,
                    ResourceSuccesses = ModIdentityServerBase.Context.Resources.Successes,
                    ResourceTitles = ModIdentityServerBase.Context.Resources.Titles
                },
                PartExternal = new ModIdentityServerWebMvcPartExternalExternals
                {
                    CoreBaseResourceErrors = CoreBase.Context.Resources.Errors,
                    ResourceErrors = ModIdentityServerBase.Context.Resources.Errors
                }
            });
        }

        #endregion Public methods

        #region Protected methods

        /// <inheritdoc/>
        protected sealed override bool TrySetModule(ICoreBaseCommonModule commonModule)
        {
            if (base.TrySetModule(commonModule)) return true;
            
            if (TrySet<ModIdentityServerWebMvcModule>(x => ModIdentityServerWebMvc = x, commonModule)) return true;

            return false;
        }

        #endregion Protected methods
    }
}
