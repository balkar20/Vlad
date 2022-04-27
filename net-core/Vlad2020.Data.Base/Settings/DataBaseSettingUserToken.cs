﻿//Author Vlad Balkarov//vlad//

using Vlad2020.Data.Base.Objects;

namespace Vlad2020.Data.Base.Settings
{
    /// <summary>
    /// Данные. Основа. Настройки. Сущность "UserToken".
    /// </summary>
    public class DataBaseSettingUserToken : DataBaseSetting
    {
        #region Constants

        /// <summary>
        /// Таблица в базе данных.
        /// </summary>
        internal const string DB_TABLE = "UserToken";

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
        /// Внешний ключ в базе данных к сущности "User".
        /// </summary>
        public string DbForeignKeyToUser => CreateNameOfForeignKey(DbTable, DataBaseSettingUser.DB_TABLE);

        #endregion Properties
    }
}
