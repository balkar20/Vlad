//Author Maxim Kuzmin//makc//

using Makc2020.Data.Base.Objects;

namespace Makc2020.Mods.Product.Base.Jobs.Item.Get
{
    /// <summary>
    /// Мод "Product". Основа. Задания. Элемент. Получение. Вывод.
    /// </summary>
    public class ModProductBaseJobItemGetOutput
    {
        #region Properties

        /// <summary>
        /// Объект, где хранятся данные сущности "Product".
        /// </summary>
        public DataBaseObjectProduct ObjectProduct { get; set; }

        /// <summary>
        /// Объекты, где хранятся данные сущности "DummyManyToMany".
        /// </summary>
        public DataBaseObjectProductFeature[] ObjectsProductFeature { get; set; }

        /// <summary>
        /// Объекты, где хранятся данные сущности "ProductDummyManyToMany".
        /// </summary>
        public DataBaseObjectProductProductFeature[] ObjectsProductProductFeature { get; set; }

        /// <summary>
        /// Объект, где хранятся данные сущности "DummyOneToMany".
        /// </summary>
        public DataBaseObjectProductCategory ObjectProductCategory { get; set; }

        #endregion Properties
    }
}