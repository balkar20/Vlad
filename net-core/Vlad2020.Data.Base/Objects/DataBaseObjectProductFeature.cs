//Author Vlad Balkarov//vlad//

namespace Vlad2020.Data.Base.Objects
{
    /// <summary>
    /// Данные. Основа. Объекты. Сущность "ProductFeature".
    /// </summary>
    public partial class DataBaseObjectProductFeature
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