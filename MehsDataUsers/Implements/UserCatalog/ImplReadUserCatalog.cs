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
    public class ImplReadUserCatalog : AbsCrud<DtoUserCatalog, UserCatalogPoco, UserDataContext>, IReadUserCatalog
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(ImplReadUserCatalog));

        public ImplReadUserCatalog()
        {

        }

        public DtoUserCatalog ReadEntity(int read)
        {
            try
            {
                if (contexto == null)
                {
                    using (contexto = new UserDataContext())
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
                log.Error(string.Format(ERROR_READ_BY_ID, typeof(UserCatalogPoco), read), e);
                return null;
            }
        }

        private DtoUserCatalog Select(int read)
        {
            var bd = (from uc in contexto.UserTypes
                      where uc.Id == read
                      select uc).SingleOrDefault();
            if (bd != null)
            {
                return CastInverse(bd);
            }
            else
            {
                return null;
            }
        }
    }
}
