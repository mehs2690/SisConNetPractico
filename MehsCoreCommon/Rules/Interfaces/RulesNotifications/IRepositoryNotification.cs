using System.Collections.Generic;

namespace MehsCoreCommon.Rules.Interfaces.RulesNotifications
{
    public interface IRepositoryNotification<Dto, Identity>
    {
        List<Dto> ReadAll(string by);
        Dto CreateRecord(Dto dto);
        Dto ReadRecord(Identity id);
    }
}
