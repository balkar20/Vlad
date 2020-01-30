//Author Maxim Kuzmin//makc//

using Vlad2020.Core.Base;
using Vlad2020.Core.Base.Common.Config.Providers;

namespace Vlad2020.Core.Caching.Config
{
    /// <summary>
    /// Ядро. Кэширование. Конфигурация. Поставщик.
    /// </summary>
    public class CoreCachingConfigProvider : CoreBaseCommonConfigProviderJson<CoreCachingConfigSettings>
    {
        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="settings">Настройки.</param>
        /// <param name="filePath">Путь к файлу.</param>
        /// <param name="environment">Окружение.</param>
        public CoreCachingConfigProvider(
            CoreCachingConfigSettings settings,
            string filePath,
            CoreBaseEnvironment environment
            )
            : base(settings, filePath, environment)
        {
        }

        #endregion Constructors
    }
}
