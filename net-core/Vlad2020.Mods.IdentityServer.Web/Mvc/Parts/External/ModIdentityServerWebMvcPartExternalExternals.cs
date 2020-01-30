﻿//Author Maxim Kuzmin//makc//

using Vlad2020.Core.Base.Resources.Errors;
using Vlad2020.Mods.Auth.Base.Resources.Errors;

namespace Vlad2020.Mods.IdentityServer.Web.Mvc.Parts.External
{
    /// <summary>
    /// Мод "IdentityServer". Веб. MVC. Часть "External". Внешнее.
    /// </summary>
    public class ModIdentityServerWebMvcPartExternalExternals
    {
        #region Properties

        /// <summary>
        /// Ядро. Основа. Ресурсы. Ошибки.
        /// </summary>
        public CoreBaseResourceErrors CoreBaseResourceErrors { get; set; }

        /// <summary>
        /// Ресурс ошибок.
        /// </summary>
        public ModIdentityServerBaseResourceErrors ResourceErrors { get; set; }

        #endregion Properties
    }
}
