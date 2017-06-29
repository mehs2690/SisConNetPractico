using log4net;
using MehsCoreCommon.Data.Core;
using MehsCoreCommon.Dtos.Notifications;
using MehsDataBugs.Orm;
using MehsDataBugs.Pocos;
using System;
using MehsCoreCommon.Data.Interfaces.NotificationCrud;

namespace MehsDataBugs.Implements.Notifications
{
    public class ImplCreateNotification : AbsCrud<DtoBugNotification, BugNotificationPoco, BugDataContext>, ICreateNotification
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(ImplCreateNotification));

        private DtoBugNotification CreateNotification(DtoBugNotification dto)
        {
            BugNotificationPoco poco = Cast(dto);
            contexto.Notifications.Add(poco);
            contexto.SaveChanges();
            return CastInverse(poco);
        }

        public DtoBugNotification CreateEntity(DtoBugNotification dto)
        {
            try
            {
                if (contexto == null)
                {
                    using (contexto = new BugDataContext())
                    {
                        return CreateNotification(dto);
                    }
                }
                else
                {
                    return CreateNotification(dto);
                }
            }
            catch (Exception e)
            {
                log.Error(string.Format(ERROR_CREATE, typeof(BugNotificationPoco)), e);
                return null;
            }
        }
    }
}
