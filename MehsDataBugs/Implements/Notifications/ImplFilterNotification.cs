using log4net;
using MehsCoreCommon.Data.Core;
using MehsCoreCommon.Data.Interfaces.NotificationCrud;
using MehsCoreCommon.Dtos.Notifications;
using MehsDataBugs.Orm;
using MehsDataBugs.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MehsDataBugs.Implements.Notifications
{
    public class ImplFilterNotification : AbsCrud<DtoBugNotification, BugNotificationPoco, BugDataContext>, IReadFilterNotification
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(ImplFilterNotification));

        public ImplFilterNotification()
        {

        }

        private List<DtoBugNotification> Filter(string by)
        {
            List<DtoBugNotification> results = new List<DtoBugNotification>();

            if (!string.IsNullOrEmpty(by))
            {

            }
            else
            {
                var bd = (from n in contexto.Notifications
                          orderby n.IssuedDate descending
                          select n).ToList();
                foreach (var noti in bd)
                {
                    results.Add(CastInverse(noti));
                }
            }
            return results;
        }

        public List<DtoBugNotification> ReadAll(string by)
        {
            try
            {
                if (contexto == null)
                {
                    using (contexto = new BugDataContext())
                    {
                        return Filter(by);
                    }
                }
                else
                {
                    return Filter(by);
                }
            }
            catch (Exception e)
            {
                log.Error("Error al obtener un filtro de notificaciones", e);
                return null;
            }
        }
    }
}
