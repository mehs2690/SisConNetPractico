using MehsCoreCommon.Data.Core;
using MehsCoreCommon.Data.Interfaces.UserCatalogCrud;
using System;
using System.Linq;
using MehsCoreCommon.Dtos.UserCatalog;
using MehsDataUsers.Orm;
using MehsDataUsers.Pocos;
using log4net;

namespace MehsDataUsers.Implements.UserCatalog
{
    public class ImplDeleteUserCatalog : AbsCrud<DtoUserCatalog, UserCatalogPoco, UserDataContext>, IDeleteUserCatalog
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(ImplDeleteUserCatalog));

        public ImplDeleteUserCatalog()
        {

        }

        public DtoUserCatalog DeleteEntity(int delete)
        {
            try
            {
                if (contexto == null)
                {
                    using (contexto = new UserDataContext())
                    {
                        return DeleteUsertype(delete);
                    }
                }
                else
                {
                    return DeleteUsertype(delete);
                }
            }
            catch (Exception e)
            {
                log.Error(string.Format(ERROR_DELETE, typeof(UserCatalogPoco), delete), e);
                return null;
            }
        }

        private DtoUserCatalog DeleteUsertype(int delete)
        {
            var bd = (from uc in contexto.UserTypes
                      where uc.Id == delete
                      select uc).SingleOrDefault();
            DtoUserCatalog dto = CastInverse(bd);
            contexto.UserTypes.Remove(bd);
            contexto.SaveChanges();
            return dto;
        }
    }
}
