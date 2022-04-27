//Author Vlad Balkarov//vlad//

using Vlad2020.Core.Base.Data;
using Vlad2020.Core.Base.Resources.Errors;
using Vlad2020.Data.Base;
using Vlad2020.Data.Entity.Db;
using Vlad2020.Mods.Product.Base.Resources.Errors;
using Vlad2020.Mods.Product.Base.Resources.Successes;
using Microsoft.Extensions.Localization;

namespace Vlad2020.Mods.Product.Base
{
    /// <summary>
    /// Мод "Product". Основа. Внешнее.
    /// </summary>
    public class ModProductBaseExternals
    {
        #region Properties

        /// <summary>
        /// Ядро. Основа. Ресурсы. Ошибки.
        /// </summary>
        public CoreBaseResourceErrors CoreBaseResourceErrors { get; set; }

        /// <summary>
        /// Данные. Основа. Настройки.
        /// </summary>
        public DataBaseSettings DataBaseSettings { get; set; }

        /// <summary>
        /// Ядро. Основа. Данные. Поставщик.
        /// </summary>
        public ICoreBaseDataProvider CoreBaseDataProvider { get; set; }

        /// <summary>
        /// Данные. Entity Framework. База данных. Фабрика.
        /// </summary>
        public DataEntityDbFactory DataEntityDbFactory { get; set; }

        /// <summary>
        /// Локализатор ресурса ошибок.
        /// </summary>
        public IStringLocalizer<ModProductBaseResourceErrors> ResourceErrorsLocalizer { get; set; }

        /// <summary>
        /// Локализатор ресурса успехов.
        /// </summary>
        public IStringLocalizer<ModProductBaseResourceSuccesses> ResourceSuccessesLocalizer { get; set; }

        #endregion Properties
    }
}
