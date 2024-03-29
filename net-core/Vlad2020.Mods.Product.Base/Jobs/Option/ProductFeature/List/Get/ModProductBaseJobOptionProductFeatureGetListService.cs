﻿//Author Vlad Balkarov//vlad//

using Vlad2020.Core.Base.Executable.Services.Async;
using Vlad2020.Core.Base.Resources.Errors;
using Vlad2020.Mods.Product.Base.Common.Jobs.Option.List.Get;
using System;
using System.Threading.Tasks;

namespace Vlad2020.Mods.Product.Base.Jobs.Option.ProductFeature.List.Get
{
    /// <summary>
    /// Мод "Product". Задания. Вариант выбора. Сущность "ProductFeature". Список. Получение. Сервис.
    /// </summary>
    /// 
    public class ModProductBaseJobOptionProductFeatureGetListService : CoreBaseExecutableServiceAsyncWithOutput
        <
            ModProductBaseCommonJobOptionListGetOutput
        >
    {
        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="executable">Выполняемое.</param>
        /// <param name="coreBaseResourceErrors">Ядро. Основа. Ресурсы. Ошибки.</param>
        public ModProductBaseJobOptionProductFeatureGetListService(
            Func<Task<ModProductBaseCommonJobOptionListGetOutput>> executable,
            CoreBaseResourceErrors coreBaseResourceErrors
            ) : base(executable, coreBaseResourceErrors)
        {
        }

        #endregion Constructors
    }
}