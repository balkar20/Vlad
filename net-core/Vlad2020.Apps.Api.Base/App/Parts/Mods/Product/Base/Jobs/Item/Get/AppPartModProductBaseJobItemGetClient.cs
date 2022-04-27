//Author Vlad Balkarov//vlad//

using Vlad2020.Apps.Api.Base.App.Common;
using Vlad2020.Core.Base.Execution;
using Vlad2020.Core.Base.Ext;
using Vlad2020.Mods.Product.Base.Jobs.Item.Get;
using Microsoft.Extensions.Logging;
using System;

namespace Vlad2020.Apps.Api.Base.App.Parts.Mods.Product.Base.Jobs.Item.Get
{
    /// <summary>
    /// Приложение. Часть "Mods". Мод "Product". Основа. Задания. Элемент. Получение. Клиент.
    /// </summary>
    public class AppPartModProductBaseJobItemGetClient : AppCommonClient
    {
        #region Properties

        private ModProductBaseJobItemGetService Job { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="logger">Регистратор.</param>
        /// <param name="job">Задание.</param>
        public AppPartModProductBaseJobItemGetClient(
            ILogger<AppPartModProductBaseJobItemGetClient> logger,
            ModProductBaseJobItemGetService job
            ) : base(logger)
        {
            Job = job;
        }

        #endregion Constructors        

        #region Protected methods

        /// <inheritdoc/>
        protected sealed override void DoRun()
        {
            var input = new ModProductBaseJobItemGetInput
            {
                DataId = 1
            };

            var result = new CoreBaseExecutionResultWithData<ModProductBaseJobItemGetOutput>();

            try
            {
                result.Data = Job.Execute(input).CoreBaseExtTaskWithCurrentCulture(false).GetResult();

                Job.OnSuccess(Logger, result, input);
            }
            catch (Exception ex)
            {
                Job.OnError(ex, Logger, result);
            }

            var msg = result.CoreBaseExtJsonSerialize(CoreBaseExtJson.OptionsForLogger);

            Show(msg, false);
        }

        #endregion Protected methods
    }
}