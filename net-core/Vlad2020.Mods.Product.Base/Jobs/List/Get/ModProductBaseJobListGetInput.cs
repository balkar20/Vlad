//Author Vlad Balkarov//vlad//

using Vlad2020.Core.Base.Ext;
using Vlad2020.Core.Base.Common.Jobs.List.Get;
using System.Linq;

namespace Vlad2020.Mods.Product.Base.Jobs.List.Get
{
    /// <summary>
    /// Мод "Product". Задания. Список. Получение. Ввод.
    /// </summary>
    public class ModProductBaseJobListGetInput : CoreBaseCommonJobListGetInput
    {
        #region Properties

        /// <summary>
        /// Имя объекта, где хранятся данные сущности "ProductCategory".
        /// </summary>
        public string DataObjectProductCategoryName { get; set; }

        /// <summary>
        /// Идентификатор объекта, где хранятся данные сущности "ProductCategory".
        /// </summary>
        public long DataObjectProductCategoryId { get; set; }

        /// <summary>
        /// Строка идентификаторов объектов, где хранятся данные сущности "ProductCategory".
        /// </summary>
        public string DataObjectProductCategoryIdsString { get; set; }

        /// <summary>
        /// Идентификаторы объектов, где хранятся данные сущности "ProductCategory".
        /// </summary>
        public long[] DataObjectProductCategoryIds { get; set; }

        /// <summary>
        /// Имя данных.
        /// </summary>
        public string DataName { get; set; }

        /// <summary>
        /// Строка идентификаторов данных.
        /// </summary>
        public string DataIdsString { get; set; }

        /// <summary>
        /// Идентификаторы данных.
        /// </summary>
        public long[] DataIds { get; set; }

        /// <summary>
        /// Сортировка данных.
        /// </summary>
        public int DataSorting { get; set; }

        #endregion Properties

        #region Public methods

        /// <summary>
        /// Нормализовать.
        /// </summary>
        public sealed override void Normalize()
        {
            base.Normalize();

            if (string.IsNullOrWhiteSpace(DataSortField))
            {
                DataSortField = "id";
            }

            if (string.IsNullOrWhiteSpace(DataSortDirection))
            {
                DataSortDirection = "desc";
            }

            if (!string.IsNullOrWhiteSpace(DataObjectProductCategoryIdsString) && (DataObjectProductCategoryIds == null || !DataObjectProductCategoryIds.Any()))
            {
                DataObjectProductCategoryIds = DataObjectProductCategoryIdsString.CoreBaseExtConvertToNumericInt64Array();
            }

            if (!string.IsNullOrWhiteSpace(DataIdsString) && (DataIds == null || !DataIds.Any()))
            {
                DataIds = DataIdsString.CoreBaseExtConvertToNumericInt64Array();
            }
        }

        #endregion Public methods
    }
}