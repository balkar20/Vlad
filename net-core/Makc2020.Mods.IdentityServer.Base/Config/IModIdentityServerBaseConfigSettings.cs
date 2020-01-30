﻿//Author Maxim Kuzmin//makc//

using Vlad2020.Mods.IdentityServer.Base.Config.Enums;
using Vlad2020.Mods.IdentityServer.Base.Config.Settings;

namespace Vlad2020.Mods.IdentityServer.Base.Config
{
    /// <summary>
    /// Мод "IdentityServer". Основа. Конфигурация. Настройки. Интерфейс.
    /// </summary>
    public interface IModIdentityServerBaseConfigSettings
    {
        #region Properties

        /// <summary>
        /// Ресурсы API.
        /// </summary>
        IModIdentityServerBaseConfigSettingApiResource[] ApiResources { get; }

        /// <summary>
        /// Клиенты.
        /// </summary>
        IModIdentityServerBaseConfigSettingClient[] Clients { get; }

        /// <summary>
        /// Ресурсы идентичности.
        /// </summary>
        ModIdentityServerBaseConfigEnumIdentityResources[] IdentityResources { get; }

        #endregion Properties
    }
}