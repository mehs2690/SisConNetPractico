using MehsCoreCommon.Data.Core.Crud;
using MehsCoreCommon.Dtos.Notifications;

namespace MehsCoreCommon.Data.Interfaces.NotificationCrud
{
    public interface IReadFilterNotification : IReadAllWithFilter<DtoBugNotification, string>
    {

    }
}
