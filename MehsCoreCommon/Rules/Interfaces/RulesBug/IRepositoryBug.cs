using MehsCoreCommon.Dtos.Bugs;
using MehsCoreCommon.Rules.Core;
using System;

namespace MehsCoreCommon.Rules.Interfaces.RulesBug
{
    public interface IRepositoryBug : IRepositoryRestApi<DtoBug, Guid>
    {
    }
}
