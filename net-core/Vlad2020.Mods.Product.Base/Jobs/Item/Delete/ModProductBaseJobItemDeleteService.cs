//Author Maxim Kuzmin//makc//

using Vlad2020.Core.Base.Executable.Services.Async;
using Vlad2020.Core.Base.Resources.Errors;
using Vlad2020.Mods.Product.Base.Jobs.Item.Get;
using Vlad2020.Mods.Product.Base.Resources.Successes;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Vlad2020.Mods.Product.Base.Jobs.Item.Delete
{
    /// <summary>
    /// Мод "Product". Основа. Задания. Элемент. Удаление. Сервис.
    /// </summary>
    public class ModProductBaseJobItemDeleteService : CoreBaseExecutableServiceAsyncWithInput
        <
            ModProductBaseJobItemGetInput
        >
    {
        #region Properties

        private ModProductBaseResourceSuccesses ResourceSuccesses { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="executable">Выполняемое.</param>
        /// <param name="coreBaseResourceErrors">Ядро. Основа. Ресурсы. Ошибки.</param>
        /// <param name="resourceSuccesses">Ресурсы успехов.</param>
        public ModProductBaseJobItemDeleteService(
            Func<ModProductBaseJobItemGetInput, Task> executable,
            CoreBaseResourceErrors coreBaseResourceErrors,
            ModProductBaseResourceSuccesses resourceSuccesses
            ) : base(executable, coreBaseResourceErrors)
        {
            ResourceSuccesses = resourceSuccesses;

            Execution.FuncGetSuccessMessages = GetSuccessMessages;
        }

        #endregion Constructors

        #region Private methods

        private IEnumerable<string> GetSuccessMessages(ModProductBaseJobItemGetInput input)
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