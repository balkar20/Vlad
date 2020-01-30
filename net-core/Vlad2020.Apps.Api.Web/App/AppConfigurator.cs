﻿//Author Maxim Kuzmin//makc//

using Vlad2020.Root.Apps.Api.Web;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace Vlad2020.Apps.Api.Web.App
{
    /// <summary>
    /// Приложение. Конфигуратор.
    /// </summary>
    public class AppConfigurator : RootAppApiWebConfigurator<AppContext, RootAppApiWebModules>
    {
        #region Constants

        public const string CORS_POLICY_NAME = "MyPolicy";

        #endregion Constants

        #region Public methods

        /// <inheritdoc/>
        public sealed override void ConfigureServices(IServiceCollection services)
        {
            base.ConfigureServices(services);

            services.AddTransient(x => AppServer.Instance.GetContext());

            services.AddControllers();//makc//???//.AddControllersAsServices();

            services.Configure<CorsOptions>(options =>
                options.AddPolicy(
                    CORS_POLICY_NAME,
                    corsBuilder => corsBuilder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                    //.AllowCredentials()
                    )
                );
        }

        #endregion Public methods
    }
}
