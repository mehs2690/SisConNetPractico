using MehsCoreCommon.Data.Core.Crud;
using MehsCoreCommon.Dtos.Users;
using System;

namespace MehsCoreCommon.Data.Interfaces.UserCrud
{
    public interface IReadUser : IRead<DtoUser, Guid>
    {
    }
}
