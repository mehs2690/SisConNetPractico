using MehsCoreCommon.Data.Core.Crud;
using MehsCoreCommon.Dtos.Bugs;
using System;

namespace MehsCoreCommon.Data.Interfaces.BugCrud
{
    public interface IDeleteBug : IDelete<DtoBug, Guid>
    {
    }
}
