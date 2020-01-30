//Author Maxim Kuzmin//makc//

using Vlad2020.Core.Base.Resources.Errors;
using Vlad2020.Data.Base;
using Vlad2020.Mods.Product.Base.Jobs.Item.Get;
using Vlad2020.Mods.Product.Base.Jobs.Item.Insert;
using Vlad2020.Mods.Product.Base.Resources.Errors;
using Vlad2020.Mods.Product.Base.Resources.Successes;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Vlad2020.Mods.Product.Base.Jobs.Item.Update
{
    /// <summary>
    /// Мод "Product". Основа. Задания. Элемент. Обновление. Сервис.
    /// </summary>
    public class ModProductBaseJobItemUpdateService : ModProductBaseJobItemInsertService
    {
        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="executable">Выполняемое.</param>
        /// <param name="coreBaseResourceErrors">Ядро. Основа. Ресурсы. Ошибки.</param>
        /// <param name="resourceSuccesses">Ресурсы успехов.</param>
        /// <param name="resourceErrors">Ресурсы ошибок.</param>
        /// <param name="dataBaseSettings">Настройки основы данных.</param>
        public ModProductBaseJobItemUpdateService(
            Func<ModProductBaseJobItemGetOutput, Task<ModProductBaseJobItemGetOutput>> executable,
            CoreBaseResourceErrors coreBaseResourceErrors,
            ModProductBaseResourceSuccesses resourceSuccesses,
            ModProductBaseResourceErrors resourceErrors,
            DataBaseSettings dataBaseSettings
            ) : base(
                executable,
                coreBaseResourceErrors,
                resourceSuccesses,
                resourceErrors,
                dataBaseSettings
                )
        {
        }

        #endregion Constructors

        #region Protected methods

        /// <inheritdoc/>
        protected sealed override IEnumerable<string> GetSuccessMessages(
            ModProductBaseJobItemGetOutput input,
            ModProductBaseJobItemGetOutput output
            )
        {
            return new[]
            {
                string.Format(
                    ResourceSuccesses.GetStringFormatObjectWithIdIsUpdated(),
                    output.ObjectProduct.Id
                    )
            };
        }

        #endregion Protected methods
    }
}