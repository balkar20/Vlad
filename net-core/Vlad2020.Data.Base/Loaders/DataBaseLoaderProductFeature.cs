//Author Maxim Kuzmin//makc//

using Vlad2020.Core.Base.Data;
using Vlad2020.Data.Base.Objects;
using System.Collections.Generic;

namespace Vlad2020.Data.Base.Loaders
{
    /// <summary>
    /// Данные. Основа. Загрузчики. Сущность "ProductFeature".
    /// </summary>
    public class DataBaseLoaderProductFeature : CoreBaseDataLoader<DataBaseObjectProductFeature>
    {
        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="data">Данные.</param>
        public DataBaseLoaderProductFeature(DataBaseObjectProductFeature data = null)
            : base(data ?? new DataBaseObjectProductFeature())
        {
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        /// Загрузить данные из источника.
        /// </summary>
        /// <param name="source">Источник данных.</param>
        /// <param name="props">Загружаемые свойства.</param>
        public void LoadDataFrom(DataBaseObjectProductFeature source, HashSet<string> props = null)
        {
            props = EnsureNotNullValue(props);

            if (props.Contains(nameof(Data.Id)))
            {
                Data.Id = source.Id;
            }

            if (props.Contains(nameof(Data.Name)))
            {
                Data.Name = source.Name;
            }
        }

        #endregion Public methods

        #region Protected methods

        /// <inheritdoc/>
        protected override HashSet<string> CreateLoadableDataProperties()
        {
            return new HashSet<string>
            {
                nameof(Data.Id),
                nameof(Data.Name)
            };
        }

        #endregion Protected methods
    }
}
