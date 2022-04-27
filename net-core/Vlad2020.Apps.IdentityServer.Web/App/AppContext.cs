//Author Vlad Balkarov//vlad//

using Microsoft.Extensions.Logging;
using Vlad2020.Root.Apps.IdentityServer.Web;

namespace Vlad2020.Apps.IdentityServer.Web.Root
{
    /// <summary>
    /// Приложение. Контекст.
    /// </summary>    
    public class AppContext : RootAppIdentityServerWebContext<RootAppIdentityServerWebModules>
    {
        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="modules">Модули.</param>
        /// <param name="logger">Регистратор.</param>
        public AppContext(RootAppIdentityServerWebModules modules, ILogger logger)
            : base(modules, logger)
        {
        }

        #endregion Constructors
    }
}
