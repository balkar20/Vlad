//Author Maxim Kuzmin//makc//

using Vlad2020.Core.Base.Executable.Services.Async;
using Vlad2020.Core.Base.Resources.Errors;
using Vlad2020.Mods.DummyMain.Base.Common.Jobs.Option.List.Get;
using System;
using System.Threading.Tasks;

namespace Vlad2020.Mods.DummyMain.Base.Jobs.Option.DummyManyToMany.List.Get
{
    /// <summary>
    /// Мод "DummyMain". Задания. Вариант выбора. Сущность "DummyManyToMany". Список. Получение. Сервис.
    /// </summary>
    public class ModDummyMainBaseJobOptionDummyManyToManyGetListService : CoreBaseExecutableServiceAsyncWithOutput
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
        public ModDummyMainBaseJobOptionDummyManyToManyGetListService(
            Func<Task<ModDummyMainBaseCommonJobOptionListGetOutput>> executable,
            CoreBaseResourceErrors coreBaseResourceErrors
            ) : base(executable, coreBaseResourceErrors)
        {
        }

        #endregion Constructors
    }
}