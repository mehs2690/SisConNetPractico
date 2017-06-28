using MehsCoreCommon.Dtos.Profiles;
using MehsCoreCommon.Rules.Core;
using System;

namespace MehsCoreCommon.Rules.Interfaces.RulesProfile
{
    public interface IRepositoryProfile : IRepositoryRestApi<DtoProfile, Guid>
    {
    }
}
