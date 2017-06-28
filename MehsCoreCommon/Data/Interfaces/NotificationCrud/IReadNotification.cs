using MehsCoreCommon.Data.Core.Crud;
using MehsCoreCommon.Dtos.Notifications;
using System;

namespace MehsCoreCommon.Data.Interfaces.NotificationCrud
{
    public interface IReadNotification : IRead<DtoBugNotification, Guid>
    {
    }
}
