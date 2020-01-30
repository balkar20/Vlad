//Author Maxim Kuzmin//makc//

using Vlad2020.Core.Base.Resources.Errors;
using Vlad2020.Mods.Automation.Base.Common.Code.Generate;
using Vlad2020.Mods.Automation.Base.Parts.NetCore.Config;
using Vlad2020.Mods.Automation.Base.Resources.Successes;
using System;
using System.Threading.Tasks;

namespace Vlad2020.Mods.Automation.Base.Parts.NetCore.Jobs.Code.Generate
{
    /// <summary>
    /// Мод "Automation". Основа. Часть "NetCore". Задания. Код. Генерация. Сервис.
    /// </summary>
    public class ModAutomationBasePartNetCoreJobCodeGenerateService : ModAutomationBaseCommonJobCodeGenerateService
    {
        #region Constructors

        /// <inheritdoc/>
        public ModAutomationBasePartNetCoreJobCodeGenerateService(
            Func<ModAutomationBaseCommonJobCodeGenerateInput, Task> executable,
            CoreBaseResourceErrors coreBaseResourceErrors,
            ModAutomationBaseResourceSuccesses resourceSuccesses,
            IModAutomationBasePartNetCoreConfigSettings configSettings
            ) : base(executable, coreBaseResourceErrors, resourceSuccesses, configSettings)
        {
        }

        #endregion Constructors
    }
}