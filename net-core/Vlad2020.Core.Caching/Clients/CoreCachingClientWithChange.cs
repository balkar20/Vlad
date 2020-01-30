﻿//Author Maxim Kuzmin//makc//

using Vlad2020.Core.Caching.Ext;
using Vlad2020.Core.Caching.Resources.Errors;
using System;
using System.Threading.Tasks;

namespace Vlad2020.Core.Caching.Clients
{
    /// <summary>
    /// Ядро. Модуль. Кэширование. Клиенты. Клиент с изменением кэшируемых данных.
    /// </summary>    
    public class CoreCachingClientWithChange
    {
        #region Properties

        /// <summary>
        /// Кэш.
        /// </summary>
        private ICoreCachingCache Cache { get; set; }

        /// <summary>
        /// Ресурсы ошибок ядра кэширования.
        /// </summary>
        private CoreCachingResourceErrors CoreCachingResourceErrors { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="cache">Кэш.</param>
        /// <param name="coreCachingResourceErrors">Ресурсы ошибок ядра кэширования.</param>
        public CoreCachingClientWithChange(
            ICoreCachingCache cache,
            CoreCachingResourceErrors coreCachingResourceErrors
            )
        {
            Cache = cache;
            CoreCachingResourceErrors = coreCachingResourceErrors;
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        /// Изменить и прочитать данные.
        /// </summary>
        /// <param name="func">Функция для получения данных.</param>
        /// <param name="tags">Тэги.</param>
        /// <returns>Задача с данными.</returns>
        public Task Change(Func<Task> func, string[] tags)
        {
            return func.CoreCachingExtInvokeChange(Cache, tags, CoreCachingResourceErrors);
        }

        #endregion Public methods
    }
}
