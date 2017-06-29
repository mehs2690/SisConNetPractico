using log4net;
using MehsCoreCommon.Data.Core;
using MehsCoreCommon.Data.Interfaces.BugCrud;
using MehsCoreCommon.Dtos.Bugs;
using MehsDataBugs.Orm;
using MehsDataBugs.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MehsDataBugs.Implements.Bugs
{
    public class ImplReadFilterBug : AbsCrud<DtoBug, BugPoco, BugDataContext>, IReadFilterBug
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(ImplReadFilterBug));

        public ImplReadFilterBug()
        {

        }

        private List<DtoBug> Filter(string by)
        {
            List<DtoBug> result = new List<DtoBug>();

            if (!string.IsNullOrEmpty(by))
            {

            }
            else
            {
                var bd = (from b in contexto.Bugs
                          select b).ToList();
                foreach (var bug in bd)
                {
                    result.Add(CastInverse(bug));
                }
            }

            return result;
        }

        public List<DtoBug> ReadAll(string by)
        {
            try
            {
                if (contexto == null)
                {
                    using (contexto = new BugDataContext())
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
                log.Error("Error al consultar los registros de tipo bug", e);
                return null;
            }
        }
    }
}
