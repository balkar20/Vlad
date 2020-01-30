//Author Maxim Kuzmin//makc//

namespace Vlad2020.Mods.Product.Base
{
    /// <summary>
    /// Мод "Product". Основа. Контекст.
    /// </summary>
    public class ModProductBaseContext
    {
        #region Properties

        /// <summary>
        /// Конфигурация.
        /// </summary>
        public ModProductBaseConfig Config { get; private set; }

        /// <summary>
        /// Задания.
        /// </summary>
        public ModProductBaseJobs Jobs { get; private set; }

        /// <summary>
        /// Ресурсы.
        /// </summary>
        public ModProductBaseResources Resources { get; private set; }

        /// <summary>
        /// Сервис.
        /// </summary>
        public ModProductBaseService Service { get; private set; }

        #endregion Properties

        #region Constructor

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="config">Конфигурация.</param>
        /// <param name="externals">Внешнее.</param>
        public ModProductBaseContext(ModProductBaseConfig config, ModProductBaseExternals externals)
        {
            Config = config;
            
            Resources = new ModProductBaseResources(
                externals.ResourceErrorsLocalizer,
                externals.ResourceSuccessesLocalizer
                );

            Service = new ModProductBaseService(
                Config.Settings,
                externals.CoreBaseDataProvider,
                externals.DataEntityDbFactory
                );

            Jobs = new ModProductBaseJobs(
                externals.CoreBaseResourceErrors,
                externals.DataBaseSettings,
                Resources.Successes,
                Resources.Errors,
                Service
                );
        }

        #endregion Constructor
    }
}
