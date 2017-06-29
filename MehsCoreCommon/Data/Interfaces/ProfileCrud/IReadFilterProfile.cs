using MehsCoreCommon.Data.Core.Crud;
using MehsCoreCommon.Dtos.Profiles;

namespace MehsCoreCommon.Data.Interfaces.ProfileCrud
{
    public interface IReadFilterProfile : IReadAllWithFilter<DtoProfile, string>
    {
    }
}
