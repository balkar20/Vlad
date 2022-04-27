//Author Vlad Balkarov//vlad//

using Vlad2020.Data.Entity.Objects;
using Vlad2020.Mods.Product.Base.Jobs.Item.Get;
using Vlad2020.Mods.Product.Base.Jobs.List.Get;
using System.Linq;

namespace Vlad2020.Mods.Product.Base.Ext
{
    /// <summary>
    /// Мод "Product". Основа. Расширение. Применить.
    /// </summary>
    public static class ModProductBaseExtApply
    {
        #region Public methods

        /// <summary>
        /// Мод "Product". Основа. Расширение. Применить. Фильтрацию.
        /// </summary>
        /// <param name="query">Запрос.</param>
        /// <param name="input">Ввод.</param>
        /// <returns>Запрос с учётом фильтрации.</returns>
        public static IQueryable<DataEntityObjectProduct> ModProductBaseExtApplyFiltering(
            this IQueryable<DataEntityObjectProduct> query,
            ModProductBaseJobItemGetInput input
            )
        {
            if (input.DataId > 0)
            {
                query = query.Where(x => x.Id == input.DataId);
            }

            if (input.DataName != null)
            {
                query = query.Where(x => x.Name == input.DataName);
            }

            return query;
        }

        /// <summary>
        /// Мод "Product". Основа. Расширение. Применить. Фильтрацию.
        /// </summary>
        /// <param name="query">Запрос.</param>
        /// <param name="input">Ввод.</param>
        /// <returns>Запрос с учётом фильтрации.</returns>
        public static IQueryable<DataEntityObjectProduct> ModProductBaseExtApplyFiltering(
            this IQueryable<DataEntityObjectProduct> query,
            ModProductBaseJobListGetInput input
            )
        {
            if (!string.IsNullOrWhiteSpace(input.DataName))
            {
                query = query.Where(x => x.Name.Contains(input.DataName));
            }

            if (input.DataIds != null && input.DataIds.Any())
            {
                query = query.Where(x => input.DataIds.Contains(x.Id));
            }

            if (input.DataObjectProductCategoryId > 0)
            {
                query = query.Where(x => x.ObjectProductCategoryId == input.DataObjectProductCategoryId);
            }

            if (input.DataObjectProductCategoryIds != null && input.DataObjectProductCategoryIds.Any())
            {
                query = query.Where(x => input.DataObjectProductCategoryIds.Contains(x.ObjectProductCategoryId));
            }

            if (!string.IsNullOrWhiteSpace(input.DataObjectProductCategoryName))
            {
                query = query.Where(x => x.ObjectProductCategory.Name.Contains(input.DataObjectProductCategoryName));
            }

            return query;
        }

        /// <summary>
        /// Мод "Product". Основа. Расширение. Применить. Сортировку.
        /// </summary>
        /// <param name="query">Запрос.</param>
        /// <param name="input">Ввод.</param>
        /// <returns>Запрос с учётом сортировки.</returns>
        public static IQueryable<DataEntityObjectProduct> ModProductBaseExtApplySorting(
            this IQueryable<DataEntityObjectProduct> query,
            ModProductBaseJobListGetInput input
            )
        {
            var sortField = input.DataSortField.ToLower();
            var sortDirection = input.DataSortDirection.ToLower();

            switch (sortField)
            {
                case "id":
                    switch (sortDirection)
                    {
                        case "asc":
                            query = query.OrderBy(x => x.Id);
                            break;
                        case "desc":
                            query = query.OrderByDescending(x => x.Id);
                            break;
                    }
                    break;
                case "name":
                    switch (sortDirection)
                    {
                        case "asc":
                            query = query.OrderBy(x => x.Name);
                            break;
                        case "desc":
                            query = query.OrderByDescending(x => x.Name);
                            break;
                    }
                    break;

                case "price":
                    switch (sortDirection)
                    {
                        case "asc":
                            query = query.OrderBy(x => x.Price);
                            break;
                        case "desc":
                            query = query.OrderByDescending(x => x.Price);
                            break;
                    }
                    break;
                case "description":
                    switch (sortDirection)
                    {
                        case "asc":
                            query = query.OrderBy(x => x.Description);
                            break;
                        case "desc":
                            query = query.OrderByDescending(x => x.Description);
                            break;
                    }
                    break;
                case "objectproductcategory":
                    switch (sortDirection)
                    {
                        case "asc":
                            query = query.OrderBy(x => x.ObjectProductCategory.Name);
                            break;
                        case "desc":
                            query = query.OrderByDescending(x => x.ObjectProductCategory.Name);
                            break;
                    }
                    break;
            }

            if (!string.IsNullOrWhiteSpace(sortField) && sortField != "id")
            {
                query = ((IOrderedQueryable<DataEntityObjectProduct>)query).ThenBy(x => x.Id);
            }

            return query;
        }

        #endregion Public methods
    }
}