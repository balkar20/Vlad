//Author Maxim Kuzmin//makc//

using Vlad2020.Mods.IdentityServer.Web.Mvc.Parts.Account;

namespace Vlad2020.Apps.IdentityServer.Web.Controllers
{
    public class AccountController : ModIdentityServerWebMvcPartAccountController
    {
        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="model">Модель.</param>
        public AccountController(ModIdentityServerWebMvcPartAccountModel model)
            : base(model)
        {
        }

        #endregion Constructors
    }
}
