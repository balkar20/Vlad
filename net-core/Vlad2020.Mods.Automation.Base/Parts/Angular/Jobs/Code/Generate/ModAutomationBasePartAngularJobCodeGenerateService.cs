//Author Vlad Balkarov//vlad//

using Vlad2020.Core.Base.Resources.Errors;
using Vlad2020.Mods.Automation.Base.Common.Code.Generate;
using Vlad2020.Mods.Automation.Base.Parts.Angular.Config;
using Vlad2020.Mods.Automation.Base.Resources.Successes;
using System;
using System.Threading.Tasks;

namespace Vlad2020.Mods.Automation.Base.Parts.Angular.Jobs.Code.Generate
{
    /// <summary>
    /// Мод "Automation". Основа. Часть "Angular". Задания. Код. Генерация. Сервис.
    /// </summary>
    public class ModAutomationBasePartAngularJobCodeGenerateService : ModAutomationBaseCommonJobCodeGenerateService
    {
        #region Constructors

        /// <inheritdoc/>
        public ModAutomationBasePartAngularJobCodeGenerateService(
            Func<ModAutomationBaseCommonJobCodeGenerateInput, Task> executable,
            CoreBaseResourceErrors coreBaseResourceErrors,
            ModAutomationBaseResourceSuccesses resourceSuccesses,
            IModAutomationBasePartAngularConfigSettings configSettings
            ) : base(executable, coreBaseResourceErrors, resourceSuccesses, configSettings)
        {
        }

        #endregion Constructors
    }
}