using MehsCoreCommon.Data.Core.Crud;
using MehsCoreCommon.Dtos.Bugs;

namespace MehsCoreCommon.Data.Interfaces.BugCrud
{
    public interface IReadFilterBug : IReadAllWithFilter<DtoBug, string>
    {
    }
}
