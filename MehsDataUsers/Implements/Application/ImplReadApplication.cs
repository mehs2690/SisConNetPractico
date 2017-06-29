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
    public class ImplReadApplication : AbsCrud<DtoApplication, ApplicationPoco, UserDataContext>, IReadApplication
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(ImplReadApplication));

        public ImplReadApplication()
        {

        }

        private DtoApplication Select(Guid read)
        {
            var bd = (from a in contexto.Applications
                      where a.Id.Equals(read)
                      select a).SingleOrDefault();
            if (bd != null)
            {
                return CastInverse(bd);
            }
            else
            {
                return null;
            }
        }

        public DtoApplication ReadEntity(Guid read)
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
                log.Error(string.Format(ERROR_READ_BY_ID, typeof(ApplicationPoco), read), e);
                return null;
            }
        }
    }
}
