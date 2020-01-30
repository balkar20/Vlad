//Author Maxim Kuzmin//makc//

using Vlad2020.Core.Base.Execution;
using Vlad2020.Core.Base.Execution.Services;
using Vlad2020.Core.Base.Resources.Errors;
using Microsoft.Extensions.Logging;

namespace Vlad2020.Core.Base.Executable.Services
{
    /// <summary>
    /// Ядро. Основа. Выполняемое. Сервис без ввода и вывода.
    /// </summary>
    public class CoreBaseExecutableServiceWithoutInputAndOutput
        : CoreBaseExecutableService<CoreBaseExecutionServiceWithoutInputAndOutput>
    {
        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="coreBaseResourceErrors">Ядро. Основа. Ресурсы. Ошибки.</param>
        public CoreBaseExecutableServiceWithoutInputAndOutput(CoreBaseResourceErrors coreBaseResourceErrors) 
            : base(new CoreBaseExecutionServiceWithoutInputAndOutput(coreBaseResourceErrors))
        {
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        /// В случае успеха.
        /// </summary>
        /// <param name="logger">Регистратор.</param>
        /// <param name="result">Результат выполнения.</param>
        public void OnSuccess(ILogger logger, CoreBaseExecutionResult result)
        {
            Execution.OnSuccess(logger, result);
        }

        #endregion Public methods
    }
}
