//Author Vlad Balkarov//vlad//

namespace Vlad2020.Host.Base.Parts.Auth.Config.Settings
{
    /// <summary>
    /// Хост. Основа. Часть "Auth". Конфигурация. Настройки. Группы.
    /// </summary>
    public class HostBasePartAuthConfigSettingGroups : IHostBasePartAuthConfigSettingGroups
    {
        #region Properties

        /// <inheritdoc/>
        public string[] Administrators { get; set; }

        #endregion Properties
    }
}