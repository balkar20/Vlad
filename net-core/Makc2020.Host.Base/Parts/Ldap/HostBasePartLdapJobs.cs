//Author Maxim Kuzmin//makc//

using Vlad2020.Core.Base.Resources.Errors;
using Vlad2020.Host.Base.Parts.Ldap.Jobs.Login;
using Vlad2020.Host.Base.Parts.Ldap.Resources.Errors;
using Vlad2020.Host.Base.Parts.Ldap.Resources.Successes;

namespace Vlad2020.Host.Base.Parts.Ldap
{
    /// <summary>
    /// Хост. Основа. Часть "LDAP". Задания.
    /// </summary>
    public class HostBasePartLdapJobs
    {
        #region Properties

        /// <summary>
        /// Задание на вход в систему.
        /// </summary>
        public HostBasePartLdapJobLoginService JobLogin { get; private set; }

        #endregion Properties

        #region Constructor

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="coreBaseResourceErrors">Ядро. Основа. Ресурсы. Ошибки.</param>
        /// <param name="resourceSuccesses">Ресурсы. Успехи.</param>
        /// <param name="resourceErrors">Ресурсы. Ошибки.</param>
        /// <param name="service">Сервис.</param>
        public HostBasePartLdapJobs(
            CoreBaseResourceErrors coreBaseResourceErrors,
            HostBasePartLdapResourceSuccesses resourceSuccesses,
            HostBasePartLdapResourceErrors resourceErrors,
            HostBasePartLdapService service
            )
        {
            JobLogin = new HostBasePartLdapJobLoginService(
                service.Login,
                coreBaseResourceErrors,
                resourceSuccesses,
                resourceErrors
                );
        }

        #endregion Constructor
    }
}
