//Author Vlad Balkarov//vlad//

using Vlad2020.Core.Base.Common;
using Microsoft.Extensions.DependencyInjection;

namespace Vlad2020.Mods.Product.Web.Api
{
    /// <summary>
    /// Мод "Product". Веб. API. Модуль.
    /// </summary>
    public class ModProductWebApiModule : ICoreBaseCommonModule
    {
        #region Public methods

        /// <summary>
        /// Настроить сервисы.
        /// </summary>
        /// <param name="services">Сервисы.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<ModProductWebApiModel>();
        }

        #endregion Public methods
    }
}