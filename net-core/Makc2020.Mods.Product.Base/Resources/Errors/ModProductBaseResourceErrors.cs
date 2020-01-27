//Author Maxim Kuzmin//makc//

using Microsoft.Extensions.Localization;

namespace Makc2020.Mods.Product.Base.Resources.Errors
{
    /// <summary>
    /// Мод "Product". Основа. Ресурсы. Ошибки.
    /// </summary>
    public class ModProductBaseResourceErrors
    {
        #region Properties

        private IStringLocalizer<ModProductBaseResourceErrors> Localizer { get; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="localizer">Локализатор.</param>
        public ModProductBaseResourceErrors(IStringLocalizer<ModProductBaseResourceErrors> localizer)
        {
            Localizer = localizer;
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        /// Получить строку форматирования "Значение поля \"{0}\" не уникально".
        /// </summary>
        /// <returns>Строка.</returns>
        public string GetStringFormatFieldValueIsNotUnique()
        {
            return Localizer["Значение поля \"{0}\" не уникально"];
        }

        #endregion Public methods
    }
}