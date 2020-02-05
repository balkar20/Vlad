//Author Maxim Kuzmin//makc//

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vlad2020.Data.Base.Objects
{
    /// <summary>
    /// Данные. Основа. Объекты. Сущность "Product".
    /// </summary>
    public class DataBaseObjectProduct
    {
        #region Properties

        /// <summary>
        /// Идентификатор.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Имя.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Идентификатор объекта, где хранятся данные сущности "ProductCategory".
        /// </summary>
        public long ObjectProductCategoryId { get; set; }

        /// <summary>
        /// Свойство, содержащее десятичную дробь.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Свойство, содержащее строку.
        /// </summary>
        public string Description { get; set; }

        #endregion Properties
    }
}