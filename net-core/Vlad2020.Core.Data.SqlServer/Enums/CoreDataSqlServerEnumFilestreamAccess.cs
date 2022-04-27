//Author Vlad Balkarov//vlad//

namespace Vlad2020.Core.Data.SqlServer.Enums
{
    /// <summary>
    /// Ядро. Данные. SQL Server. Перечисление. Уровни доступа к файловому потоку.
    /// </summary>
    public enum CoreDataSqlServerEnumFilestreamAccess : uint
    {
        /// <summary>
        /// Прочитать.
        /// </summary>
        Read,
        /// <summary>
        /// Записать.
        /// </summary>
        Write,
        /// <summary>
        /// Прочитать и записать.
        /// </summary>
        ReadWrite,
    }
}
