using MehsCoreCommon.Data.Core.Crud;
using MehsCoreCommon.Dtos.UserCatalog;
using System;

namespace MehsCoreCommon.Data.Interfaces.UserCatalogCrud
{
    public interface IDeleteUserCatalog : IDelete<DtoUserCatalog, Guid>
    {
    }
}
