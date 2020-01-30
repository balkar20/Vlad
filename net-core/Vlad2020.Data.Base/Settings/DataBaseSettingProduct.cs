//Author Maxim Kuzmin//makc//

using Vlad2020.Data.Base.Objects;

namespace Vlad2020.Data.Base.Settings
{
    /// <summary>
    /// Данные. Основа. Настройки. Сущность "Product".
    /// </summary>
    public class DataBaseSettingProduct : DataBaseSetting
    {
        #region Constants

        /// <summary>
        /// Таблица в базе данных.
        /// </summary>
        internal const string DB_TABLE = "Product";

        #endregion Constants

        #region Properties

        /// <summary>
        /// Таблица в базе данных.
        /// </summary>
        public string DbTable => DB_TABLE;

        /// <summary>
        /// Схема в базе данных.
        /// </summary>
        public string DbSchema => CreateNameOfSchema();

        /// <summary>
        /// Таблица со схемой в базе данных.
        /// </summary>
        public string DbTableWithSchema => CreateFullName(DbSchema, DbTable);

        /// <summary>
        /// Первичный ключ в базе данных.
        /// </summary>
        public string DbPrimaryKey => CreateNameOfPrimaryKey(DbTable);

        /// <summary>
        /// Внешний ключ в базе данных к сущности "DummyOneToMany".
        /// </summary>
        public string DbForeignKeyToProductCategory => CreateNameOfForeignKey(DbTable, DataBaseSettingProductCategory.DB_TABLE);

        /// <summary>
        /// Колонка в базе данных для поля идентификатора сущности "DummyOneToMany".
        /// </summary>
        public string DbColumnForProductCategoryId => CreateNameOfColumn(DataBaseSettingProductCategory.DB_TABLE, nameof(DataBaseObjectProductCategory.Id));

        /// <summary>
        /// Наименование уникального индекса в базе данных для поля "Name".
        /// </summary>
        public string DbUniqueIndexForName => CreateNameOfUniqueIndex(DbTable, nameof(DataBaseObjectProduct.Name));

        #endregion Properties
    }
}
