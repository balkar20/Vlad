﻿//Author Vlad Balkarov//vlad//

using Vlad2020.Core.Base;
using Vlad2020.Core.Base.Common.Config.Providers;

namespace Vlad2020.Mods.Product.Base.Config
{
    /// <summary>
    /// Мод "Product". Основа. Конфигурация. Поставщик.
    /// </summary>
    public class ModProductBaseConfigProvider : CoreBaseCommonConfigProviderJson<ModProductBaseConfigSettings>
    {
        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="settings">Настройки.</param>
        /// <param name="filePath">Путь к файлу.</param>
        /// <param name="environment">Окружение.</param>
        public ModProductBaseConfigProvider(
            ModProductBaseConfigSettings settings,
            string filePath,
            CoreBaseEnvironment environment
            )
            : base(settings, filePath, environment)
        {
        }

        #endregion Constructors
    }
}
