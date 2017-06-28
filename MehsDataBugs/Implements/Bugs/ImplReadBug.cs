using log4net;
using MehsCoreCommon.Data.Core;
using MehsCoreCommon.Data.Interfaces.BugCrud;
using MehsCoreCommon.Dtos.Bugs;
using MehsDataBugs.Orm;
using MehsDataBugs.Pocos;
using System;
using System.Linq;

namespace MehsDataBugs.Implements.Bugs
{
    public class ImplReadBug : AbsCrud<DtoBug, BugPoco, BugDataContext>, IReadBug
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(ImplReadBug));

        public ImplReadBug()
        {

        }

        private DtoBug Select(Guid read)
        {
            var db = (from b in contexto.Bugs
                      where b.Id.Equals(read)
                      select b).SingleOrDefault();
            if (db != null)
            {
                return CastInverse(db);
            }
            else
            {
                return null;
            }
        }

        public DtoBug ReadEntity(Guid read)
        {
            try
            {
                if (contexto == null)
                {
                    using (contexto = new BugDataContext())
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
                log.Error(string.Format(ERROR_READ_BY_ID, typeof(BugPoco), read), e);
                return null;
                throw;
            }
        }
    }
}
