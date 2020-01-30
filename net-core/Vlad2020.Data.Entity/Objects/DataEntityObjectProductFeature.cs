//Author Maxim Kuzmin//makc//

using Vlad2020.Data.Base.Loaders;
using Vlad2020.Data.Base.Objects;
using System.Collections.Generic;

namespace Vlad2020.Data.Entity.Objects
{
    /// <summary>
    /// Данные. Entity Framework. Объекты. Сущность "ProductFeature".
    /// </summary>
    public class DataEntityObjectProductFeature : DataBaseObjectProductFeature
    {
        #region Properties

        /// <summary>
        /// Объекты, где хранятся данные сущности "ProductProductFeature".
        /// </summary>
        public virtual List<DataEntityObjectProductProductFeature> ObjectsProductProductFeature { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        public DataEntityObjectProductFeature()
        {
            ObjectsProductProductFeature = new List<DataEntityObjectProductProductFeature>();
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        /// Создать объект Entity Framework, где хранятся данные сущности "ProductFeature".
        /// </summary>
        /// <param name="source">Источник данных.</param>
        /// <returns>Объект Entity Framework, где хранятся данные сущности "ProductFeature".</returns>
        public static DataEntityObjectProductFeature Create(DataBaseObjectProductFeature source)
        {
            var result = new DataEntityObjectProductFeature();
            new DataBaseLoaderProductFeature(result).LoadDataFrom(source);
            return result;
        }

        /// <summary>
        /// Создать объект, где хранятся данные сущности "ProductFeature".
        /// </summary>
        /// <returns>Объект, где хранятся данные сущности "ProductFeature".</returns>
        public DataBaseObjectProductFeature CreateObjectProductFeature()
        {
            var loader = new DataBaseLoaderProductFeature();
            loader.LoadDataFrom(this);
            return loader.Data;
        }

        #endregion Public methods
    }
}
