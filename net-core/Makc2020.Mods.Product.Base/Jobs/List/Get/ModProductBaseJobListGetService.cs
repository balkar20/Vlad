//Author Maxim Kuzmin//makc//

using Vlad2020.Core.Base.Executable.Services.Async;
using Vlad2020.Core.Base.Resources.Errors;
using System;
using System.Threading.Tasks;

namespace Vlad2020.Mods.Product.Base.Jobs.List.Get
{
    /// <summary>
    /// Мод "Product". Задания. Список. Получение. Сервис.
    /// </summary>
    public class ModProductBaseJobListGetService : CoreBaseExecutableServiceAsyncWithInputAndOutput
        <
            ModProductBaseJobListGetInput,
            ModProductBaseJobListGetOutput
        >
    {
        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="executable">Выполняемое.</param>
        /// <param name="coreBaseResourceErrors">Ядро. Основа. Ресурсы. Ошибки.</param>
        public ModProductBaseJobListGetService(
            Func<ModProductBaseJobListGetInput, Task<ModProductBaseJobListGetOutput>> executable,
            CoreBaseResourceErrors coreBaseResourceErrors
            ) : base(executable, coreBaseResourceErrors)
        {
            Execution.FuncTransformInput = TransformInput;
        }

        #endregion Constructors

        #region Private methods

        private ModProductBaseJobListGetInput TransformInput(ModProductBaseJobListGetInput input)
        {
            if (input == null)
            {
                input = new ModProductBaseJobListGetInput();
            }

            input.Normalize();

            return input;
        }

        #endregion Private methods
    }
}