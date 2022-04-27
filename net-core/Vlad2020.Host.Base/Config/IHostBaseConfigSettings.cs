//Author Vlad Balkarov//vlad//

using Vlad2020.Host.Base.Parts.Auth.Config;
using Vlad2020.Host.Base.Parts.Ldap.Config;

namespace Vlad2020.Host.Base.Config
{
    /// <summary>
    /// Хост. Основа. Конфигурация. Настройки. Интерфейс.
    /// </summary>
    public interface IHostBaseConfigSettings
    {
        #region Properties

        /// <summary>
        /// Часть "Auth".
        /// </summary>
        IHostBasePartAuthConfigSettings PartAuth { get; }

        /// <summary>
        /// Часть "LDAP".
        /// </summary>
        IHostBasePartLdapConfigSettings PartLdap { get; }

        #endregion Properties
    }
}