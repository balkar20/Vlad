//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Executable.Services.Async;
using Makc2020.Core.Base.Resources.Errors;
using Makc2020.Mods.DummyMain.Base.Common.Jobs.Option.List.Get;
using System;
using System.Threading.Tasks;

namespace Makc2020.Mods.DummyMain.Base.Jobs.Option.ProductFeature.List.Get
{
    /// <summary>
    /// Мод "DummyMain". Задания. Вариант выбора. Сущность "ProductFeature". Список. Получение. Сервис.
    /// </summary>
    public class ModDummyMainBaseJobOptionProductFeatureGetListService : CoreBaseExecutableServiceAsyncWithOutput
        <
            ModDummyMainBaseCommonJobOptionListGetOutput
        >
    {
        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="executable">Выполняемое.</param>
        /// <param name="coreBaseResourceErrors">Ядро. Основа. Ресурсы. Ошибки.</param>
        public ModDummyMainBaseJobOptionProductFeatureGetListService(
            Func<Task<ModDummyMainBaseCommonJobOptionListGetOutput>> executable,
            CoreBaseResourceErrors coreBaseResourceErrors
            ) : base(executable, coreBaseResourceErrors)
        {
        }

        #endregion Constructors
    }
}