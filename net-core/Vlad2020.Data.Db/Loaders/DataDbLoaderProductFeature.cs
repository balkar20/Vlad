﻿//Author Vlad Balkarov//vlad//

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
    /// Данные. База данных. Загрузчики. Сущность "ProductFeature".
    /// </summary>
    public class DataDbLoaderProductFeature : DataBaseLoaderProductFeature, ICoreBaseDataDbLoader
    {
        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="data">Данные.</param>
        public DataDbLoaderProductFeature(DataBaseObjectProductFeature data = null)
            : base(data ?? new DataBaseObjectProductFeature())
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

            if (props.Contains(nameof(Data.Id)))
            {
                Data.Id = await source.GetFieldValueAsync<long>(ordinal++).CoreBaseExtTaskWithCurrentCulture(false);
            }

            if (props.Contains(nameof(Data.Name)))
            {
                Data.Name = await source.GetFieldValueAsync<string>(ordinal++).CoreBaseExtTaskWithCurrentCulture(false);
            }

            return ordinal;
        }

        #endregion Public methods
    }
}