﻿//Author Vlad Balkarov//vlad//

using Vlad2020.Data.Base.Objects;

namespace Vlad2020.Data.Base.Settings
{
    /// <summary>
    /// Данные. Основа. Настройки. Сущность "User".
    /// </summary>
    public class DataBaseSettingUser : DataBaseSetting
    {
        #region Constants

        /// <summary>
        /// Таблица в базе данных.
        /// </summary>
        internal const string DB_TABLE = "User";

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
        /// Наименование индекса в базе данных для поля "NormalizedEmail".
        /// </summary>
        public string DbIndexForNormalizedEmail => CreateNameOfIndex(DbTable, nameof(DataBaseObjectUser.NormalizedEmail));

        /// <summary>
        /// Наименование уникального индекса в базе данных для поля "NormalizedUserName".
        /// </summary>
        public string DbUniqueIndexForNormalizedUserName => CreateNameOfUniqueIndex(DbTable, nameof(DataBaseObjectUser.NormalizedUserName));

        #endregion Properties
    }
}
