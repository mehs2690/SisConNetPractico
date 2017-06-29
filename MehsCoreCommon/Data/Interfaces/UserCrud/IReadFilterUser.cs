using MehsCoreCommon.Data.Core.Crud;
using MehsCoreCommon.Dtos.Users;

namespace MehsCoreCommon.Data.Interfaces.UserCrud
{
    public interface IReadFilterUser : IReadAllWithFilter<DtoUser, string>
    {
    }
}
