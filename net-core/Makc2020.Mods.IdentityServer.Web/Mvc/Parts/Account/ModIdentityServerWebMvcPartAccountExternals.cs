﻿//Author Maxim Kuzmin//makc//

using Vlad2020.Core.Base.Resources.Errors;
using Vlad2020.Mods.Auth.Base.Resources.Errors;
using Vlad2020.Mods.IdentityServer.Base.Resources.Successes;
using Vlad2020.Mods.IdentityServer.Base.Resources.Titles;

namespace Vlad2020.Mods.IdentityServer.Web.Mvc.Parts.Account
{
    /// <summary>
    /// Мод "IdentityServer". Веб. MVC. Часть "Account". Внешнее.
    /// </summary>
    public class ModIdentityServerWebMvcPartAccountExternals
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

        /// <summary>
        /// Ресурс успехов.
        /// </summary>
        public ModIdentityServerBaseResourceSuccesses ResourceSuccesses { get; set; }

        /// <summary>
        /// Ресурс заголовков.
        /// </summary>
        public ModIdentityServerBaseResourceTitles ResourceTitles { get; set; }

        #endregion Properties
    }
}
