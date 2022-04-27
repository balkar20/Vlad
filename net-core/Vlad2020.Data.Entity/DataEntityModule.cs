﻿//Author Vlad Balkarov//vlad//

using Vlad2020.Core.Base.Common;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Vlad2020.Data.Entity
{
    /// <summary>
    /// Данные. Entity Framework. Модуль.
    /// </summary>
    public class DataEntityModule : ICoreBaseCommonModule
    {
        #region Properties

        /// <summary>
        /// Контекст.
        /// </summary>
        public DataEntityContext Context { get; private set; }

        #endregion Properties

        #region Public methods

        /// <summary>
        /// Настроить сервисы.
        /// </summary>
        /// <param name="services">Сервисы.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient(x => GetContext(x).Jobs.JobDatabaseMigrate);
            services.AddTransient(x => GetContext(x).Service);
        }

        /// <summary>
        /// Инициализировать контекст.
        /// </summary>
        /// <param name="externals">Внешнее.</param>
        public void InitContext(DataEntityExternals externals)
        {
            Context = new DataEntityContext(externals);
        }

        #endregion Public methods

        #region Private methods

        private DataEntityContext GetContext(IServiceProvider serviceProvider)
        {
            return serviceProvider.GetService<DataEntityContext>();
        }

        #endregion Private methods
    }
}