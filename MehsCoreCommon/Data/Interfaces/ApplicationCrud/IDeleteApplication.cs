using MehsCoreCommon.Data.Core.Crud;
using MehsCoreCommon.Dtos.Applications;
using System;

namespace MehsCoreCommon.Data.Interfaces.ApplicationCrud
{
    public interface IDeleteApplication : IDelete<DtoApplication, Guid>
    {
    }
}
