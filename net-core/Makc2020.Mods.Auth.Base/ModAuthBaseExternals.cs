﻿//Author Maxim Kuzmin//makc//

using Vlad2020.Core.Base.Resources.Errors;
using Vlad2020.Mods.Auth.Base.Resources.Errors;
using Vlad2020.Mods.Auth.Base.Resources.Successes;
using Microsoft.Extensions.Localization;

namespace Vlad2020.Mods.Auth.Base
{
    /// <summary>
    /// Мод "Auth". Основа. Внешнее.
    /// </summary>
    public class ModAuthBaseExternals
    {
        #region Properties

        /// <summary>
        /// Ядро. Основа. Ресурсы. Ошибки.
        /// </summary>
        public CoreBaseResourceErrors CoreBaseResourceErrors { get; set; }

        /// <summary>
        /// Локализатор ресурса ошибок.
        /// </summary>
        public IStringLocalizer<ModAuthBaseResourceErrors> ResourceErrorsLocalizer { get; set; }

        /// <summary>
        /// Локализатор ресурса успехов.
        /// </summary>
        public IStringLocalizer<ModAuthBaseResourceSuccesses> ResourceSuccessesLocalizer { get; set; }

        #endregion Properties
    }
}
