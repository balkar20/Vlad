﻿//Author Vlad Balkarov//vlad//

using Microsoft.Extensions.Configuration;
using System;

namespace Vlad2020.Core.Base.Ext
{
    /// <summary>
    /// Ядро. Основа. Расширение. Конфигурация.
    /// </summary>
    public static class CoreBaseExtConfig
    {
        #region Public methods

        /// <summary>
        /// Ядро. Основа. Расширение. Конфигурация. Добавить из JSON-файла.
        /// </summary>
        /// <param name="builder">Построитель конфигурации.</param>
        /// <param name="absolutePathToFileWithoutExtension">Абсолютный путь к файлу без расширения.</param>
        /// <param name="environmentName">Имя окружения.</param>
        /// <returns>Построитель конфигурации.</returns>
        public static IConfigurationBuilder CoreBaseExtConfigAddFromJsonFile(
            this IConfigurationBuilder builder,
            string absolutePathToFileWithoutExtension,
            string environmentName = null
            )
        {
            const string fileExtension = ".json";

            builder.AddJsonFile(
                $"{absolutePathToFileWithoutExtension}{fileExtension}",
                false,
                true
                );

            if (!string.IsNullOrWhiteSpace(environmentName))
            {
                builder.AddJsonFile(
                    $"{absolutePathToFileWithoutExtension}.{environmentName}{fileExtension}",
                    true,
                    true
                    );
            }

            builder.AddJsonFile(
                $"{absolutePathToFileWithoutExtension}.m.{Environment.MachineName}{fileExtension}",
                true,
                true
                );

            return builder;
        }

        #endregion Public methods
    }
}
