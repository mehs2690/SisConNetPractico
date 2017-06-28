using MehsCoreCommon.Data.Core.Crud;
using MehsCoreCommon.Dtos.Profiles;
using System;

namespace MehsCoreCommon.Data.Interfaces.ProfileCrud
{
    public interface IReadProfile : IRead<DtoProfile, Guid>
    {
    }
}
