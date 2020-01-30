//Author Maxim Kuzmin//makc//

using Vlad2020.Host.Base.Parts.Ldap.Resources.Errors;
using Vlad2020.Host.Base.Parts.Ldap.Resources.Successes;
using Microsoft.Extensions.Localization;

namespace Vlad2020.Host.Base.Parts.Ldap
{
    /// <summary>
    /// Хост. Основа. Часть "LDAP". Ресурсы.
    /// </summary>
    public class HostBasePartLdapResources
    {
        #region Properties

        /// <summary>
        /// Ошибки.
        /// </summary>
        public HostBasePartLdapResourceErrors Errors { get; set; }

        /// <summary>
        /// Успехи.
        /// </summary>
        public HostBasePartLdapResourceSuccesses Successes { get; set; }

        #endregion Properties

        #region Constructor

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="resourceErrorsLocalizer">Локализатор ресурсов ошибок.</param>
        /// <param name="resourceSuccessesLocalizer">Локализатор ресурсов успехов.</param>
        public HostBasePartLdapResources(
            IStringLocalizer<HostBasePartLdapResourceErrors> resourceErrorsLocalizer,
            IStringLocalizer<HostBasePartLdapResourceSuccesses> resourceSuccessesLocalizer
            )
        {
            Errors = new HostBasePartLdapResourceErrors(resourceErrorsLocalizer);
            Successes = new HostBasePartLdapResourceSuccesses(resourceSuccessesLocalizer);
        }

        #endregion Constructor
    }
}
