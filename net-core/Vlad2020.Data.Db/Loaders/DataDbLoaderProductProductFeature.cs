//Author Maxim Kuzmin//makc//

using Vlad2020.Core.Base.Data.Db;
using Vlad2020.Core.Base.Ext;
using Vlad2020.Data.Base.Loaders;
using Vlad2020.Data.Base.Objects;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading.Tasks;

namespace Vlad2020.Data.Db.Loaders
{
    /// <summary>
    /// Данные. База данных. Загрузчики. Сущность "DummyMainProductFeature".
    /// </summary>
    public class DataDbLoaderProductProductFeature : DataBaseLoaderProductProductFeature, ICoreBaseDataDbLoader
    {
        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="data">Данные.</param>
        public DataDbLoaderProductProductFeature(DataBaseObjectProductProductFeature data = null)
            : base(data ?? new DataBaseObjectProductProductFeature())
        {
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        /// Загрузить данные из источника.
        /// </summary>
        /// <param name="source">Источник данных.</param>
        /// <param name="ordinal">Порядковый номер, начиная с которого нужно считывать данные.</param>
        /// <param name="props">Загружаемые свойства.</param>
        /// <returns>Задача с порядковым номером, начиная с которого нужно считывать следующие данные.</returns>
        public async Task<int> LoadDataFrom(DbDataReader source, int ordinal, HashSet<string> props = null)
        {
            props = EnsureNotNullValue(props);

            if (props.Contains(nameof(Data.ObjectProductId)))
            {
                Data.ObjectProductId = await source.GetFieldValueAsync<long>(ordinal++).CoreBaseExtTaskWithCurrentCulture(false);
            }

            if (props.Contains(nameof(Data.ObjectProductFeatureId)))
            {
                Data.ObjectProductFeatureId = await source.GetFieldValueAsync<long>(ordinal++).CoreBaseExtTaskWithCurrentCulture(false);
            }

            return ordinal;
        }

        #endregion Public methods
    }
}