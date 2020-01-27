//Author Maxim Kuzmin//makc//

namespace Makc2020.Mods.Product.Base.Config
{
    /// <summary>
    /// Мод "Product". Основа. Конфигурация. Настройки. Интерфейс.
    /// </summary>
    public interface IModProductBaseConfigSettings
    {
        #region Properties

        /// <summary>
        /// Таймаут команд базы данных.
        /// </summary>
        int DbCommandTimeout { get; }

        #endregion Properties
    }
}