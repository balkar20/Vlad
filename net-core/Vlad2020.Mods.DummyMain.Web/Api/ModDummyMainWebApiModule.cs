﻿//Author Vlad Balkarov//vlad//

using Vlad2020.Core.Base.Common;
using Microsoft.Extensions.DependencyInjection;

namespace Vlad2020.Mods.DummyMain.Web.Api
{
    /// <summary>
    /// Мод "DummyMain". Веб. API. Модуль.
    /// </summary>
    public class ModDummyMainWebApiModule : ICoreBaseCommonModule
    {
        #region Public methods

        /// <summary>
        /// Настроить сервисы.
        /// </summary>
        /// <param name="services">Сервисы.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<ModDummyMainWebApiModel>();
        }

        #endregion Public methods
    }
}