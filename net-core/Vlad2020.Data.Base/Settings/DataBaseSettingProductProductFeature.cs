﻿//Author Vlad Balkarov//vlad//

using Vlad2020.Data.Base.Objects;

namespace Vlad2020.Data.Base.Settings
{
    /// <summary>
    /// Данные. Основа. Настройки. Сущность "DummyMainProductFeature".
    /// </summary>
    public class DataBaseSettingProductProductFeature : DataBaseSetting
    {
        #region Constants

        /// <summary>
        /// Таблица в базе данных.
        /// </summary>
        internal const string DB_TABLE = "ProductProductFeature";

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
        /// Внешний ключ в базе данных к сущности "DummyMain".
        /// </summary>
        public string DbForeignKeyToProduct => CreateNameOfForeignKey(DbTable, DataBaseSettingProduct.DB_TABLE);

        /// <summary>
        /// Внешний ключ в базе данных к сущности "ProductFeature".
        /// </summary>
        public string DbForeignKeyToProductFeature => CreateNameOfForeignKey(DbTable, DataBaseSettingProductFeature.DB_TABLE);

        /// <summary>
        /// Колонка в базе данных для поля идентификатора сущности "DummyMain".
        /// </summary>
        public string DbColumnForProductId => CreateNameOfColumn(DataBaseSettingProduct.DB_TABLE, nameof(DataBaseObjectProduct.Id));

        /// <summary>
        /// Колонка в базе данных для поля идентификатора сущности "ProductFeature".
        /// </summary>
        public string DbColumnForProductFeatureId => CreateNameOfColumn(DataBaseSettingProductFeature.DB_TABLE, nameof(DataBaseObjectProductFeature.Id));

        #endregion Properties
    }
}
