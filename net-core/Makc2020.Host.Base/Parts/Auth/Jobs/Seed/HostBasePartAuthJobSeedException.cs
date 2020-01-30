//Author Maxim Kuzmin//makc//

using Vlad2020.Host.Base.Common.Identity;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Vlad2020.Host.Base.Parts.Auth.Jobs.Seed
{
    /// <summary>
    /// Хост. Основа. Часть "Auth". Задания. Посев. Исключение.
    /// </summary>
    public class HostBasePartAuthJobSeedException : HostBaseCommonIdentityException
    {
        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="errors">Ошибки.</param>
        public HostBasePartAuthJobSeedException(IEnumerable<IdentityError> errors)
            : base(errors)
        {
        }

        #endregion Constructors
    }
}
