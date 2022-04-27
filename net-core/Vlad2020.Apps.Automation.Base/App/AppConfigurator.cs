//Author Vlad Balkarov//vlad//

using Vlad2020.Apps.Automation.Base.App.Parts.Angular.Jobs.Code.Generate;
using Vlad2020.Apps.Automation.Base.App.Parts.NetCore.Jobs.Code.Generate;
using Vlad2020.Root.Apps.Automation.Base;
using Microsoft.Extensions.DependencyInjection;

namespace Vlad2020.Apps.Automation.Base.App
{
    /// <summary>
    /// Приложение. Конфигуратор.
    /// </summary>
    public class AppConfigurator : RootAppAutomationBaseConfigurator<AppContext, RootAppAutomationBaseModules>
    {
        #region Public methods

        /// <inheritdoc/>
        public sealed override void ConfigureServices(IServiceCollection services)
        {
            base.ConfigureServices(services);

            services.AddTransient(x => AppServer.Instance.GetContext());

            services.AddTransient<AppPartAngularJobCodeGenerateClient>();
            services.AddTransient<AppPartNetCoreJobCodeGenerateClient>();

            services.AddHostedService<AppHostedService>();            
        }

        #endregion Public methods
    }
}
