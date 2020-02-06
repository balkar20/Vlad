//Author Maxim Kuzmin//makc//

using Vlad2020.Core.Base;
using Vlad2020.Core.Base.Common;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Vlad2020.Mods.Product.Caching
{
    /// <summary>
    /// Мод "Product". Кэширование. Модуль.
    /// </summary>
    public class ModProductCachingModule : ICoreBaseCommonModule
    {
        #region Properties

        /// <summary>
        /// Конфигурация.
        /// </summary>
        public ModProductCachingConfig Config { get; private set; }

        /// <summary>
        /// Контекст.
        /// </summary>
        public ModProductCachingContext Context { get; private set; }

        #endregion Properties

        #region Public methods

        /// <summary>
        /// Настроить сервисы.
        /// </summary>
        /// <param name="services">Сервисы.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient(x => GetContext(x).Config);
            services.AddTransient(x => GetContext(x).Config.Settings);
            services.AddTransient(x => GetContext(x).Jobs.JobItemDelete);
            services.AddTransient(x => GetContext(x).Jobs.JobItemGet);
            services.AddTransient(x => GetContext(x).Jobs.JobItemInsert);
            services.AddTransient(x => GetContext(x).Jobs.JobItemUpdate);
            services.AddTransient(x => GetContext(x).Jobs.JobListGet);
            services.AddTransient(x => GetContext(x).Jobs.JobOptionsProductFeatureGet);
            services.AddTransient(x => GetContext(x).Jobs.JobOptionsProductCategoryGet);
        }

        /// <summary>
        /// Инициализировать конфигурацию.
        /// </summary>
        /// <param name="environment">Окружение.</param>
        public void InitConfig(CoreBaseEnvironment environment)
        {
            Config = new ModProductCachingConfig(environment);
        }

        /// <summary>
        /// Инициализировать контекст.
        /// </summary>
        /// <param name="externals">Внешнее.</param>
        public void InitContext(ModProductCachingExternals externals)
        {
            Context = new ModProductCachingContext(Config, externals);
        }

        #endregion Public methods

        #region Private methods

        private ModProductCachingContext GetContext(IServiceProvider serviceProvider)
        {
            return serviceProvider.GetService<ModProductCachingContext>();
        }

        #endregion Private methods
    }
}