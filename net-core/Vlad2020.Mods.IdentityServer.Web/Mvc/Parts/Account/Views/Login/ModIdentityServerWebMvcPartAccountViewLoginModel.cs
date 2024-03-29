﻿//Author Vlad Balkarov//vlad//

using Vlad2020.Mods.IdentityServer.Base.Enums;
using System.ComponentModel.DataAnnotations;

namespace Vlad2020.Mods.IdentityServer.Web.Mvc.Parts.Account.Views.Login
{
    /// <summary>
    /// Мод "IdentityServer". Веб. MVC. Часть "Account". Виды. Вход в систему. Модель.
    /// </summary>
    public class ModIdentityServerWebMvcPartAccountViewLoginModel
    {
        #region Properties

        /// <summary>
        /// Способ входа в систему.
        /// </summary>
        [Required]
        public ModIdentityServerBaseEnumLoginMethods LoginMethod { get; set; }

        /// <summary>
        /// Имя пользователя.
        /// </summary>
        [Required]
        public string Username { get; set; }

        /// <summary>
        /// Пароль.
        /// </summary>
        [Required]
        public string Password { get; set; }

        /// <summary>
        /// Признак необходимости запомнить вход в систему.
        /// </summary>
        public bool RememberLogin { get; set; }

        /// <summary>
        /// URL возврата.
        /// </summary>
        public string ReturnUrl { get; set; }

        #endregion Properties
    }
}
