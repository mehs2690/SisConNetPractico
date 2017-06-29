using MehsCoreCommon.Data.Core.Crud;
using MehsCoreCommon.Dtos.UserCatalog;

namespace MehsCoreCommon.Data.Interfaces.UserCatalogCrud
{
    public interface IReadFilterUserCatalog : IReadAllWithFilter<DtoUserCatalog, string>
    {
    }
}
