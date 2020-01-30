//Author Maxim Kuzmin//makc//

using Vlad2020.Data.Base.Loaders;
using Vlad2020.Data.Base.Objects;

namespace Vlad2020.Data.Entity.Objects
{
    /// <summary>
    /// Данные. Entity Framework. Объекты. Сущность "ProductDummyManyToMany".
    /// </summary>
    public class DataEntityObjectProductProductFeature : DataBaseObjectProductProductFeature
    {
        #region Properties

        /// <summary>
        /// Объект, где хранятся данные сущности "Product".
        /// </summary>
        public DataEntityObjectProduct ObjectProduct { get; set; }

        /// <summary>
        /// Объект, где хранятся данные сущности "DummyManyToMany".
        /// </summary>
        public DataEntityObjectProductFeature ObjectProductFeature { get; set; }

        #endregion Properties

        #region Public methods

        /// <summary>
        /// Создать объект Entity Framework, где хранятся данные сущности "ProductDummyManyToMany".
        /// </summary>
        /// <param name="source">Источник данных.</param>
        /// <returns>Объект Entity Framework, где хранятся данные сущности "ProductDummyManyToMany".</returns>
        public static DataEntityObjectProductProductFeature Create(DataBaseObjectProductProductFeature source)
        {
            var result = new DataEntityObjectProductProductFeature();
            new DataBaseLoaderProductDummyManyToMany(result).LoadDataFrom(source);
            return result;
        }

        /// <summary>
        /// Создать объект, где хранятся данные сущности "ProductDummyManyToMany".
        /// </summary>
        /// <returns>Объект, где хранятся данные сущности "ProductDummyManyToMany".</returns>
        public DataBaseObjectProductProductFeature CreateObjectProductDummyManyToMany()
        {
            var loader = new DataBaseLoaderProductProductFeature();
            loader.LoadDataFrom(this);
            return loader.Data;
        }

        #endregion Public methods
    }
}