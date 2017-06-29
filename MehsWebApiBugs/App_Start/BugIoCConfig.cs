using MehsCoreCommon.Data.Interfaces.BugCrud;
using MehsCoreCommon.Data.Interfaces.NotificationCrud;
using MehsCoreCommon.Dtos.Notifications;
using MehsCoreCommon.Rules.Interfaces.RulesBug;
using MehsCoreCommon.Rules.Interfaces.RulesNotifications;
using MehsDataBugs.Implements.Bugs;
using MehsDataBugs.Implements.Notifications;
using MehsRulesBugs.Implements;
using Microsoft.Practices.Unity;
using System;

namespace MehsWebApiBugs
{
    public static class BugIoCConfig
    {
        private static UnityContainer contenedor = new UnityContainer();

        public static UnityContainer Contenedor
        {
            get { return contenedor; }
        }

        private static void RegisterDependencies()
        {
            contenedor.RegisterType<ICreateBug, ImplCreateBug>("CreateBug");
            contenedor.RegisterType<IReadBug, ImplReadBug>("ReadBug");
            contenedor.RegisterType<IReadFilterBug, ImplReadFilterBug>("FilterBug");
            contenedor.RegisterType<IUpdateBug, ImplUpdateBug>("UdpateBug");
            contenedor.RegisterType<IDeleteBug, ImplDeleteBug>("DeleteBug");

            contenedor.RegisterType<IRepositoryBug, ImplRuleBug>();

            contenedor.RegisterType<ICreateNotification, ImplCreateNotification>("CreateNotification");
            contenedor.RegisterType<IReadNotification, ImplReadNotification>("ReadNotification");
            contenedor.RegisterType<IReadFilterNotification, ImplFilterNotification>("FilterNotification");

            contenedor.RegisterType<IRepositoryNotification<DtoBugNotification, Guid>, ImplRuleNotification>();
        }

        public static void InitDependencies()
        {
            RegisterDependencies(); 
        }

    }
}