﻿//Author Maxim Kuzmin//makc//

using Vlad2020.Core.Base.Executable.Services.Async;
using Vlad2020.Core.Base.Execution.Exceptions;
using Vlad2020.Core.Base.Resources.Errors;
using Vlad2020.Host.Base.Parts.Auth.Resources.Errors;
using Vlad2020.Host.Base.Parts.Auth.Resources.Successes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vlad2020.Host.Base.Parts.Auth.Jobs.CurrentUser.Get
{
    /// <summary>
    /// Хост. Основа. Часть "Auth". Задания. Текущий пользователь. Получение. Сервис.
    /// </summary>
    public class HostBasePartAuthJobCurrentUserGetService : CoreBaseExecutableServiceAsyncWithInputAndOutput
        <
            HostBasePartAuthJobCurrentUserGetInput,
            HostBasePartAuthUser
        >
    {
        #region Properties

        private HostBasePartAuthResourceErrors ResourceErrors { get; set; }

        private HostBasePartAuthResourceSuccesses ResourceSuccesses { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="executable">Выполняемое.</param>
        /// <param name="coreBaseResourceErrors">Ядро. Основа. Ресурсы. Ошибки.</param>
        /// <param name="resourceSuccesses">Ресурсы успехов.</param>
        /// <param name="resourceErrors">Ресурсы ошибок.</param>
        public HostBasePartAuthJobCurrentUserGetService(
            Func<HostBasePartAuthJobCurrentUserGetInput, Task<HostBasePartAuthUser>> executable,
            CoreBaseResourceErrors coreBaseResourceErrors,
            HostBasePartAuthResourceSuccesses resourceSuccesses,
            HostBasePartAuthResourceErrors resourceErrors
            ) : base(executable, coreBaseResourceErrors)
        {
            ResourceSuccesses = resourceSuccesses;
            ResourceErrors = resourceErrors;

            Execution.FuncGetSuccessMessages = GetSuccessMessages;
            Execution.FuncGetErrorMessages = GetErrorMessages;
            Execution.FuncTransformInput = TransformInput;
        }

        #endregion Constructors

        #region Private methods

        private IEnumerable<string> GetErrorMessages(Exception ex)
        {
            if (ex is HostBasePartAuthJobCurrentUserGetException)
            {
                return new[]
                {
                    ResourceErrors.GetStringFailedToGetCurrentUser()
                };
            }

            return null;
        }

        private IEnumerable<string> GetSuccessMessages(
            HostBasePartAuthJobCurrentUserGetInput input,
            HostBasePartAuthUser output
            )
        {
            return new[]
            {
                ResourceSuccesses.GetStringCurrentUserIsReceived()
            };
        }

        private HostBasePartAuthJobCurrentUserGetInput TransformInput(HostBasePartAuthJobCurrentUserGetInput input)
        {
            if (input == null)
            {
                input = new HostBasePartAuthJobCurrentUserGetInput();
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
