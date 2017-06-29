using MehsCoreCommon.Data.Core.Crud;
using MehsCoreCommon.Dtos.Applications;

namespace MehsCoreCommon.Data.Interfaces.ApplicationCrud
{
    public interface IReadFilterApplication : IReadAllWithFilter<DtoApplication, string>
    {
    }
}
