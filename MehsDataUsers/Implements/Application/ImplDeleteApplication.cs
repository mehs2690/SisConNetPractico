using log4net;
using MehsCoreCommon.Data.Core;
using MehsCoreCommon.Data.Interfaces.ApplicationCrud;
using MehsCoreCommon.Dtos.Applications;
using MehsDataUsers.Orm;
using MehsDataUsers.Pocos;
using System;
using System.Linq;

namespace MehsDataUsers.Implements.Application
{
    public class ImplDeleteApplication : AbsCrud<DtoApplication, ApplicationPoco, UserDataContext>, IDeleteApplication
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(ImplDeleteApplication));

        public ImplDeleteApplication()
        {

        }

        private DtoApplication DeleteApplication(Guid delete)
        {
            var bd = (from a in contexto.Applications
                      where a.Id.Equals(delete)
                      select a).SingleOrDefault();
            DtoApplication dto = CastInverse(bd);
            contexto.Applications.Remove(bd);
            contexto.SaveChanges();
            return dto;
        }

        public DtoApplication DeleteEntity(Guid delete)
        {
            try
            {
                if (contexto == null)
                {
                    using (contexto = new UserDataContext())
                    {
                        return DeleteApplication(delete);
                    }
                }
                else
                {
                    return DeleteApplication(delete);
                }
            }
            catch (Exception e)
            {
                log.Error(string.Format(ERROR_DELETE, typeof(ApplicationPoco), delete), e);
                return null;
            }
        }
    }
}
