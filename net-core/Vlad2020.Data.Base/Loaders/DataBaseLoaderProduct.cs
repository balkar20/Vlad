//Author Maxim Kuzmin//makc//

using Vlad2020.Core.Base.Data;
using Vlad2020.Data.Base.Objects;
using System.Collections.Generic;

namespace Vlad2020.Data.Base.Loaders
{
    /// <summary>
    /// Данные. Основа. Загрузчики. Сущность "Product".
    /// </summary>
    public class DataBaseLoaderProduct : CoreBaseDataLoader<DataBaseObjectProduct>
    {
        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="data">Данные.</param>
        public DataBaseLoaderProduct(DataBaseObjectProduct data = null)
            : base(data ?? new DataBaseObjectProduct())
        {
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        /// Загрузить данные из источника.
        /// </summary>
        /// <param name="source">Источник данных.</param>
        /// <param name="props">Загружаемые свойства.</param>
        public void LoadDataFrom(DataBaseObjectProduct source, HashSet<string> props = null)
        {
            props = EnsureNotNullValue(props);

            if (props.Contains(nameof(Data.Id)))
            {
                Data.Id = source.Id;
            }

            if (props.Contains(nameof(Data.Name)))
            {
                Data.Name = source.Name ?? string.Empty;
            }

            if (props.Contains(nameof(Data.ObjectProductCategoryId)))
            {
                Data.ObjectProductCategoryId = source.ObjectProductCategoryId;
            }

            if (props.Contains(nameof(Data.Description)))
            {
                Data.Description = source.Description ?? string.Empty;
            }

            if (props.Contains(nameof(Data.Price)))
            {
                Data.Price = source.Price;
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
                nameof(Data.Name),
                nameof(Data.ObjectProductCategoryId),
                nameof(Data.Price),
                nameof(Data.Description)
            };
        }

        #endregion Protected methods
    }
}
