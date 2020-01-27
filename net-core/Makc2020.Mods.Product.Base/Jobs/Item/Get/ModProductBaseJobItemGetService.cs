//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Execution.Exceptions;
using Makc2020.Core.Base.Executable.Services.Async;
using Makc2020.Core.Base.Resources.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Makc2020.Mods.Product.Base.Jobs.Item.Get
{
    /// <summary>
    /// Мод "Product". Основа. Задания. Элемент. Получение. Сервис.
    /// </summary>
    public class ModProductBaseJobItemGetService : CoreBaseExecutableServiceAsyncWithInputAndOutput
        <
            ModProductBaseJobItemGetInput,
            ModProductBaseJobItemGetOutput
        >
    {
        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="executable">Выполняемое.</param>
        /// <param name="coreBaseResourceErrors">Ядро. Основа. Ресурсы. Ошибки.</param>
        public ModProductBaseJobItemGetService(
            Func<ModProductBaseJobItemGetInput, Task<ModProductBaseJobItemGetOutput>> executable,
            CoreBaseResourceErrors coreBaseResourceErrors
            ) : base(executable, coreBaseResourceErrors)
        {
            Execution.FuncGetErrorMessages = GetErrorMessages;
            Execution.FuncTransformInput = TransformInput;
            Execution.FuncTransformOutput = TransformOutput;
        }

        #endregion Constructors

        #region Private methods

        private ModProductBaseJobItemGetInput TransformInput(ModProductBaseJobItemGetInput input)
        {
            if (input == null)
            {
                input = new ModProductBaseJobItemGetInput();
            }

            input.Normalize();

            var invalidProperties = input.GetInvalidProperties();

            if (invalidProperties.Any())
            {
                throw new CoreExecutionExceptionInvalidInput(invalidProperties);
            }

            return input;
        }

        private ModProductBaseJobItemGetOutput TransformOutput(ModProductBaseJobItemGetOutput input)
        {
            return input.ObjectProduct != null ? input : null;
        }

        private IEnumerable<string> GetErrorMessages(Exception ex)
        {
            return GetErrorMessagesOnInvalidInput(ex);
        }

        #endregion Private methods
    }
}