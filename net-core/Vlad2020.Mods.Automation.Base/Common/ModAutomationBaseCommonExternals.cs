//Author Vlad Balkarov//vlad//

using Vlad2020.Core.Base.Resources.Errors;
using Vlad2020.Mods.Automation.Base.Resources.Errors;
using Vlad2020.Mods.Automation.Base.Resources.Successes;
using Microsoft.Extensions.Localization;

namespace Vlad2020.Mods.Automation.Base.Common
{
    /// <summary>
    /// Мод "Automation". Основа. Общее. Внешнее.
    /// </summary>
    public class ModAutomationBaseCommonExternals
    {
        #region Properties

        /// <summary>
        /// Ядро. Основа. Ресурсы. Ошибки.
        /// </summary>
        public CoreBaseResourceErrors CoreBaseResourceErrors { get; set; }

        /// <summary>
        /// Ресурс ошибок.
        /// </summary>
        public ModAutomationBaseResourceErrors ResourceErrors { get; set; }

        /// <summary>
        /// Ресурс успехов.
        /// </summary>
        public ModAutomationBaseResourceSuccesses ResourceSuccesses { get; set; }

        #endregion Properties
    }
}
