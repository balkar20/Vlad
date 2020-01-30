﻿//Author Maxim Kuzmin//makc//

using Vlad2020.Core.Base.Resources.Errors;
using Vlad2020.Core.Caching;
using Vlad2020.Core.Caching.Resources.Errors;
using Vlad2020.Data.Base;
using Vlad2020.Mods.DummyMain.Base;
using Vlad2020.Mods.DummyMain.Base.Resources.Errors;
using Vlad2020.Mods.DummyMain.Base.Resources.Successes;

namespace Vlad2020.Mods.DummyMain.Caching
{
    /// <summary>
    /// Мод "DummyMain". Кэширование. Внешнее.
    /// </summary>
    public class ModDummyMainCachingExternals
    {
        #region Properties

        /// <summary>
        /// Кэш.
        /// </summary>
        public ICoreCachingCache Cache { get; set; }

        /// <summary>
        /// Ядро. Основа. Ресурсы. Ошибки.
        /// </summary>
        public CoreBaseResourceErrors CoreBaseResourceErrors { get; set; }

        /// <summary>
        /// Ядро. Кэширование. Ресурсы. Ошибки.
        /// </summary>
        public CoreCachingResourceErrors CoreCachingResourceErrors { get; set; }

        /// <summary>
        /// Данные. Основа. Настройки.
        /// </summary>
        public DataBaseSettings DataBaseSettings { get; set; }

        /// <summary>
        /// Ресурс ошибок.
        /// </summary>
        public ModDummyMainBaseResourceErrors ResourceErrors { get; set; }

        /// <summary>
        /// Ресурс успехов.
        /// </summary>
        public ModDummyMainBaseResourceSuccesses ResourceSuccesses { get; set; }

        /// <summary>
        /// Сервис.
        /// </summary>
        public ModDummyMainBaseService Service { get; set; }

        #endregion Properties
    }
}
