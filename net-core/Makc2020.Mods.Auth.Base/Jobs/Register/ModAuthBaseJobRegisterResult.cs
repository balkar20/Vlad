//Author Maxim Kuzmin//makc//

using Vlad2020.Core.Base.Execution;
using Vlad2020.Host.Base.Parts.Auth;

namespace Vlad2020.Mods.Auth.Base.Jobs.Register
{
    /// <summary>
    /// Мод "Auth". Основа. Задания. Регистрация. Результат.
    /// </summary>
    public class ModAuthBaseJobRegisterResult : CoreBaseExecutionResultWithData
        <
            HostBasePartAuthUser
        >
    {
    }
}
