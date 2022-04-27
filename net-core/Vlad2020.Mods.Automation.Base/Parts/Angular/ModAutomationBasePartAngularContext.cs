﻿//Author Vlad Balkarov//vlad//

using Vlad2020.Mods.Automation.Base.Parts.Angular.Config;

namespace Vlad2020.Mods.Automation.Base.Parts.Angular
{
    /// <summary>
    /// Мод "Automation". Основа. Часть "Angular". Контекст.
    /// </summary>
    public class ModAutomationBasePartAngularContext
    {
        #region Properties

        /// <summary>
        /// Задания.
        /// </summary>
        public ModAutomationBasePartAngularJobs Jobs { get; private set; }

        /// <summary>
        /// Сервис.
        /// </summary>
        public ModAutomationBasePartAngularService Service { get; private set; }

        #endregion Properties

        #region Constructor

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="configSettings">Конфигурационные настройки.</param>
        /// <param name="externals">Внешнее.</param>
        public ModAutomationBasePartAngularContext(
            IModAutomationBasePartAngularConfigSettings configSettings,
            ModAutomationBasePartAngularExternals externals
            )
        {
            Service = new ModAutomationBasePartAngularService();

            Jobs = new ModAutomationBasePartAngularJobs(
                externals.CoreBaseResourceErrors,
                externals.ResourceSuccesses,
                externals.ResourceErrors,
                configSettings,
                Service
                );
        }

        #endregion Constructor
    }
}
