﻿//Author Vlad Balkarov//vlad//

using System;

namespace Vlad2020.Core.Base.Common
{
    /// <summary>
    /// Ядро. Основа. Общее. Сервер. Интерфейс.
    /// </summary>
    public interface ICoreBaseCommonServer
    {
        #region Events

        /// <summary>
        /// Событие, возникающее после инициализации.
        /// </summary>
        event EventHandler AfterInit;

        #endregion Events

        #region Methods

        /// <summary>
        /// Инициализировать.
        /// </summary>
        void Init();

        #endregion Methods
    }
}
