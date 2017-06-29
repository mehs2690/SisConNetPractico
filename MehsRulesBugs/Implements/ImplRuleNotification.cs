using MehsCoreCommon.Data.Interfaces.NotificationCrud;
using MehsCoreCommon.Dtos.Notifications;
using MehsCoreCommon.Rules.Interfaces.RulesNotifications;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;

namespace MehsRulesBugs.Implements
{
    public class ImplRuleNotification : IRepositoryNotification<DtoBugNotification, Guid>
    {
        private ICreateNotification create;
        private IReadNotification read;
        private IReadFilterNotification filter;

        [Dependency("FitlerNotification")]
        public IReadFilterNotification Filter
        {
            get { return filter; }
            set { filter = value; }
        }

        [Dependency("ReadNotification")]
        public IReadNotification Read
        {
            get { return read; }
            set { read = value; }
        }

        [Dependency("CreateNotification")]
        public ICreateNotification Create
        {
            get { return create; }
            set { create = value; }
        }


        public ImplRuleNotification()
        {

        }

        public DtoBugNotification CreateRecord(DtoBugNotification dto)
        {
            return create.CreateEntity(dto);
        }

        public DtoBugNotification ReadRecord(Guid id)
        {
            return read.ReadEntity(id);
        }

        public List<DtoBugNotification> ReadAll(string by)
        {
            return filter.ReadAll(by);
        }
    }
}
