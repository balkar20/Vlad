//Author Maxim Kuzmin//makc//

using Vlad2020.Host.Base.Parts.Auth.Config.Settings;

namespace Vlad2020.Host.Base.Parts.Auth.Config
{
    /// <summary>
    /// Хост. Основа. Часть "Auth". Конфигурация. Настройки.
    /// </summary>
    public class HostBasePartAuthConfigSettings : IHostBasePartAuthConfigSettings
    {
        #region Properties

        /// <summary>
        /// Группы.
        /// </summary>
        public HostBasePartAuthConfigSettingGroups Groups { get; set; }

        /// <inheritdoc/>
        IHostBasePartAuthConfigSettingGroups IHostBasePartAuthConfigSettings.Groups => Groups;

        /// <summary>
        /// Пользователи.
        /// </summary>
        public HostBasePartAuthConfigSettingUser[] Users { get; set; }

        /// <inheritdoc/>
        IHostBasePartAuthConfigSettingUser[] IHostBasePartAuthConfigSettings.Users => Users;

        #endregion Properties
    }
}