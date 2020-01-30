//Author Maxim Kuzmin//makc//

using Vlad2020.Data.Base.Loaders;
using Vlad2020.Data.Base.Objects;
using System.Collections.Generic;

namespace Vlad2020.Data.Entity.Objects
{
    /// <summary>
    /// Данные. Entity Framework. Объекты. Сущность "ProductCategory".
    /// </summary>
    public class DataEntityObjectProductCategory : DataBaseObjectProductCategory
    {
        #region Properties

        /// <summary>
        /// Объекты, где хранятся данные сущности "DummyMain".
        /// </summary>
        public virtual List<DataEntityObjectProduct> ObjectsProduct { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        public DataEntityObjectProductCategory()
        {
            ObjectsProduct = new List<DataEntityObjectProduct>();
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        /// Создать объект Entity Framework, где хранятся данные сущности "ProductCategory".
        /// </summary>
        /// <param name="source">Источник данных.</param>
        /// <returns>Объект Entity Framework, где хранятся данные сущности "ProductCategory".</returns>
        public static DataEntityObjectProductCategory Create(DataBaseObjectProductCategory source)
        {
            var result = new DataEntityObjectProductCategory();
            //new DataBaseLoaderProductCategory(result).LoadDataFrom(source);
            return result;
        }

        /// <summary>
        /// Создать объект, где хранятся данные сущности "ProductCategory".
        /// </summary>
        /// <returns>Объект, где хранятся данные сущности "ProductCategory".</returns>
        public DataBaseObjectProductCategory CreateObjectProductCategory()
        {
            var loader = new DataBaseLoaderProductCategory();
            loader.LoadDataFrom(this);
            return loader.Data;
        }

        #endregion Public methods
    }
}
