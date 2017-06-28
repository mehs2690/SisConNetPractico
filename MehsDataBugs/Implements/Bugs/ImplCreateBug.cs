using log4net;
using MehsCoreCommon.Data.Core;
using MehsCoreCommon.Data.Interfaces.BugCrud;
using MehsCoreCommon.Dtos.Bugs;
using MehsDataBugs.Orm;
using MehsDataBugs.Pocos;
using System;

namespace MehsDataBugs.Implements.Bugs
{
    public class ImplCreateBug : AbsCrud<DtoBug, BugPoco, BugDataContext>, ICreateBug
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(ImplCreateBug));

        public ImplCreateBug()
        {

        }

        private DtoBug CreateBug(DtoBug dto)
        {
            BugPoco poco = Cast(dto);
            contexto.Bugs.Add(poco);
            contexto.SaveChanges();
            return CastInverse(poco);
        }

        public DtoBug CreateEntity(DtoBug dto)
        {
            try
            {
                if (contexto == null)
                {
                    using (contexto = new BugDataContext())
                    {
                        return CreateBug(dto);
                    }
                }
                else
                {
                    return CreateBug(dto);
                }
            }
            catch (Exception e)
            {
                log.Error(string.Format(ERROR_CREATE, typeof(BugPoco)), e);
                return null;
            }

        }
    }
}
