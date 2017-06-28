using MehsCoreCommon.Dtos.Users;
using MehsCoreCommon.Rules.Core;
using System;

namespace MehsCoreCommon.Rules.Interfaces.RulesUser
{
    public interface IRepositoryUser : IRepositoryRestApi<DtoUser, Guid>
    {
    }
}
