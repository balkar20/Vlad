//Author Vlad Balkarov//vlad//

using Vlad2020.Core.Base.Data;
using Vlad2020.Core.Base.Resources.Errors;
using Vlad2020.Data.Base;
using Vlad2020.Data.Entity.Db;
using Vlad2020.Mods.DummyMain.Base.Resources.Errors;
using Vlad2020.Mods.DummyMain.Base.Resources.Successes;
using Microsoft.Extensions.Localization;

namespace Vlad2020.Mods.DummyMain.Base
{
    /// <summary>
    /// Мод "DummyMain". Основа. Внешнее.
    /// </summary>
    public class ModDummyMainBaseExternals
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
        public IStringLocalizer<ModDummyMainBaseResourceErrors> ResourceErrorsLocalizer { get; set; }

        /// <summary>
        /// Локализатор ресурса успехов.
        /// </summary>
        public IStringLocalizer<ModDummyMainBaseResourceSuccesses> ResourceSuccessesLocalizer { get; set; }

        #endregion Properties
    }
}
