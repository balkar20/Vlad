//Author Vlad Balkarov//vlad//

using Vlad2020.Core.Base;
using Vlad2020.Data.Base;

namespace Vlad2020.Data.Entity.SqlServer
{
    /// <summary>
    /// Данные. Entity Framework. SQL Server. Внешнее.
    /// </summary>
    public class DataEntitySqlServerExternals
    {
        #region Properties

        /// <summary>
        /// Данные. Основа. Настройки.
        /// </summary>
        public DataBaseSettings DataBaseSettings { get; set; }

        /// <summary>
        /// Окружение.
        /// </summary>
        public CoreBaseEnvironment Environment { get; set; }

        #endregion Properties
    }
}
