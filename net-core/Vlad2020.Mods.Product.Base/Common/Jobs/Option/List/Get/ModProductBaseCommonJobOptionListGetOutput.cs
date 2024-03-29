﻿//Author Vlad Balkarov//vlad//

using Vlad2020.Core.Base.Common.Jobs.Option.List.Get;
using Vlad2020.Mods.Product.Base.Common.Jobs.Option.Item.Get;

namespace Vlad2020.Mods.Product.Base.Common.Jobs.Option.List.Get
{
    /// <summary>
    /// Мод "Product". Основа. Общее. Задания. Вариант выбора. Список. Получение. Вывод.
    /// </summary>
    public class ModProductBaseCommonJobOptionListGetOutput : CoreBaseCommonJobOptionListGetOutput
        <
            ModProductBaseCommonJobOptionItemGetOutput 
        >
    {
    }
}