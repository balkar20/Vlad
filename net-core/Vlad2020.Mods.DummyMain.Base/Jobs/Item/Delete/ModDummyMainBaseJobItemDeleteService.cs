//Author Vlad Balkarov//vlad//

using Vlad2020.Core.Base.Executable.Services.Async;
using Vlad2020.Core.Base.Resources.Errors;
using Vlad2020.Mods.DummyMain.Base.Jobs.Item.Get;
using Vlad2020.Mods.DummyMain.Base.Resources.Successes;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Vlad2020.Mods.DummyMain.Base.Jobs.Item.Delete
{
    /// <summary>
    /// Мод "DummyMain". Основа. Задания. Элемент. Удаление. Сервис.
    /// </summary>
    public class ModDummyMainBaseJobItemDeleteService : CoreBaseExecutableServiceAsyncWithInput
        <
            ModDummyMainBaseJobItemGetInput
        >
    {
        #region Properties

        private ModDummyMainBaseResourceSuccesses ResourceSuccesses { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="executable">Выполняемое.</param>
        /// <param name="coreBaseResourceErrors">Ядро. Основа. Ресурсы. Ошибки.</param>
        /// <param name="resourceSuccesses">Ресурсы успехов.</param>
        public ModDummyMainBaseJobItemDeleteService(
            Func<ModDummyMainBaseJobItemGetInput, Task> executable,
            CoreBaseResourceErrors coreBaseResourceErrors,
            ModDummyMainBaseResourceSuccesses resourceSuccesses
            ) : base(executable, coreBaseResourceErrors)
        {
            ResourceSuccesses = resourceSuccesses;

            Execution.FuncGetSuccessMessages = GetSuccessMessages;
        }

        #endregion Constructors

        #region Private methods

        private IEnumerable<string> GetSuccessMessages(ModDummyMainBaseJobItemGetInput input)
        {
            return new[]
            {
                string.Format(
                    ResourceSuccesses.GetStringFormatObjectWithIdIsDeleted(),
                    input.DataId
                    )
            };
        }

        #endregion Private methods
    }
}