//Author Maxim Kuzmin//makc//

using Makc2020.Data.Base.Loaders;
using Makc2020.Data.Base.Objects;
using System.Collections.Generic;

namespace Makc2020.Data.Entity.Objects
{
    /// <summary>
    /// Данные. Entity Framework. Объекты. Сущность "Product".
    /// </summary>
    public class DataEntityObjectProduct : DataBaseObjectProduct
    {
        #region Properties

        /// <summary>
        /// Объект, где хранятся данные сущности "ProductCategory".
        /// </summary>
        public virtual DataEntityObjectProductCategory ObjectProductCategory { get; set; }

        /// <summary>
        /// Объекты, где хранятся данные сущности "ProductDummyManyToMany".
        /// </summary>
        public virtual List<DataEntityObjectProductFeature> ObjectsProductFeature { get; set; }

        /// <summary>
        /// Объекты, где хранятся данные сущности "ProductDummyManyToMany".
        /// </summary>
        public virtual List<DataEntityObjectProductProductFeature> ObjectsProductProductFeature { get; set; }


        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        public DataEntityObjectProduct()
        {
            ObjectsProductFeature = new List<DataEntityObjectProductFeature>();
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        /// Создать объект Entity Framework, где хранятся данные сущности "Product".
        /// </summary>
        /// <param name="source">Источник данных.</param>
        /// <returns>Объект Entity Framework, где хранятся данные сущности "Product".</returns>
        public static DataEntityObjectProduct Create(DataBaseObjectProduct source)
        {
            var result = new DataEntityObjectProduct();
            new DataBaseLoaderProduct(result).LoadDataFrom(source);            
            return result;
        }

        /// <summary>
        /// Создать объект, где хранятся данные сущности "Product".
        /// </summary>
        /// <returns>Объект, где хранятся данные сущности "Product".</returns>
        public DataBaseObjectProduct CreateObjectProduct()
        {
            var loader = new DataBaseLoaderProduct();
            loader.LoadDataFrom(this);
            return loader.Data;
        }

        #endregion Public methods
    }
}
