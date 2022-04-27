﻿//Author Vlad Balkarov//vlad//

using Vlad2020.Core.Base.Auth.Types.Oidc;

namespace Vlad2020.Mods.Auth.Base.Config.Settings.Types
{
    /// <summary>
    /// Мод "Auth". Основа. Конфигурация. Настройки. Типы. OIDC.
    /// </summary>
    public class ModAuthBaseConfigSettingTypeOidc : ICoreBaseAuthTypeOidcSettings
    {
        #region Properties

        /// <inheritdoc/>
        public string Audience { get; set; }

        /// <inheritdoc/>
        public string Authority { get; set; }

        /// <inheritdoc/>
        public bool RequireHttpsMetadata { get; set; }

        #endregion Properties
    }
}