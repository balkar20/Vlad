﻿//Author Vlad Balkarov//vlad//

using Vlad2020.Core.Base.Resources.Errors;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace Vlad2020.Core.Base.Execution.Services
{
    /// <summary>
    /// Ядро. Основа. Выполнение. Сервисы.  Без ввода и вывода.
    /// </summary>
    public class CoreBaseExecutionServiceWithoutInputAndOutput : CoreBaseExecutionService
    {
        #region Properties

        /// <summary>
        /// Функция получения сообщений об успехах.
        /// </summary>
        public Func<IEnumerable<string>> FuncGetSuccessMessages { get; set; }

        /// <summary>
        /// Функция получения сообщений о предупреждениях.
        /// </summary>
        public Func<IEnumerable<string>> FuncGetWarningMessages { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="coreBaseResourceErrors">Ядро. Основа. Ресурсы. Ошибки.</param>
        public CoreBaseExecutionServiceWithoutInputAndOutput(CoreBaseResourceErrors coreBaseResourceErrors)
            : base(coreBaseResourceErrors)
        {
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        /// В случае успеха.
        /// </summary>
        /// <param name="logger">Регистратор.</param>
        /// <param name="result">Результат выполнения.</param>
        public void OnSuccess(
            ILogger logger,
            CoreBaseExecutionResult result
            )
        {
            DoOnSuccess(
                logger,
                result,
                FuncGetSuccessMessages,
                FuncGetWarningMessages
                );
        }

        #endregion Public methods
    }
}
