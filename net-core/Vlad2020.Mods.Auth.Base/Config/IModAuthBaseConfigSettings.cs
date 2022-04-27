//Author Vlad Balkarov//vlad//

using Vlad2020.Core.Base.Auth.Enums;
using Vlad2020.Mods.Auth.Base.Config.Settings;

namespace Vlad2020.Mods.Auth.Base.Config
{
    /// <summary>
    /// Мод "Auth". Основа. Конфигурация. Настройки. Интерфейс.
    /// </summary>
    public interface IModAuthBaseConfigSettings
    {
        #region Properties

        /// <summary>
        /// Тип.
        /// </summary>
        CoreBaseAuthEnumTypes Type { get; }

        /// <summary>
        /// Типы.
        /// </summary>
        IModAuthBaseConfigSettingTypes Types { get; }

        #endregion Properties
    }
}