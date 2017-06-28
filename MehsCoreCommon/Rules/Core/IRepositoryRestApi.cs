using System.Collections.Generic;

namespace MehsCoreCommon.Rules.Core
{
    public interface IRepositoryRestApi<Dto, Identity>
    {
        List<Dto> ReadAll(string by);
        Dto ReadRecord(Identity id);
        Dto CreateRecord(Dto dto);
        Dto UpdateRecord(Dto dto);
        Dto DeleteRecord(Identity id);
    }
}
