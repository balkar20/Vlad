﻿//Author Vlad Balkarov//vlad//

namespace Vlad2020.Data.Base.Objects
{
    /// <summary>
    /// Данные. Основа. Объекты. Сущность "DummyMainDummyManyToMany".
    /// </summary>
    public partial class DataBaseObjectDummyMainDummyManyToMany
    {
        #region Properties

        /// <summary>
        /// Идентификатор объекта, где хранятся данные сущности "DummyMain".
        /// </summary>
        public long ObjectDummyMainId { get; set; }

        /// <summary>
        /// Идентификатор объекта, где хранятся данные сущности "DummyManyToMany".
        /// </summary>
        public long ObjectDummyManyToManyId { get; set; }

        #endregion Properties
    }
}
