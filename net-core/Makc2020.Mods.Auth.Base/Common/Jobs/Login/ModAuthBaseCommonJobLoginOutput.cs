//Author Maxim Kuzmin//makc//

using Vlad2020.Host.Base.Parts.Auth;

namespace Vlad2020.Mod.Auth.Base.Common.Jobs.Login
{
    /// <summary>
    /// Мод "Auth". Основа. Общее. Задания. Вход в систему. Вывод.
    /// </summary>
    public class ModAuthBaseCommonJobLoginOutput
    {
        #region Properties

        /// <summary>
        /// Имя пользователя.
        /// </summary>
        public HostBasePartAuthUser CurrentUser { get; set; }

        #endregion Properties
    }
}
