using MehsCoreCommon.Dtos.Applications;
using MehsCoreCommon.Rules.Core;
using System;

namespace MehsCoreCommon.Rules.Interfaces.RulesApplication
{
    public interface IRepositoryApplication : IRepositoryRestApi<DtoApplication, Guid>
    {
    }
}
