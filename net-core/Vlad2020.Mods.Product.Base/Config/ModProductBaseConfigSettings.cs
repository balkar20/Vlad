//Author Vlad Balkarov//vlad//

using Vlad2020.Core.Base;

namespace Vlad2020.Mods.Product.Base.Config
{
    /// <summary>
    /// Мод "Product". Основа. Конфигурация. Настройки.
    /// </summary>
    public class ModProductBaseConfigSettings : IModProductBaseConfigSettings
    {
        #region Properties

        /// <inheritdoc/>
        public int DbCommandTimeout { get; set; }

        #endregion Properties

        #region Internal methods

        /// <summary>
        /// Создать.
        /// </summary>
        /// <param name="configFilePath">Путь к файлу конфигурации.</param>
        /// <param name="environment">Окружение.</param>
        /// <returns>Конфигурационные настройки.</returns>
        internal static IModProductBaseConfigSettings Create(string configFilePath, CoreBaseEnvironment environment)
        {
            var result = new ModProductBaseConfigSettings();

            var configProvider = new ModProductBaseConfigProvider(result, configFilePath, environment);

            configProvider.Load();

            return result;
        }

        #endregion Internal methods
    }
}