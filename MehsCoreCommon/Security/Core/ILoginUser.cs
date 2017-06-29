using MehsCoreCommon.Dtos.Users;

namespace MehsCoreCommon.Security.Core
{
    public interface ILoginUser
    {
        DtoUser Login(string username, string password);
    }
}
