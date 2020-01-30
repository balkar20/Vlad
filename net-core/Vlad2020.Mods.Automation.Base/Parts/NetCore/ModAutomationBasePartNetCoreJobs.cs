﻿//Author Maxim Kuzmin//makc//

using Vlad2020.Core.Base.Resources.Errors;
using Vlad2020.Mods.Automation.Base.Parts.NetCore.Config;
using Vlad2020.Mods.Automation.Base.Parts.NetCore.Jobs.Code.Generate;
using Vlad2020.Mods.Automation.Base.Resources.Errors;
using Vlad2020.Mods.Automation.Base.Resources.Successes;

namespace Vlad2020.Mods.Automation.Base.Parts.NetCore
{
    /// <summary>
    /// Мод "Automation". Основа. Часть "NetCore". Задания.
    /// </summary>
    public class ModAutomationBasePartNetCoreJobs
    {
        #region Properties

        /// <summary>
        /// Задание на генерацию кода.
        /// </summary>
        public ModAutomationBasePartNetCoreJobCodeGenerateService JobCodeGenerate { get; private set; }

        #endregion Properties

        #region Constructor

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="coreBaseResourceErrors">Ядро. Основа. Ресурсы. Ошибки.</param>
        /// <param name="resourceSuccesses">Ресурсы. Успехи.</param>
        /// <param name="resourceErrors">Ресурсы. Ошибки.</param>
        /// <param name="configSettings">Конфигурационные настройки.</param>
        /// <param name="service">Сервис.</param>
        public ModAutomationBasePartNetCoreJobs(            
            CoreBaseResourceErrors coreBaseResourceErrors,
            ModAutomationBaseResourceSuccesses resourceSuccesses,
            ModAutomationBaseResourceErrors resourceErrors,
            IModAutomationBasePartNetCoreConfigSettings configSettings,
            ModAutomationBasePartNetCoreService service
            )
        {
            JobCodeGenerate = new ModAutomationBasePartNetCoreJobCodeGenerateService(
                service.GenerateCode,
                coreBaseResourceErrors,
                resourceSuccesses,
                configSettings
                );
        }

        #endregion Constructor
    }
}
