//Author Vlad Balkarov//vlad//

using Vlad2020.Mods.Automation.Base.Parts.Angular.Config;
using Vlad2020.Mods.Automation.Base.Parts.NetCore.Config;

namespace Vlad2020.Mods.Automation.Base.Config
{
    /// <summary>
    /// Мод "Automation". Основа. Конфигурация. Настройки. Интерфейс.
    /// </summary>
    public interface IModAutomationBaseConfigSettings
    {
        #region Properties

        /// <summary>
        /// Часть "Angular".
        /// </summary>
        IModAutomationBasePartAngularConfigSettings PartAngular { get; }

        /// <summary>
        /// Часть "NetCore".
        /// </summary>
        IModAutomationBasePartNetCoreConfigSettings PartNetCore { get; }

        #endregion Properties
    }
}