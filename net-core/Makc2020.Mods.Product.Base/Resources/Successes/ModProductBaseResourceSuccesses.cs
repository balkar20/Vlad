//Author Maxim Kuzmin//makc//

using Microsoft.Extensions.Localization;

namespace Makc2020.Mods.Product.Base.Resources.Successes
{
    /// <summary>
    /// Мод "Product". Основа. Ресурсы. Успехи.
    /// </summary>
    public class ModProductBaseResourceSuccesses
    {
        #region Properties

        private IStringLocalizer<ModProductBaseResourceSuccesses> Localizer { get; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="localizer">Локализатор.</param>
        public ModProductBaseResourceSuccesses(IStringLocalizer<ModProductBaseResourceSuccesses> localizer)
        {
            Localizer = localizer;
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        /// Получить строку форматирования "Объект с Id = {0} удалён".
        /// </summary>
        /// <returns>Строка.</returns>
        public string GetStringFormatObjectWithIdIsDeleted()
        {
            return Localizer["Объект с Id = {0} удалён"];
        }

        /// <summary>
        /// Получить строку форматирования "Объект с Id = {0} вставлен".
        /// </summary>
        /// <returns>Строка.</returns>
        public string GetStringFormatObjectWithIdIsInserted()
        {
            return Localizer["Объект с Id = {0} вставлен"];
        }

        /// <summary>
        /// Получить строку форматирования "Объект с Id = {0} обновлён".
        /// </summary>
        /// <returns>Строка.</returns>
        public string GetStringFormatObjectWithIdIsUpdated()
        {
            return Localizer["Объект с Id = {0} обновлён"];
        }

        #endregion Public methods
    }
}