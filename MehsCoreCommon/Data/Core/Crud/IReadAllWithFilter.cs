using System.Collections.Generic;

namespace MehsCoreCommon.Data.Core.Crud
{
    public interface IReadAllWithFilter<Dto, ReadBy>
    {
        List<Dto> ReadAll(ReadBy by);
    }
}
