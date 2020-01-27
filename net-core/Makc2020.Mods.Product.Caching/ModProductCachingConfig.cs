//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base;
using Makc2020.Core.Caching.Common.Client.Config;
using Makc2020.Mods.Product.Caching.Config;
using System.IO;

namespace Makc2020.Mods.Product.Caching
{
    /// <summary>
    /// Мод "Product". Кэширование. Конфигурация.
    /// </summary>
    public sealed class ModProductCachingConfig
    {
        #region Properties

        private CoreBaseEnvironment Environment { get; set; }

        private string FilePath { get; set; }

        /// <summary>
        /// Настройки.
        /// </summary>
        public ICoreCachingCommonClientConfigSettings Settings { get; private set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="environment">Окружение.</param>
        public ModProductCachingConfig(CoreBaseEnvironment environment)
        {
            Environment = environment;

            FilePath = CreateFilePath();

            Settings = ModProductCachingConfigSettings.Create(FilePath, Environment);
        }

        #endregion Constructors

        #region Internal methods

        /// <summary>
        /// Создать путь к файлу.
        /// </summary>
        /// <returns>Путь к файлу.</returns>
        internal static string CreateFilePath()
        {
            return Path.Combine("ConfigFiles", "Mod.Product.Caching.config");
        }

        #endregion Internal methods

        #region Рublic methods

        /// <summary>
        /// Создать поставщика.
        /// </summary>
        /// <param name="settings">Настройки.</param>
        public ModProductCachingConfigProvider CreateProvider(ModProductCachingConfigSettings settings)
        {
            return new ModProductCachingConfigProvider(settings, FilePath, Environment);
        }

        #endregion Рublic methods
    }
}