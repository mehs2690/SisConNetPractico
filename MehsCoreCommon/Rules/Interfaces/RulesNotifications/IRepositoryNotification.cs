namespace MehsCoreCommon.Rules.Interfaces.RulesNotifications
{
    public interface IRepositoryNotification<Dto, Identity>
    {
        Dto ReadAll(Identity id);
        Dto Create(Dto dto);
        Dto Read(Identity id);
    }
}
