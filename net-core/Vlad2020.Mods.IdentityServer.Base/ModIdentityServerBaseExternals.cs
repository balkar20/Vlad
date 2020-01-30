﻿//Author Maxim Kuzmin//makc//

using Vlad2020.Mods.Auth.Base.Resources.Errors;
using Vlad2020.Mods.IdentityServer.Base.Resources.Successes;
using Vlad2020.Mods.IdentityServer.Base.Resources.Titles;
using Microsoft.Extensions.Localization;

namespace Vlad2020.Mods.IdentityServer.Base
{
    /// <summary>
    /// Мод "IdentityServer". Основа. Внешнее.
    /// </summary>
    public class ModIdentityServerBaseExternals
    {
        #region Properties

        /// <summary>
        /// Локализатор ресурса ошибок.
        /// </summary>
        public IStringLocalizer<ModIdentityServerBaseResourceErrors> ResourceErrorsLocalizer { get; set; }

        /// <summary>
        /// Локализатор ресурса успехов.
        /// </summary>
        public IStringLocalizer<ModIdentityServerBaseResourceSuccesses> ResourceSuccessesLocalizer { get; set; }

        /// <summary>
        /// Локализатор ресурса заголовков.
        /// </summary>
        public IStringLocalizer<ModIdentityServerBaseResourceTitles> ResourceTitlesLocalizer { get; set; }

        #endregion Properties
    }
}
