﻿//Author Maxim Kuzmin//makc//

using Vlad2020.Core.Base;
using Vlad2020.Core.Base.Common.Config.Providers;

namespace Vlad2020.Mods.Auth.Base.Config
{
    /// <summary>
    /// Мод "Auth". Основа. Конфигурация. Поставщик.
    /// </summary>
    public class ModAuthBaseConfigProvider : CoreBaseCommonConfigProviderJson<ModAuthBaseConfigSettings>
    {
        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="settings">Настройки.</param>
        /// <param name="filePath">Путь к файлу.</param>
        /// <param name="environment">Окружение.</param>
        public ModAuthBaseConfigProvider(
            ModAuthBaseConfigSettings settings,
            string filePath,
            CoreBaseEnvironment environment
            )
            : base(settings, filePath, environment)
        {
        }

        #endregion Constructors
    }
}
