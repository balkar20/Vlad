//Author Vlad Balkarov//vlad//

using Vlad2020.Core.Base;
using Vlad2020.Core.Base.Common.Config.Providers;

namespace Vlad2020.Mods.IdentityServer.Base.Config
{
    /// <summary>
    /// Мод "IdentityServer". Основа. Конфигурация. Поставщик.
    /// </summary>
    public class ModIdentityServerBaseConfigProvider :
        CoreBaseCommonConfigProviderJson<ModIdentityServerBaseConfigSettings>
    {
        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="settings">Настройки.</param>
        /// <param name="filePath">Путь к файлу.</param>
        /// <param name="environment">Окружение.</param>
        public ModIdentityServerBaseConfigProvider(
            ModIdentityServerBaseConfigSettings settings,
            string filePath,
            CoreBaseEnvironment environment
            )
            : base(settings, filePath, environment)
        {
        }

        #endregion Constructors
    }
}
