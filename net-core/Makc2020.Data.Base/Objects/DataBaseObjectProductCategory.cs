//Author Maxim Kuzmin//makc//

namespace Makc2020.Data.Base.Objects
{
    /// <summary>
    /// Данные. Основа. Объекты. Сущность "ProductCategory".
    /// </summary>
    public partial class DataBaseObjectProductCategory
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

        #endregion Properties
    }
}