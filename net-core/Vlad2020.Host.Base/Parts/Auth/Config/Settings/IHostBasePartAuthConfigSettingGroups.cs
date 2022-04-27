﻿//Author Vlad Balkarov//vlad//

namespace Vlad2020.Host.Base.Parts.Auth.Config.Settings
{
    /// <summary>
    /// Хост. Основа. Часть "Auth". Конфигурация. Настройки. Интерфейс.
    /// </summary>
    public interface IHostBasePartAuthConfigSettingGroups
    {
        #region Properties

        /// <summary>
        /// Администраторы.
        /// </summary>
        string[] Administrators { get; }

        #endregion Properties
    }
}