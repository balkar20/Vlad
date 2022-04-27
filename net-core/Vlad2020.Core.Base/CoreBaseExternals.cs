//Author Vlad Balkarov//vlad//

using Vlad2020.Core.Base.Resources.Converting;
using Vlad2020.Core.Base.Resources.Errors;
using Microsoft.Extensions.Localization;

namespace Vlad2020.Core.Base
{
    /// <summary>
    /// Ядро. Основа. Внешнее.
    /// </summary>
    public class CoreBaseExternals
    {
        #region Properties

        /// <summary>
        /// Локализатор ресурса преобразования.
        /// </summary>
        public IStringLocalizer<CoreBaseResourceConverting> ResourceConvertingLocalizer { get; set; }

        /// <summary>
        /// Локализатор ресурса ошибок.
        /// </summary>
        public IStringLocalizer<CoreBaseResourceErrors> ResourceErrorsLocalizer { get; set; }

        #endregion Properties
    }
}
