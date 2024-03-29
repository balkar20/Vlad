﻿//Author Vlad Balkarov//vlad//

using Vlad2020.Core.Base;
using Vlad2020.Core.Caching.Common.Client.Config;

namespace Vlad2020.Mods.Product.Caching.Config
{
    /// <summary>
    /// Мод "Product". Кэширование. Конфигурация. Настройки.
    /// </summary>
    public class ModProductCachingConfigSettings : ICoreCachingCommonClientConfigSettings
    {
        #region Properties

        /// <summary>
        /// Окончание срока действия кэша в секундах.
        /// </summary>
        public int CacheExpiryInSeconds { get; set; }

        /// <summary>
        /// Признак включения кэширования.
        /// </summary>
        public bool IsCachingEnabled { get; private set; }

        /// <summary>
        /// Префикс ключа кэша.
        /// </summary>
        public string CacheKeyPrefix { get; private set; }

        #endregion Properties

        #region Internal methods

        /// <summary>
        /// Создать.
        /// </summary>
        /// <param name="configFilePath">Путь к файлу конфигурации.</param>
        /// <param name="environment">Окружение.</param>
        /// <returns>Конфигурационные настройки.</returns>
        internal static ICoreCachingCommonClientConfigSettings Create(string configFilePath, CoreBaseEnvironment environment)
        {
            var result = new ModProductCachingConfigSettings();

            var configProvider = new ModProductCachingConfigProvider(result, configFilePath, environment);

            configProvider.Load();

            return result;
        }

        #endregion Internal methods
    }
}