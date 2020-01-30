//Author Maxim Kuzmin//makc//

using Vlad2020.Core.Base.Execution;

namespace Vlad2020.Host.Base.Parts.Auth.Jobs.CurrentUser.Get
{
    /// <summary>
    /// Хост. Основа. Часть "Auth". Задания. Текущий пользователь. Получение. Результат.
    /// </summary>
    public class HostBasePartAuthJobCurrentUserGetResult : CoreBaseExecutionResultWithData
        <
            HostBasePartAuthUser
        >
    {
    }
}
