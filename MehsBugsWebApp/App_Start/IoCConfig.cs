using MehsCoreCommon.Security.Core;
using MehsDataUsers.Implements.User;
using Microsoft.Practices.Unity;

namespace MehsBugsWebApp
{
    public static class IoCConfig
    {
        private static UnityContainer contenedor = new UnityContainer();

        public static UnityContainer Contenedor
        {
            get { return contenedor; }
        }

        public static void InitDependencies()
        {
            contenedor.RegisterType<ILoginUser, ImplLoginUser>("LoginUser");
        }

    }
}