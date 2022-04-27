//Author Vlad Balkarov//vlad//

using Vlad2020.Mods.IdentityServer.Web.Mvc.Parts.Account.Config;

namespace Vlad2020.Mods.IdentityServer.Web.Mvc.Config
{
    /// <summary>
    /// Мод "IdentityServer". Веб. MVC. Конфигурация. Настройки. Интерфейс.
    /// </summary>
    public interface IModIdentityServerWebMvcConfigSettings
    {
        #region Properties

        /// <summary>
        /// Часть "Account".
        /// </summary>
        IModIdentityServerWebMvcPartAccountConfigSettings PartAccount { get; }

        #endregion Properties
    }
}