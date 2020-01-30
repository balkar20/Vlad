﻿//Author Maxim Kuzmin//makc//

namespace Vlad2020.Mods.Automation.Base.Common.Config
{
    /// <summary>
    /// Мод "Automation". Основа. Общее. Конфигурация. Настройки.
    /// </summary>
    public class ModAutomationBaseCommonConfigSettings : IModAutomationBaseCommonConfigSettings
    {
        #region Properties

        /// <inheritdoc/>
        public string SourceEntityName { get; set; }

        /// <inheritdoc/>
        public string SourcePath { get; set; }

        /// <inheritdoc/>
        public string TargetEntityName { get; set; }

        /// <inheritdoc/>
        public string TargetPath { get; set; }

        #endregion Properties
    }
}