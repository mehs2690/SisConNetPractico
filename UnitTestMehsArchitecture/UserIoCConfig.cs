using MehsCoreCommon.Data.Interfaces.ApplicationCrud;
using MehsCoreCommon.Data.Interfaces.MenuCrud;
using MehsCoreCommon.Data.Interfaces.UserCatalogCrud;
using MehsCoreCommon.Data.Interfaces.UserCrud;
using MehsCoreCommon.Rules.Interfaces.RulesApplication;
using MehsCoreCommon.Rules.Interfaces.RulesMenu;
using MehsCoreCommon.Rules.Interfaces.RulesUser;
using MehsCoreCommon.Rules.Interfaces.RulesUserCatalog;
using MehsDataUsers.Implements.Application;
using MehsDataUsers.Implements.Menu;
using MehsDataUsers.Implements.User;
using MehsDataUsers.Implements.UserCatalog;
using MehsRulesUsers.Implements;
using Microsoft.Practices.Unity;

namespace UnitTestMehsArchitecture
{
    public static class UserIoCConfig
    {
        private static UnityContainer contenedor = new UnityContainer();

        public static UnityContainer Contenedor
        {
            get { return contenedor; }
        }

        public static void InitDependencies()
        {
            contenedor.RegisterType<ICreateUser, ImplCreateUser>("CreateUser");
            contenedor.RegisterType<IReadFilterUser, ImplReadFilterUser>("FilterUser");
            contenedor.RegisterType<IReadUser, ImplReadUser>("ReadUser");
            contenedor.RegisterType<IUpdateUser, ImplUpdateUser>("UdpateUser");
            contenedor.RegisterType<IDeleteUser, ImplDeleteUser>("DeleteUser");

            contenedor.RegisterType<IRepositoryUser, ImplRuleUser>();

            contenedor.RegisterType<ICreateApplication, ImplCreateApplication>("CreateApp");
            contenedor.RegisterType<IReadApplication, ImplReadApplication>("ReadApp");
            contenedor.RegisterType<IReadFilterApplication, ImplReadFilterApplication>("FilterApp");
            contenedor.RegisterType<IUpdateApplication, ImplUpdateApplication>("UpdateApp");
            contenedor.RegisterType<IDeleteApplication, ImplDeleteApplication>("DeleteApp");

            contenedor.RegisterType<IRepositoryApplication, ImplRuleApplication>();

            contenedor.RegisterType<ICreateMenu, ImplCreateMenu>("CreateMenu");
            contenedor.RegisterType<IReadMenu, ImplReadMenu>("ReadMenu");
            contenedor.RegisterType<IReadFilterMenu, ImplReadFilterMenu>("FilterMenu");
            contenedor.RegisterType<IUpdateMenu, ImplUpdateMenu>("UpdateMenu");
            contenedor.RegisterType<IDeleteMenu, ImplDeleteMenu>("DeleteMenu");

            contenedor.RegisterType<IRepositoryMenu, ImplRuleMenu>();
            contenedor.RegisterType<IBuildHtmlMenu, ImplRuleBuildHtmlMenu>();

            contenedor.RegisterType<ICreateUserCatalog, ImplCreateUserCatalog>("CreateUsertype");
            contenedor.RegisterType<IReadFilterUserCatalog, ImplReadFilterUserCatalog>("FilterUsertype");
            contenedor.RegisterType<IReadUserCatalog, ImplReadUserCatalog>("ReadUsertype");
            contenedor.RegisterType<IUpdateUserCatalog, ImplUpdateUserCatalog>("UdpateUsertype");
            contenedor.RegisterType<IDeleteUserCatalog, ImplDeleteUserCatalog>("DeleteUsertype");

            contenedor.RegisterType<IRepositoryUserCatalog, ImplRuleUserCatalog>();
        }
    }
}