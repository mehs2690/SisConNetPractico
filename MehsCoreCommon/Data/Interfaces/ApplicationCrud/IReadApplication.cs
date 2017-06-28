using MehsCoreCommon.Data.Core.Crud;
using MehsCoreCommon.Dtos.Applications;
using System;

namespace MehsCoreCommon.Data.Interfaces.ApplicationCrud
{
    public interface IReadApplication : IRead<DtoApplication, Guid>
    {
    }
}
