//Author Maxim Kuzmin//makc//

using Vlad2020.Core.Base;
using Vlad2020.Core.Base.Common.Config.Providers;

namespace Vlad2020.Host.Base.Config
{
    /// <summary>
    /// Хост. Основа. Конфигурация. Поставщик.
    /// </summary>
    public class HostBaseConfigProvider : CoreBaseCommonConfigProviderJson<HostBaseConfigSettings>
    {
        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="settings">Настройки.</param>
        /// <param name="filePath">Путь к файлу.</param>
        /// <param name="environment">Окружение.</param>
        public HostBaseConfigProvider(
            HostBaseConfigSettings settings,
            string filePath,
            CoreBaseEnvironment environment
            )
            : base(settings, filePath, environment)
        {
        }

        #endregion Constructors
    }
}
