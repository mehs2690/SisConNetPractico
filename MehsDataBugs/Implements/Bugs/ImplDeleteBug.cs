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
    public class ImplDeleteBug : AbsCrud<DtoBug, BugPoco, BugDataContext>, IDeleteBug
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(ImplDeleteBug));

        public ImplDeleteBug()
        {

        }

        private DtoBug DeleteBug(Guid delete)
        {
            var bd = (from b in contexto.Bugs
                      where b.Id.Equals(delete)
                      select b).SingleOrDefault();
            DtoBug dto = CastInverse(bd);
            contexto.Bugs.Remove(bd);
            contexto.SaveChanges();
            return dto;
        }

        public DtoBug DeleteEntity(Guid delete)
        {
            try
            {
                if (contexto == null)
                {
                    using (contexto = new BugDataContext())
                    {
                        return DeleteBug(delete);
                    }
                }
                else
                {
                    return DeleteBug(delete);
                }
            }
            catch (Exception e)
            {
                log.Error(string.Format(ERROR_DELETE, typeof(BugPoco), delete), e);
                return null;
            }
        }
    }
}
