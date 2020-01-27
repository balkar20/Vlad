//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Common.Ext;
using Makc2020.Core.Base.Data;
using Makc2020.Core.Base.Ext;
using Makc2020.Data.Base.Loaders;
using Makc2020.Data.Base.Objects;
using Makc2020.Data.Entity.Db;
using Makc2020.Data.Entity.Objects;
using Makc2020.Mods.Product.Base.Common.Jobs.Option.Item.Get;
using Makc2020.Mods.Product.Base.Common.Jobs.Option.List.Get;
using Makc2020.Mods.Product.Base.Config;
using Makc2020.Mods.Product.Base.Ext;
using Makc2020.Mods.Product.Base.Jobs.Item.Get;
using Makc2020.Mods.Product.Base.Jobs.List.Get;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Makc2020.Mods.Product.Base
{
    /// <summary>
    /// Мод "Product". Основа. Сервис.
    /// </summary>
    public class ModProductBaseService
    {
        #region Properties

        private IModProductBaseConfigSettings ConfigSettings { get; set; }

        private CoreBaseDataHelper DataHelper { get; set; }

        private DataEntityDbFactory DbFactory { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="configSettings">Конфигурационные настройки.</param>
        /// <param name="dataProvider">Поставщик данных.</param>
        /// <param name="dbFactory">Фабрика базы данных.</param>
        public ModProductBaseService(
            IModProductBaseConfigSettings configSettings,
            ICoreBaseDataProvider dataProvider,
            DataEntityDbFactory dbFactory
            )
        {
            ConfigSettings = configSettings;
            DataHelper = new CoreBaseDataHelper(dataProvider);
            DbFactory = dbFactory;
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        /// Получить элемент.
        /// </summary>
        /// <param name="input">Ввод.</param>
        /// <returns>Задача с полученными данными.</returns>
        public async Task<ModProductBaseJobItemGetOutput> GetItem(
            ModProductBaseJobItemGetInput input
            )
        {
            ModProductBaseJobItemGetOutput result = null;
            
            using (var source = CreateDbContext())
            {
                var entityProduct = await source.Product
                    .Include(x => x.ObjectProductCategory)
                    .Include(x => x.ObjectsProductFeature)
                    .ModProductBaseExtApplyFiltering(input)
                    .FirstOrDefaultAsync()
                    .CoreBaseExtTaskWithCurrentCulture(false);

                if (entityProduct != null)
                {
                    result = CreateItem(entityProduct);

                    if (result.ObjectsProductProductFeature != null)
                    {
                        var idsOfDummyManyToMany = result.ObjectsProductProductFeature
                            .Select(x => x.ObjectProductFeatureId)
                            .ToArray();

                        if (idsOfDummyManyToMany.Any())
                        {
                            var enities = await source.ProductFeature
                                .Where(x => idsOfDummyManyToMany.Contains(x.Id))
                                .ToArrayAsync()
                                .CoreBaseExtTaskWithCurrentCulture(false);

                            if (enities.Any())
                            {
                                InitItemProductFeature(result, enities);
                            }
                        }
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Получить список.
        /// </summary>
        /// <param name="input">Ввод.</param>
        /// <returns>Задача с полученными данными.</returns>
        public async Task<ModProductBaseJobListGetOutput> GetList(
            ModProductBaseJobListGetInput input
            )
        {
            var result = new ModProductBaseJobListGetOutput();

            using (var source = CreateDbContext())
            using (var sourceOfTotalCount = CreateDbContext())
            {
                var queryOfItems = source.Product
                    .Include(x => x.ObjectProductCategory)
                    .Include(x => x.ObjectsProductFeature)
                    .ModProductBaseExtApplyFiltering(input)
                    .ModProductBaseExtApplySorting(input)
                    .CoreBaseCommonModExtApplyPagination(input);

                var queryOfTotalCount = sourceOfTotalCount.Product
                    .ModProductBaseExtApplyFiltering(input);

                var taskOfItems = queryOfItems.ToArrayAsync();
                var taskOfTotalCount = queryOfTotalCount.CountAsync();

                await Task.WhenAll(taskOfItems, taskOfTotalCount).CoreBaseExtTaskWithCurrentCulture(false);

                result.Items = taskOfItems.Result.Select(x => CreateItem(x)).ToArray();
                result.TotalCount = taskOfTotalCount.Result;

                if (result.Items.Any())
                {
                    var idsDummyManyToMany = result.Items
                        .Where(x => x.ObjectsProductProductFeature != null)
                        .SelectMany(x => x.ObjectsProductProductFeature)                        
                        .Select(x => x.ObjectProductFeatureId)
                        .Distinct()
                        .ToArray();

                    if (idsDummyManyToMany.Any())
                    {
                        var lookupOfProductFeature = await source.ProductFeature
                            .Where(x => idsDummyManyToMany.Contains(x.Id))
                            .ToDictionaryAsync(x => x.Id)
                            .CoreBaseExtTaskWithCurrentCulture(false);

                        if (lookupOfProductFeature.Any())
                        {
                            foreach (var item in result.Items)
                            {
                                if (item.ObjectsProductProductFeature != null)
                                {
                                    InitItemProductFeature(item, lookupOfProductFeature);
                                }
                            }
                        }
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Получить варианты выбора сущности "DummyManyToMany".
        /// </summary>
        /// <returns>Задача с полученными данными.</returns>
        public async Task<ModProductBaseCommonJobOptionListGetOutput> GetOptionsDummyManyToMany()
        {
            var result = new ModProductBaseCommonJobOptionListGetOutput();

            using (var source = CreateDbContext())
            {
                var entities = await source.DummyManyToMany.ToArrayAsync();

                result.Items = entities.Select(x => CreateOptionDummyManyToMany(x)).ToArray();
            }

            return result;
        }

        /// <summary>
        /// Получить варианты выбора сущности "DummyOneToMany".
        /// </summary>
        /// <returns>Задача с полученными данными.</returns>
        public async Task<ModProductBaseCommonJobOptionListGetOutput> GetOptionsDummyOneToMany()
        {
            var result = new ModProductBaseCommonJobOptionListGetOutput();

            using (var source = CreateDbContext())
            {
                var entities = await source.DummyOneToMany.ToArrayAsync();

                result.Items = entities.Select(x => CreateOptionDummyOneToMany(x)).ToArray();
            }

            return result;
        }

        /// <summary>
        /// Сохранить элемент.
        /// </summary>
        /// <param name="data">Данные для сохранения.</param>
        /// <returns>Задача с сохранёнными данными.</returns>
        public async Task<ModProductBaseJobItemGetOutput> SaveItem(ModProductBaseJobItemGetOutput data)
        {
            var result = new ModProductBaseJobItemGetOutput();

            if (data.ObjectProduct != null)
            {
                result.ObjectProduct = await SaveObjectProduct(
                    data.ObjectProduct
                    ).CoreBaseExtTaskWithCurrentCulture(false);
            }

            if (data.ObjectProductCategory != null)
            {
                result.ObjectProductCategory = await SaveObjectProductCategory(
                    data.ObjectProductCategory
                    ).CoreBaseExtTaskWithCurrentCulture(false);
            }

            if (data.ObjectsProductFeature != null && data.ObjectsProductFeature.Any())
            {
                result.ObjectsProductFeature = await SaveObjectsDummyManyToMany(
                    data.ObjectsProductFeature
                    ).CoreBaseExtTaskWithCurrentCulture(false);
            }

            if (result.ObjectProduct.Id > 0)
            {
                result = await GetItem(new ModProductBaseJobItemGetInput { DataId = result.ObjectProduct.Id });
            }

            return result;
        }

        /// <summary>
        /// Удалить элемент.
        /// </summary>
        /// <param name="input">Ввод.</param>
        /// <returns>Задача.</returns>
        public async Task DeleteItem(ModProductBaseJobItemGetInput input)
        {
            using var source = CreateDbContext();

            var obj = await source.Product.FirstAsync(
                x => x.Id == input.DataId
                ).CoreBaseExtTaskWithCurrentCulture(false);

            source.Product.Remove(obj);

            await source.SaveChangesAsync().CoreBaseExtTaskWithCurrentCulture(false);
        }

        #endregion Public methods

        #region Private methods

        private ModProductBaseJobItemGetOutput CreateItem(DataEntityObjectProduct entity)
        {
            var result = new ModProductBaseJobItemGetOutput
            {
                ObjectProduct = entity.CreateObjectProduct(),
                ObjectProductCategory = entity.ObjectProductCategory.CreateObjectProductCategory()
            };

            if (entity.ObjectsProductProductFeature.Any())
            {
                result.ObjectsProductProductFeature = entity.ObjectsProductProductFeature.Select(
                    x => x.CreateObjectProductDummyManyToMany()
                    ).ToArray();
            }

            return result;
        }

        private ModProductBaseCommonJobOptionItemGetOutput  CreateOptionDummyManyToMany(
            DataEntityObjectDummyManyToMany entity
            )
        {
            return new ModProductBaseCommonJobOptionItemGetOutput 
            {
                Name = entity.Name,
                Value = entity.Id
            };
        }

        private ModProductBaseCommonJobOptionItemGetOutput  CreateOptionDummyOneToMany(
            DataEntityObjectDummyOneToMany entity
            )
        {
            return new ModProductBaseCommonJobOptionItemGetOutput 
            {
                Name = entity.Name,
                Value = entity.Id
            };
        }

        private void InitItemProductFeature(
            ModProductBaseJobItemGetOutput item,
            IEnumerable<DataEntityObjectProductFeature> entities
            )
        {
            item.ObjectsProductFeature = entities
                .OrderBy(x => x.Name)
                .ThenBy(x => x.Id)
                .Select(x => x.CreateObjectProductFeature())
                .ToArray();
        }

        private void InitItemProductFeature(
            ModProductBaseJobItemGetOutput item,
            IDictionary<long, DataEntityObjectProductFeature> lookup
            )
        {
            var ids = item.ObjectsProductProductFeature
                .Select(x => x.ObjectProductFeatureId)
                .ToArray();

            var entities = new List<DataEntityObjectProductFeature>();

            foreach (var id in ids)
            {
                if (lookup.TryGetValue(id, out DataEntityObjectProductFeature entity))
                {
                    entities.Add(entity);
                }
            }

            if (entities.Any())
            {
                InitItemProductFeature(item, entities);
            }
        }

        private async Task<DataBaseObjectProduct> SaveObjectProduct(
            DataBaseObjectProduct obj
            )
        {
            DataBaseObjectProduct result = null;

            using (var source = CreateDbContext())
            {
                if (obj.Id > 0)
                {
                    result = await source.Product
                        .FirstAsync(x => x.Id == obj.Id)
                        .CoreBaseExtTaskWithCurrentCulture(false);

                    var loader = new DataBaseLoaderProduct(result);

                    loader.LoadDataFrom(obj);
                }
                else
                {
                    var entity = DataEntityObjectProduct.Create(obj);

                    var entry = source.Product.Add(entity);

                    result = entry.Entity;
                }

                await source.SaveChangesAsync().CoreBaseExtTaskWithCurrentCulture(false);
            }

            return result;
        }

        private async Task<DataBaseObjectProductCategory> SaveObjectProductCategory(
            DataBaseObjectProductCategory obj
            )
        {
            DataBaseObjectProductCategory result = null;

            using (var source = CreateDbContext())
            {
                if (obj.Id > 0)
                {
                    result = await source.ProductCategory
                        .FirstAsync(x => x.Id == obj.Id)
                        .CoreBaseExtTaskWithCurrentCulture(false);

                    var loader = new DataBaseLoaderProductCategory(result);

                    loader.LoadDataFrom(obj);
                }
                else
                {
                    var entity = DataEntityObjectProductCategory.Create(obj);

                    var entry = source.ProductCategory.Add(entity);

                    result = entry.Entity;
                }

                await source.SaveChangesAsync().CoreBaseExtTaskWithCurrentCulture(false);
            }

            return result;
        }

        private async Task<DataBaseObjectProductFeature[]> SaveObjectsDummyManyToMany(
            DataBaseObjectProductFeature[] objects
            )
        {
            var result = new DataBaseObjectProductFeature[objects.Length];

            for (int i = 0; i < objects.Length; i++)
            {
                result[i] = await SaveObjectDummyManyToMany(objects[i]).CoreBaseExtTaskWithCurrentCulture(false);
            }

            return result;
        }

        private async Task<DataBaseObjectProductFeature> SaveObjectDummyManyToMany(
            DataBaseObjectProductFeature obj
            )
        {
            DataBaseObjectProductFeature result = null;

            using (var source = CreateDbContext())
            {
                if (obj.Id > 0)
                {
                    result = await source.ProductFeature
                        .FirstAsync(x => x.Id == obj.Id)
                        .CoreBaseExtTaskWithCurrentCulture(false);

                    var loader = new DataBaseLoaderProductFeature(result);

                    loader.LoadDataFrom(obj);
                }
                else
                {
                    var entity = DataEntityObjectProductFeature.Create(obj);

                    var entry = source.ProductFeature.Add(DataEntityObjectProductFeature.Create(obj));

                    result = entry.Entity;
                }

                await source.SaveChangesAsync().CoreBaseExtTaskWithCurrentCulture(false);
            }

            return result;
        }

        private DataEntityDbContext CreateDbContext()
        {
            var result = DbFactory.CreateDbContext();

            result.Database.SetCommandTimeout(ConfigSettings.DbCommandTimeout);

            return result;
        }

        #endregion Private methods
    }
}