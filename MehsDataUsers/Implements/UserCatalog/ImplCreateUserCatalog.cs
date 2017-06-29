using MehsCoreCommon.Data.Core;
using MehsCoreCommon.Data.Interfaces.UserCatalogCrud;
using System;
using MehsCoreCommon.Dtos.UserCatalog;
using MehsDataUsers.Orm;
using MehsDataUsers.Pocos;
using log4net;

namespace MehsDataUsers.Implements.UserCatalog
{
    public class ImplCreateUserCatalog : AbsCrud<DtoUserCatalog, UserCatalogPoco, UserDataContext>, ICreateUserCatalog
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(ImplCreateUserCatalog));

        public ImplCreateUserCatalog()
        {

        }

        public DtoUserCatalog CreateEntity(DtoUserCatalog dto)
        {
            try
            {
                if (contexto == null)
                {
                    using (contexto = new UserDataContext())
                    {
                        return CreateUsertype(dto);
                    }
                }
                else
                {
                    return CreateUsertype(dto);
                }
            }
            catch (Exception e)
            {
                log.Error(string.Format(ERROR_CREATE, typeof(UserCatalogPoco)), e);
                return null;
            }
        }

        private DtoUserCatalog CreateUsertype(DtoUserCatalog dto)
        {
            UserCatalogPoco poco = Cast(dto);
            contexto.UserTypes.Add(poco);
            contexto.SaveChanges();
            return CastInverse(poco);
        }
    }
}
