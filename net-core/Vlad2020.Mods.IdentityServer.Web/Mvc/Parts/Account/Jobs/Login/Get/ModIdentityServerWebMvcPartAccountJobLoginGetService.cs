//Author Maxim Kuzmin//makc//

using Vlad2020.Core.Base.Executable.Services.Async;
using Vlad2020.Core.Base.Execution.Exceptions;
using Vlad2020.Core.Base.Resources.Errors;
using Vlad2020.Mods.IdentityServer.Web.Mvc.Parts.Account.Common.Jobs.Login;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Vlad2020.Mods.IdentityServer.Web.Mvc.Parts.Account.Jobs.Login.Get
{
    /// <summary>
    /// Мод "IdentityServer". Веб. MVC. Часть "Account". Задания. Вход в систему. Получение. Сервис.
    /// </summary>
    public class ModIdentityServerWebMvcPartAccountJobLoginGetService : CoreBaseExecutableServiceAsyncWithInputAndOutput
        <
            ModIdentityServerWebMvcPartAccountJobLoginGetInput,
            ModIdentityServerWebMvcPartAccountCommonJobLoginOutput
        >
    {
        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="executable">Выполняемое.</param>
        /// <param name="coreBaseResourceErrors">Ядро. Основа. Ресурсы. Ошибки.</param>
        public ModIdentityServerWebMvcPartAccountJobLoginGetService(
            Func<ModIdentityServerWebMvcPartAccountJobLoginGetInput, Task<ModIdentityServerWebMvcPartAccountCommonJobLoginOutput>> executable,
            CoreBaseResourceErrors coreBaseResourceErrors
            ) : base(executable, coreBaseResourceErrors)
        {
            Execution.FuncTransformInput = TransformInput;
        }

        #endregion Constructors

        #region Private methods

        private ModIdentityServerWebMvcPartAccountJobLoginGetInput TransformInput(ModIdentityServerWebMvcPartAccountJobLoginGetInput input)
        {
            if (input == null)
            {
                input = new ModIdentityServerWebMvcPartAccountJobLoginGetInput();
            }

            var invalidProperties = input.GetInvalidProperties();

            if (invalidProperties.Any())
            {
                throw new CoreExecutionExceptionInvalidInput(invalidProperties);
            }

            return input;
        }

        #endregion Private methods
    }
}