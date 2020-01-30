//Author Maxim Kuzmin//makc//

using Vlad2020.Core.Base.Resources.Errors;
using Vlad2020.Data.Entity.Db;

namespace Vlad2020.Data.Entity
{
    /// <summary>
    /// Данные. Entity Framework. Внешнее.
    /// </summary>
    public class DataEntityExternals
    {
        #region Properties

        /// <summary>
        /// Ядро. Основа. Ресурсы. Ошибки.
        /// </summary>
        public CoreBaseResourceErrors CoreBaseResourceErrors { get; set; }

        /// <summary>
        /// Данные. Entity Framework. База данных. Фабрика.
        /// </summary>
        public DataEntityDbFactory DataEntityDbFactory { get; set; }

        #endregion Properties
    }
}
