//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Data;
using Makc2020.Data.Base.Objects;
using System.Collections.Generic;

namespace Makc2020.Data.Base.Loaders
{
    /// <summary>
    /// Данные. Основа. Загрузчики. Сущность "ProductDummyManyToMany".
    /// </summary>
    public class DataBaseLoaderProductDummyManyToMany : CoreBaseDataLoader<DataBaseObjectProductProductFeature>
    {
        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="data">Данные.</param>
        public DataBaseLoaderProductDummyManyToMany(DataBaseObjectProductProductFeature data = null)
            : base(data ?? new DataBaseObjectProductProductFeature())
        {
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        /// Загрузить данные из источника.
        /// </summary>
        /// <param name="source">Источник данных.</param>
        /// <param name="props">Загружаемые свойства.</param>
        public void LoadDataFrom(DataBaseObjectProductProductFeature source, HashSet<string> props = null)
        {
            props = EnsureNotNullValue(props);

            if (props.Contains(nameof(Data.ObjectProductId)))
            {
                Data.ObjectProductId = source.ObjectProductId;
            }

            if (props.Contains(nameof(Data.ObjectProductFeatureId)))
            {
                Data.ObjectProductFeatureId = source.ObjectProductFeatureId;
            }
        }

        #endregion Public methods

        #region Protected methods

        /// <inheritdoc/>
        protected override HashSet<string> CreateLoadableDataProperties()
        {
            return new HashSet<string>
            {
                nameof(Data.ObjectProductId),
                nameof(Data.ObjectProductFeatureId)
            };
        }

        #endregion Protected methods
    }
}