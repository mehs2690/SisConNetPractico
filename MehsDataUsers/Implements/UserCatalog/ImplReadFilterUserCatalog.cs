using log4net;
using MehsCoreCommon.Data.Core;
using MehsCoreCommon.Data.Interfaces.UserCatalogCrud;
using MehsCoreCommon.Dtos.UserCatalog;
using MehsDataUsers.Orm;
using MehsDataUsers.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MehsDataUsers.Implements.UserCatalog
{
    public class ImplReadFilterUserCatalog : AbsCrud<DtoUserCatalog, UserCatalogPoco, UserDataContext>, IReadFilterUserCatalog
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(ImplReadFilterUserCatalog));

        public ImplReadFilterUserCatalog()
        {

        }
        public List<DtoUserCatalog> ReadAll(string by)
        {
            try
            {
                if (contexto == null)
                {
                    using (contexto = new UserDataContext())
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
                log.Error("error en el filtro de tipos de usuario", e);
                return null;
            }
        }

        private List<DtoUserCatalog> Filter(string by)
        {
            List<DtoUserCatalog> result = new List<DtoUserCatalog>();
            if (!string.IsNullOrEmpty(by))
            {

            }
            else
            {
                var bd = (from uc in contexto.UserTypes
                          select uc).ToList();
                foreach (var uc in bd)
                {
                    result.Add(CastInverse(uc));
                }
            }
            return result;
        }
    }
}
