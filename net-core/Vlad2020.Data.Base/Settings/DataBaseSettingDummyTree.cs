﻿//Author Vlad Balkarov//vlad//

using Vlad2020.Data.Base.Objects;

namespace Vlad2020.Data.Base.Settings
{
    /// <summary>
    /// Данные. Основа. Настройки. Сущность "DummyTree".
    /// </summary>
    public class DataBaseSettingDummyTree : DataBaseSetting
    {
        #region Constants

        /// <summary>
        /// Таблица в базе данных.
        /// </summary>
        internal const string DB_TABLE = "DummyTree";

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
        public string DbForeignKeyToDummyMain => CreateNameOfForeignKey(DbTable, DataBaseSettingDummyMain.DB_TABLE);

        /// <summary>
        /// Внешний ключ в базе данных к родительской сущности "DummyTree".
        /// </summary>
        public string DbForeignKeyToParentDummyTree => CreateNameOfForeignKey(DbTable, DbTable, nameof(DataBaseObjectDummyTree.ParentId));

        /// <summary>
        /// Колонка в базе данных для поля идентификатора сущности "DummyMain".
        /// </summary>
        public string DbColumnForDummyMainId => CreateNameOfColumn(DataBaseSettingDummyMain.DB_TABLE, nameof(DataBaseObjectDummyMain.Id));

        /// <summary>
        /// Наименование уникального индекса в базе данных для полей "Id" и "ParentId".
        /// </summary>
        public string DbUniqueIndexForIdAndParentId => CreateNameOfUniqueIndex(DbTable, nameof(DataBaseObjectDummyTree.Id), nameof(DataBaseObjectDummyTree.ParentId));

        /// <summary>
        /// Наименование индекса в базе данных для поля "DummyMainId".
        /// </summary>
        public string DbIndexForDummyMainId => CreateNameOfIndex(DbTable, DbColumnForDummyMainId);

        #endregion Properties
    }
}