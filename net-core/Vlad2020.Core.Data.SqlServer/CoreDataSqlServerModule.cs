﻿//Author Vlad Balkarov//vlad//

using Vlad2020.Core.Base.Common;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Vlad2020.Core.Data.SqlServer
{
    /// <summary>
    /// Ядро. Данные. SQL Server. Модуль.
    /// </summary>
    public class CoreDataSqlServerModule : ICoreBaseCommonModule
    {
        #region Properties

        /// <summary>
        /// Контекст.
        /// </summary>
        public CoreDataSqlServerContext Context { get; private set; } = new CoreDataSqlServerContext();

        #endregion Properties

        #region Public methods

        /// <summary>
        /// Настроить сервисы.
        /// </summary>
        /// <param name="services">Сервисы.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient(x => GetContext(x).Provider);
        }

        #endregion Public methods

        #region Private methods

        private CoreDataSqlServerContext GetContext(IServiceProvider serviceProvider)
        {
            return serviceProvider.GetService<CoreDataSqlServerContext>();
        }

        #endregion Private methods
    }
}