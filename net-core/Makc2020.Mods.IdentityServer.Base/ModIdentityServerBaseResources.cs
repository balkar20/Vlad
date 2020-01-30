﻿//Author Maxim Kuzmin//makc//

using Vlad2020.Mods.Auth.Base.Resources.Errors;
using Vlad2020.Mods.IdentityServer.Base.Resources.Successes;
using Vlad2020.Mods.IdentityServer.Base.Resources.Titles;
using Microsoft.Extensions.Localization;

namespace Vlad2020.Mods.IdentityServer.Base
{
    /// <summary>
    /// Мод "IdentityServer". Основа. Ресурсы.
    /// </summary>
    public class ModIdentityServerBaseResources
    {
        #region Properties

        /// <summary>
        /// Ошибки.
        /// </summary>
        public ModIdentityServerBaseResourceErrors Errors { get; set; }

        /// <summary>
        /// Успехи.
        /// </summary>
        public ModIdentityServerBaseResourceSuccesses Successes { get; set; }

        /// <summary>
        /// Заголовки.
        /// </summary>
        public ModIdentityServerBaseResourceTitles Titles { get; set; }

        #endregion Properties

        #region Constructor

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="resourceTitlesLocalizer">Локализатор ресурсов заголовков.</param>
        public ModIdentityServerBaseResources(
            IStringLocalizer<ModIdentityServerBaseResourceErrors> resourceErrorsLocalizer,
            IStringLocalizer<ModIdentityServerBaseResourceSuccesses> resourceSuccessesLocalizer,
            IStringLocalizer<ModIdentityServerBaseResourceTitles> resourceTitlesLocalizer
            )
        {
            Errors = new ModIdentityServerBaseResourceErrors(resourceErrorsLocalizer);
            Successes = new ModIdentityServerBaseResourceSuccesses(resourceSuccessesLocalizer);
            Titles = new ModIdentityServerBaseResourceTitles(resourceTitlesLocalizer);
        }

        #endregion Constructor
    }
}
