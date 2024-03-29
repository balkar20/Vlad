﻿//Author Vlad Balkarov//vlad//

using Vlad2020.Data.Base.Objects;

namespace Vlad2020.Data.Base.Settings
{
    /// <summary>
    /// Данные. Основа. Настройки. Сущность "RoleClaim".
    /// </summary>
    public class DataBaseSettingRoleClaim : DataBaseSetting
    {
        #region Constants

        /// <summary>
        /// Таблица в базе данных.
        /// </summary>
        internal const string DB_TABLE = "RoleClaim";

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
        /// Внешний ключ в базе данных к сущности "Role".
        /// </summary>
        public string DbForeignKeyToRole => CreateNameOfForeignKey(DbTable, DataBaseSettingRole.DB_TABLE);

        /// <summary>
        /// Наименование индекса в базе данных для поля "RoleId".
        /// </summary>
        public string DbIndexForRoleId=> CreateNameOfIndex(DbTable, nameof(DataBaseObjectRoleClaim.RoleId));

        #endregion Properties
    }
}
