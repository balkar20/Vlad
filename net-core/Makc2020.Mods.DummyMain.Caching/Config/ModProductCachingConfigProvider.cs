//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base;
using Makc2020.Core.Base.Common.Config.Providers;

namespace Makc2020.Mods.Product.Caching.Config
{
    /// <summary>
    /// Мод "Product". Кэширование. Конфигурация. Поставщик.
    /// </summary>
    public class ModProductCachingConfigProvider : CoreBaseCommonConfigProviderJson<ModProductCachingConfigSettings>
    {
        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="settings">Настройки.</param>
        /// <param name="filePath">Путь к файлу.</param>
        /// <param name="environment">Окружение.</param>
        public ModProductCachingConfigProvider(
            ModProductCachingConfigSettings settings,
            string filePath,
            CoreBaseEnvironment environment
            )
            : base(settings, filePath, environment)
        {
        }

        #endregion Constructors
    }
}
