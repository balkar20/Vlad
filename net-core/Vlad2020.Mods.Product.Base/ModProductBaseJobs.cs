//Author Maxim Kuzmin//makc//

using Vlad2020.Core.Base.Resources.Errors;
using Vlad2020.Data.Base;
using Vlad2020.Mods.Product.Base.Jobs.Item.Delete;
using Vlad2020.Mods.Product.Base.Jobs.Item.Get;
using Vlad2020.Mods.Product.Base.Jobs.Item.Insert;
using Vlad2020.Mods.Product.Base.Jobs.Item.Update;
using Vlad2020.Mods.Product.Base.Jobs.List.Get;
using Vlad2020.Mods.Product.Base.Jobs.Option.DummyManyToMany.List.Get;
using Vlad2020.Mods.Product.Base.Jobs.Option.DummyOneToMany.List.Get;
using Vlad2020.Mods.Product.Base.Resources.Errors;
using Vlad2020.Mods.Product.Base.Resources.Successes;

namespace Vlad2020.Mods.Product.Base
{
    /// <summary>
    /// Мод "Product". Основа. Задания.
    /// </summary>
    public class ModProductBaseJobs
    {
        #region Properties

        /// <summary>
        /// Задание на удаление элемента.
        /// </summary>
        public ModProductBaseJobItemDeleteService JobItemDelete { get; private set; }

        /// <summary>
        /// Задание на получение элемента.
        /// </summary>
        public ModProductBaseJobItemGetService JobItemGet { get; private set; }

        /// <summary>
        /// Задание на вставку элемента.
        /// </summary>
        public ModProductBaseJobItemInsertService JobItemInsert { get; private set; }

        /// <summary>
        /// Задание на обновление элемента.
        /// </summary>
        public ModProductBaseJobItemUpdateService JobItemUpdate { get; private set; }

        /// <summary>
        /// Задание на получение списка.
        /// </summary>
        public ModProductBaseJobListGetService JobListGet { get; private set; }

        /// <summary>
        /// Задание на получение вариантов выбора сущности "DummyManyToMany".
        /// </summary>
        public ModProductBaseJobOptionDummyManyToManyGetListService JobOptionsDummyManyToManyGet { get; private set; }

        /// <summary>
        /// Задание на получение вариантов выбора сущности "DummyOneToMany".
        /// </summary>
        public ModProductBaseJobOptionDummyOneToManyListGetService JobOptionsDummyOneToManyGet { get; private set; }

        #endregion Properties

        #region Constructor

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="coreBaseResourceErrors">Ядро. Основа. Ресурсы. Ошибки.</param>
        /// <param name="dataBaseSettings">Данные. Основа. Настройки.</param>
        /// <param name="resourceSuccesses">Ресурсы. Успехи.</param>
        /// <param name="resourceErrors">Ресурсы. Ошибки.</param>
        /// <param name="service">Сервис.</param>
        public ModProductBaseJobs(            
            CoreBaseResourceErrors coreBaseResourceErrors,
            DataBaseSettings dataBaseSettings,
            ModProductBaseResourceSuccesses resourceSuccesses,
            ModProductBaseResourceErrors resourceErrors,
            ModProductBaseService service
            )
        {
            JobItemDelete = new ModProductBaseJobItemDeleteService(
                service.DeleteItem,
                coreBaseResourceErrors,
                resourceSuccesses
                );

            JobItemGet = new ModProductBaseJobItemGetService(
                service.GetItem,
                coreBaseResourceErrors
                );

            JobItemInsert = new ModProductBaseJobItemInsertService(
                service.SaveItem,
                coreBaseResourceErrors,
                resourceSuccesses,
                resourceErrors,
                dataBaseSettings
                );

            JobItemUpdate = new ModProductBaseJobItemUpdateService(
                service.SaveItem,
                coreBaseResourceErrors,
                resourceSuccesses,
                resourceErrors,
                dataBaseSettings
                );

            JobListGet = new ModProductBaseJobListGetService(
                service.GetList,
                coreBaseResourceErrors
                );

            JobOptionsDummyManyToManyGet = new ModProductBaseJobOptionDummyManyToManyGetListService(
                service.GetOptionsProductFeature,
                coreBaseResourceErrors
                );

            JobOptionsDummyOneToManyGet = new ModProductBaseJobOptionDummyOneToManyListGetService(
                service.GetOptionsProductCategory,
                coreBaseResourceErrors
                );
        }

        #endregion Constructor
    }
}
