//Author Vlad Balkarov//vlad//

using Vlad2020.Core.Base.Data;

namespace Vlad2020.Core.Data.SqlServer
{
    /// <summary>
    /// Ядро. Данные. SQL Server. Контекст.
    /// </summary>
    public class CoreDataSqlServerContext
    {
        #region Properties

        /// <summary>
        /// Поставщик.
        /// </summary>
        public ICoreBaseDataProvider Provider { get; private set; } = new CoreDataSqlServerProvider();

        #endregion Properties
    }
}
