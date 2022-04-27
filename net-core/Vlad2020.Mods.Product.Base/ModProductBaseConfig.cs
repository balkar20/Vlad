//Author Vlad Balkarov//vlad//

using Vlad2020.Core.Base;
using Vlad2020.Mods.Product.Base.Config;
using System.IO;

namespace Vlad2020.Mods.Product.Base
{
    /// <summary>
    /// Мод "Product". Основа. Конфигурация.
    /// </summary>
    public sealed class ModProductBaseConfig
    {
        #region Properties

        private CoreBaseEnvironment Environment { get; set; }

        private string FilePath { get; set; }

        /// <summary>
        /// Настройки.
        /// </summary>
        public IModProductBaseConfigSettings Settings { get; private set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="environment">Окружение.</param>
        public ModProductBaseConfig(CoreBaseEnvironment environment)
        {
            Environment = environment;

            FilePath = CreateFilePath();

            Settings = ModProductBaseConfigSettings.Create(FilePath, Environment);
        }

        #endregion Constructors

        #region Internal methods

        /// <summary>
        /// Создать путь к файлу.
        /// </summary>
        /// <returns>Путь к файлу.</returns>
        internal static string CreateFilePath()
        {
            return Path.Combine("ConfigFiles", "Mod.Product.Base.config");
        }

        #endregion Internal methods

        #region Рublic methods

        /// <summary>
        /// Создать поставщика.
        /// </summary>
        /// <param name="settings">Настройки.</param>
        public ModProductBaseConfigProvider CreateProvider(ModProductBaseConfigSettings settings)
        {
            return new ModProductBaseConfigProvider(settings, FilePath, Environment);
        }

        #endregion Рublic methods
    }
}