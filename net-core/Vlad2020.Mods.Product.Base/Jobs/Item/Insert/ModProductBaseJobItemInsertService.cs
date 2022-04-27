//Author Vlad Balkarov//vlad//

using Vlad2020.Core.Base.Executable.Services.Async;
using Vlad2020.Core.Base.Resources.Errors;
using Vlad2020.Data.Base;
using Vlad2020.Mods.Product.Base.Jobs.Item.Get;
using Vlad2020.Mods.Product.Base.Resources.Errors;
using Vlad2020.Mods.Product.Base.Resources.Successes;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Vlad2020.Mods.Product.Base.Jobs.Item.Insert
{
    /// <summary>
    /// Мод "Product". Основа. Задания. Элемент. Вставка. Сервис.
    /// </summary>
    public class ModProductBaseJobItemInsertService : CoreBaseExecutableServiceAsyncWithInputAndOutput
        <
            ModProductBaseJobItemGetOutput,
            ModProductBaseJobItemGetOutput
        >
    {
        #region Properties

        /// <summary>
        /// Ресурсы успехов.
        /// </summary>
        protected ModProductBaseResourceSuccesses ResourceSuccesses { get; set; }

        /// <summary>
        /// Ресурсы ошибок.
        /// </summary>
        protected ModProductBaseResourceErrors ResourceErrors { get; set; }

        /// <summary>
        /// Настройки основы данных.
        /// </summary>
        protected DataBaseSettings DataBaseSettings { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="executable">Выполняемое.</param>
        /// <param name="coreBaseResourceErrors">Ядро. Основа. Ресурсы. Ошибки.</param>
        /// <param name="resourceSuccesses">Ресурсы успехов.</param>
        /// <param name="resourceErrors">Ресурсы ошибок.</param>
        /// <param name="dataBaseSettings">Настройки основы данных.</param>
        public ModProductBaseJobItemInsertService(
            Func<ModProductBaseJobItemGetOutput, Task<ModProductBaseJobItemGetOutput>> executable,
            CoreBaseResourceErrors coreBaseResourceErrors,
            ModProductBaseResourceSuccesses resourceSuccesses,
            ModProductBaseResourceErrors resourceErrors,
            DataBaseSettings dataBaseSettings
            ) : base(executable,  coreBaseResourceErrors)
        {
            ResourceSuccesses = resourceSuccesses;
            ResourceErrors = resourceErrors;
            DataBaseSettings = dataBaseSettings;

            Execution.FuncGetErrorMessages = GetErrorMessages;
            Execution.FuncGetSuccessMessages = GetSuccessMessages;
        }

        #endregion Constructors

        #region Protected methods

        /// <summary>
        /// Получить сообщения об ошибках.
        /// </summary>
        /// <param name="ex">Исключение.</param>
        /// <returns>Сообщения.</returns>
        protected virtual IEnumerable<string> GetErrorMessages(Exception ex)
        {
            var msg = ex.ToString();

            var setting = DataBaseSettings.Product;

            if (msg.Contains(setting.DbUniqueIndexForName))
            {
                return new[]
                {
                    string.Format(
                        ResourceErrors.GetStringFormatFieldValueIsNotUnique(), 
                        "Name"
                        )
                };
            }

            return null;
        }

        /// <summary>
        /// Получить сообщения об успехах.
        /// </summary>
        /// <param name="input">Ввод.</param>
        /// <param name="output">Вывод.</param>
        /// <returns>Сообщения.</returns>
        protected virtual IEnumerable<string> GetSuccessMessages(
            ModProductBaseJobItemGetOutput input,
            ModProductBaseJobItemGetOutput output
            )
        {
            return new[]
            {
                string.Format(
                    ResourceSuccesses.GetStringFormatObjectWithIdIsInserted(),
                    output.ObjectProduct.Id
                    )
            };
        }

        #endregion Protected methods
    }
}