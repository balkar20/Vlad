﻿//Author Maxim Kuzmin//makc//

using Vlad2020.Mods.IdentityServer.Web.Mvc.Parts.Account;
using Vlad2020.Mods.IdentityServer.Web.Mvc.Parts.External;

namespace Vlad2020.Mods.IdentityServer.Web.Mvc
{
    /// <summary>
    /// Мод "IdentityServer". Веб. MVC. Внешнее.
    /// </summary>
    public class ModIdentityServerWebMvcExternals
    {
        #region Properties

        /// <summary>
        /// Часть "Account".
        /// </summary>
        public ModIdentityServerWebMvcPartAccountExternals PartAccount { get; set; }

        /// <summary>
        /// Часть "External".
        /// </summary>
        public ModIdentityServerWebMvcPartExternalExternals PartExternal { get; set; }

        #endregion Properties
    }
}
