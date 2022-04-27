//Author Vlad Balkarov//vlad//

using Vlad2020.Core.Base.Resources.Errors;
using Vlad2020.Mods.Automation.Base.Parts.Angular.Config;
using Vlad2020.Mods.Automation.Base.Parts.Angular.Jobs.Code.Generate;
using Vlad2020.Mods.Automation.Base.Resources.Errors;
using Vlad2020.Mods.Automation.Base.Resources.Successes;

namespace Vlad2020.Mods.Automation.Base.Parts.Angular
{
    /// <summary>
    /// Мод "Automation". Основа. Часть "Angular". Задания.
    /// </summary>
    public class ModAutomationBasePartAngularJobs
    {
        #region Properties

        /// <summary>
        /// Задание на генерацию кода.
        /// </summary>
        public ModAutomationBasePartAngularJobCodeGenerateService JobCodeGenerate { get; private set; }

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
        public ModAutomationBasePartAngularJobs(            
            CoreBaseResourceErrors coreBaseResourceErrors,
            ModAutomationBaseResourceSuccesses resourceSuccesses,
            ModAutomationBaseResourceErrors resourceErrors,
            IModAutomationBasePartAngularConfigSettings configSettings,
            ModAutomationBasePartAngularService service
            )
        {
            JobCodeGenerate = new ModAutomationBasePartAngularJobCodeGenerateService(
                service.GenerateCode,
                coreBaseResourceErrors,
                resourceSuccesses,
                configSettings
                );
        }

        #endregion Constructor
    }
}
