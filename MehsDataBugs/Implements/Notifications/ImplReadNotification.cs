using log4net;
using MehsCoreCommon.Data.Core;
using MehsCoreCommon.Data.Interfaces.NotificationCrud;
using MehsCoreCommon.Dtos.Notifications;
using MehsDataBugs.Orm;
using MehsDataBugs.Pocos;
using System;
using System.Linq;

namespace MehsDataBugs.Implements.Notifications
{
    public class ImplReadNotification : AbsCrud<DtoBugNotification, BugNotificationPoco, BugDataContext>, IReadNotification
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(ImplReadNotification));

        public ImplReadNotification()
        {

        }

        private DtoBugNotification Select(Guid read)
        {
            var bd = (from n in contexto.Notifications
                      where n.Id.Equals(read)
                      select n).SingleOrDefault();
            if (bd != null)
            {
                return CastInverse(bd);
            }
            else
            {
                return null;
            }
        }

        public DtoBugNotification ReadEntity(Guid read)
        {
            try
            {
                if (contexto == null)
                {
                    using (contexto = new BugDataContext())
                    {
                        return Select(read);
                    }
                }
                else
                {
                    return Select(read);
                }
            }
            catch (Exception e)
            {
                log.Error(string.Format(ERROR_READ_BY_ID, typeof(BugNotificationPoco), read), e);
                return null;
            }
        }
    }
}
