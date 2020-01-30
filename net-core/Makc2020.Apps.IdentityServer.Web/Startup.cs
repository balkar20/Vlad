//Author Maxim Kuzmin//makc//

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Web;
using Vlad2020.Apps.IdentityServer.Web.Root;
using System;
using System.IO;

namespace Vlad2020.Apps.IdentityServer.Web
{
    /// <summary>
    /// ���.
    /// </summary>
    public class Startup
    {
        #region Properties

        private static AppServer Server => AppServer.Instance;

        #endregion Properties

        #region Public methods

        /// <summary>
        /// ���������.
        /// </summary>
        /// <param name="args">���������.</param>        
        public static void Run(string[] args)
        {
            Run<Startup>(args);
        }

        /// <summary>
        /// ���������.
        /// </summary>
        /// <typeparam name="TStartup">��� �����.</typeparam>
        /// <param name="args">���������.</param>        
        public static void Run<TStartup>(string[] args) where TStartup : class
        {
            var basePath = System.AppContext.BaseDirectory;

            var logConfigFilePath = Path.Combine(basePath, "ConfigFiles", "nlog.config");

            // NLog: setup the logger first to catch all errors
            var logger = NLog.LogManager.LoadConfiguration(logConfigFilePath).GetCurrentClassLogger();

            try
            {
                logger.Debug("init main");

                Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder(args)
                    .ConfigureWebHostDefaults(webHostBuilder =>
                    {
                        webHostBuilder.ConfigureAppConfiguration((builderContext, configurationBuilder) =>
                        {
                            Server.ConfigureAppConfiguration(
                                configurationBuilder,
                                basePath,
                                builderContext.HostingEnvironment.EnvironmentName
                                );
                        })
                        .ConfigureLogging(loggingBuilder =>
                        {
                            loggingBuilder.ClearProviders();
                            loggingBuilder.SetMinimumLevel(LogLevel.Trace);
                        })
                        .UseNLog()  // NLog: setup NLog for Dependency injection   
                        .UseStartup<TStartup>();
                    })
                    .Build()
                    .Run();
            }
            catch (Exception ex)
            {
                //NLog: catch setup errors
                logger.Error(ex, "Stopped program because of exception");

                throw;
            }
            finally
            {
                // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
                NLog.LogManager.Shutdown();
            }
        }

        /// <summary>
        /// ��������� �������.
        /// </summary>
        /// <param name="services">�������.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            Server.ConfigureServices(services);
        }

        /// <summary>
        /// ���������.
        /// </summary>
        /// <param name="app">����������� ����������.</param>
        /// <param name="env">���������.</param>
        /// <param name="appLifetime">��������� ���� ����������.</param>
        public void Configure(
            IApplicationBuilder app,
            IWebHostEnvironment env,
            IHostApplicationLifetime appLifetime
            )
        {
            Server.Configure(app, env, appLifetime);
        }

        #endregion Public methods
    }
}
