//Author Vlad Balkarov//vlad//

using Microsoft.Extensions.Logging;

namespace Vlad2020.Core.Web
{
    /// <summary>
    /// Ядро. Веб. Модель.
    /// </summary>
    public class CoreWebModel
    {
        #region Properties

        /// <summary>
        /// Регистратор.
        /// </summary>
        protected ILogger ExtLogger { get; private set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="extLogger">Регистратор.</param>
        public CoreWebModel(ILogger extLogger)
        {
            ExtLogger = extLogger;
        }

        #endregion Constructors
    }
}
