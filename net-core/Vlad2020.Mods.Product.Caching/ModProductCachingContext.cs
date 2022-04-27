//Author Vlad Balkarov//vlad//

namespace Vlad2020.Mods.Product.Caching
{
    /// <summary>
    /// Мод "Product". Кэширование. Контекст.
    /// </summary>
    public class ModProductCachingContext
    {
        #region Properties

        /// <summary>
        /// Конфигурация.
        /// </summary>
        public ModProductCachingConfig Config { get; private set; }

        /// <summary>
        /// Задания.
        /// </summary>
        public ModProductCachingJobs Jobs { get; private set; }

        #endregion Properties

        #region Constructor

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="config">Конфигурация.</param>
        /// <param name="externals">Внешнее.</param>
        public ModProductCachingContext(ModProductCachingConfig config, ModProductCachingExternals externals)
        {
            Config = config;

            Jobs = new ModProductCachingJobs(
                externals.CoreBaseResourceErrors,
                externals.Cache,
                Config.Settings,
                externals.CoreCachingResourceErrors,
                externals.DataBaseSettings,
                externals.ResourceSuccesses,
                externals.ResourceErrors,
                externals.Service
                );
        }

        #endregion Constructor
    }
}
