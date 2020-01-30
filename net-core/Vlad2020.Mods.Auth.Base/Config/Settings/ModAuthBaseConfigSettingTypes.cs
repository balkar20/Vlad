//Author Maxim Kuzmin//makc//

using Vlad2020.Core.Base.Auth.Types.Jwt;
using Vlad2020.Core.Base.Auth.Types.Oidc;
using Vlad2020.Mods.Auth.Base.Config.Settings.Types;

namespace Vlad2020.Mods.Auth.Base.Config.Settings
{
    /// <summary>
    /// Мод "Auth". Основа. Конфигурация. Настройки. Типы.
    /// </summary>
    public class ModAuthBaseConfigSettingTypes : IModAuthBaseConfigSettingTypes
    {
        #region Properties

        /// <summary>
        /// JWT.
        /// </summary>
        public ModAuthBaseConfigSettingTypeJwt Jwt { get; set; }

        /// <inheritdoc/>
        ICoreBaseAuthTypeJwtSettings IModAuthBaseConfigSettingTypes.Jwt => Jwt;

        /// <summary>
        /// OIDC.
        /// </summary>
        public ModAuthBaseConfigSettingTypeOidc Oidc { get; set; }

        /// <inheritdoc/>
        ICoreBaseAuthTypeOidcSettings IModAuthBaseConfigSettingTypes.Oidc => Oidc;

        #endregion Properties

        #region Internal methods

        /// <summary>
        /// Инициализировать.
        /// </summary>
        internal void Init()
        {
            Jwt.Init();
        }

        #endregion Internal methods
    }
}