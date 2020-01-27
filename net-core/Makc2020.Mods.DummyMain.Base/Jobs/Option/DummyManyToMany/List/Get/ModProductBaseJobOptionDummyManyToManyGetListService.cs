////Author Maxim Kuzmin//makc//

//using Makc2020.Core.Base.Executable.Services.Async;
//using Makc2020.Core.Base.Resources.Errors;
//using Makc2020.Mods.Product.Base.Common.Jobs.Option.List.Get;
//using System;
//using System.Threading.Tasks;

//namespace Makc2020.Mods.Product.Base.Jobs.Option.DummyManyToMany.List.Get
//{
//    /// <summary>
//    /// Мод "Product". Задания. Вариант выбора. Сущность "DummyManyToMany". Список. Получение. Сервис.
//    /// </summary>
//    public class ModProductBaseJobOptionDummyManyToManyGetListService : CoreBaseExecutableServiceAsyncWithOutput
//        <
//            ModProductBaseCommonJobOptionListGetOutput
//        >
//    {
//        #region Constructors

//        /// <summary>
//        /// Конструктор.
//        /// </summary>
//        /// <param name="executable">Выполняемое.</param>
//        /// <param name="coreBaseResourceErrors">Ядро. Основа. Ресурсы. Ошибки.</param>
//        public ModProductBaseJobOptionDummyManyToManyGetListService(
//            Func<Task<ModProductBaseCommonJobOptionListGetOutput>> executable,
//            CoreBaseResourceErrors coreBaseResourceErrors
//            ) : base(executable, coreBaseResourceErrors)
//        {
//        }

//        #endregion Constructors
//    }
//}