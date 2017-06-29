using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Practices.Unity;
using MehsCoreCommon.Dtos.Users;
using MehsCoreCommon.Data.Core.Enums;
using MehsCoreCommon.Dtos.UserCatalog;
using System.Collections.Generic;
using MehsCoreCommon.Data.Interfaces.UserCatalogCrud;
using System.IO;
using MehsCoreCommon.Data.Interfaces.UserCrud;
using MehsCoreCommon.Dtos.Applications;
using MehsCoreCommon.Data.Interfaces.ApplicationCrud;
using MehsCoreCommon.Dtos.Menu;
using MehsCoreCommon.Data.Interfaces.MenuCrud;
using MehsCoreCommon.Rules.Interfaces.RulesMenu;

namespace UnitTestMehsArchitecture
{
    [TestClass]
    public class UnitTestDatos
    {
        public UnitTestDatos()
        {
            string logPath = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "UnitTestMehsArchitecture.dll.config");
            log4net.Config.XmlConfigurator.Configure(new FileInfo(logPath));
            UserIoCConfig.InitDependencies();
        }

        [TestMethod]
        public void TestCreateUsertypes()
        {
            List<DtoUserCatalog> types = new List<DtoUserCatalog>() {
                new DtoUserCatalog()
                {
                    Id=1,
                    Description="Usuario",
                    Status=EnmEstatusEntity.A.ToString()
                },
                new DtoUserCatalog()
                {
                    Id=2,
                    Description="Desarrollador",
                    Status=EnmEstatusEntity.A.ToString()
                },
                new DtoUserCatalog()
                {
                    Id=3,
                    Description="Adminsitrador",
                    Status=EnmEstatusEntity.A.ToString()
                }
            };
            List<DtoUserCatalog> results = new List<DtoUserCatalog>();
            foreach (var utype in types)
            {
                var createTypes = UserIoCConfig.Contenedor.Resolve<ICreateUserCatalog>("CreateUsertype");
                results.Add(createTypes.CreateEntity(utype));
            }
            Assert.IsTrue(results.Count == 3);
        }

        [TestMethod]
        public void TestCreateUser()
        {
            //DtoUser user = new DtoUser()
            //{
            //    Email = "etzael_he@hotlook.com",
            //    Estatus = EnmEstatusEntity.A.ToString(),
            //    Password = "123456",
            //    Type = "Administrador",
            //    UserName = "etzael"
            //};
            DtoUser user = new DtoUser()
            {
                Email = "dummy@hotlook.com",
                Estatus = EnmEstatusEntity.A.ToString(),
                Password = "789456",
                Type = "Usuario",
                UserName = "miss dummy"
            };
            var create = UserIoCConfig.Contenedor.Resolve<ICreateUser>("CreateUser");
            var resultado = create.CreateEntity(user);
            Assert.IsNotNull(resultado);
        }

        [TestMethod]
        public void TestCreateApplication()
        {
            DtoApplication dto = new DtoApplication()
            {
                Activate = true,
                Description = "Aplicación CRM",
                Estatus = EnmEstatusEntity.A.ToString(),
                Name = "MEHS :: CRM",
                Url = "http://mehs.crm.com.mx"
            };
            var create = UserIoCConfig.Contenedor.Resolve<ICreateApplication>("CreateApp");
            var result = create.CreateEntity(dto);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestCreateMenu()
        {
            List<DtoMenu> options = new List<DtoMenu>() {
                new DtoMenu(){
                    Alt="Bugs :: Usuario",
                    Description="Mis Bugs",
                    Estatus=EnmEstatusEntity.A.ToString(),
                    Icon="fa-bug",
                    Order=1,
                    UserTypeRefId=3
                }
            };
            var create = UserIoCConfig.Contenedor.Resolve<ICreateMenu>("CreateMenu");
            var result = create.CreateEntity(options[0]);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestReadFilterMenu()
        {
            string typeuser = "Usuario";
            var filter = UserIoCConfig.Contenedor.Resolve<IReadFilterMenu>("FilterMenu");
            var result = filter.ReadAll(typeuser);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestBuildMenu()
        {
            string usertype = "Usuario";
            var build = UserIoCConfig.Contenedor.Resolve<IBuildHtmlMenu>();
            var result = build.BuildingMenu(usertype);
            Assert.IsNotNull(result);
        }
    }
}
