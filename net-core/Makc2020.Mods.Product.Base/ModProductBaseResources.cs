//Author Maxim Kuzmin//makc//

using Makc2020.Mods.Product.Base.Resources.Errors;
using Makc2020.Mods.Product.Base.Resources.Successes;
using Microsoft.Extensions.Localization;

namespace Makc2020.Mods.Product.Base
{
    /// <summary>
    /// Мод "Product". Основа. Ресурсы.
    /// </summary>
    public class ModProductBaseResources
    {
        #region Properties

        /// <summary>
        /// Ошибки.
        /// </summary>
        public ModProductBaseResourceErrors Errors { get; set; }

        /// <summary>
        /// Успехи.
        /// </summary>
        public ModProductBaseResourceSuccesses Successes { get; set; }

        #endregion Properties

        #region Constructor

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="resourceErrorsLocalizer">Локализатор ресурсов ошибок.</param>
        /// <param name="resourceSuccessesLocalizer">Локализатор ресурсов успехов.</param>
        public ModProductBaseResources(
            IStringLocalizer<ModProductBaseResourceErrors> resourceErrorsLocalizer,
            IStringLocalizer<ModProductBaseResourceSuccesses> resourceSuccessesLocalizer
            )
        {
            Errors = new ModProductBaseResourceErrors(resourceErrorsLocalizer);
            Successes = new ModProductBaseResourceSuccesses(resourceSuccessesLocalizer);
        }

        #endregion Constructor
    }
}
