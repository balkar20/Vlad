//Author Maxim Kuzmin//makc//

namespace Makc2020.Data.Base.Objects
{
    /// <summary>
    /// Данные. Основа. Объекты. Сущность "ProductDummyManyToMany".
    /// </summary>
    public partial class DataBaseObjectProductProductFeature
    {
        #region Properties

        /// <summary>
        /// Идентификатор объекта, где хранятся данные сущности "Product".
        /// </summary>
        public long ObjectProductId { get; set; }

        /// <summary>
        /// Идентификатор объекта, где хранятся данные сущности "DummyManyToMany".
        /// </summary>
        public long ObjectProductFeatureId { get; set; }

        #endregion Properties
    }
}
