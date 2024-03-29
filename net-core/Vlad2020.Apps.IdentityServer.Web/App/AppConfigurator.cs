﻿//Author Vlad Balkarov//vlad//

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Vlad2020.Root.Apps.IdentityServer.Web;

namespace Vlad2020.Apps.IdentityServer.Web.Root
{
    /// <summary>
    /// Приложение. Конфигуратор.
    /// </summary>
    public class AppConfigurator : RootAppIdentityServerWebConfigurator<AppContext, RootAppIdentityServerWebModules>
    {
        #region Public methods

        /// <summary>
        /// Настроить сервисы.
        /// </summary>
        /// <param name="services">Сервисы.</param>
        public sealed override void ConfigureServices(IServiceCollection services)
        {
            base.ConfigureServices(services);

            services.AddTransient(x => AppServer.Instance.GetContext());

            services.AddControllersWithViews();

            // configures IIS out-of-proc settings (see https://github.com/aspnet/AspNetCore/issues/14882)
            services.Configure<IISOptions>(iis =>
            {
                iis.AuthenticationDisplayName = "Windows";
                iis.AutomaticAuthentication = false;
            });

            // configures IIS in-proc settings
            services.Configure<IISServerOptions>(iis =>
            {
                iis.AuthenticationDisplayName = "Windows";
                iis.AutomaticAuthentication = false;
            });
        }

        #endregion Public methods
    }
}
