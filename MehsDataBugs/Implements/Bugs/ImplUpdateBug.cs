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
    public class ImplUpdateBug : AbsCrud<DtoBug, BugPoco, BugDataContext>, IUpdateBug
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(ImplUpdateBug));

        public ImplUpdateBug()
        {

        }

        protected override void MappingProps(ref BugPoco poco, DtoBug dto)
        {
            poco.AppId = dto.AppId;
            poco.BugClosedDate = dto.BugClosedDate;
            poco.Description = dto.Description;
            poco.Image = dto.Image;
            poco.Status = dto.Status;
            poco.UserRegId = dto.UserRegId;
            poco.UserSolId = dto.UserSolId;
        }

        private DtoBug UpdateBug(DtoBug dto)
        {
            var bd = (from b in contexto.Bugs
                      where b.Id.Equals(dto.Id)
                      select b).SingleOrDefault();
            MappingProps(ref bd, dto);
            contexto.SaveChanges();
            return CastInverse(bd);
        }

        public DtoBug UpdateEntity(DtoBug dto)
        {
            try
            {
                if (contexto == null)
                {
                    using (contexto = new BugDataContext())
                    {
                        return UpdateBug(dto);
                    }
                }
                else
                {
                    return UpdateBug(dto);
                }
            }
            catch (Exception e)
            {
                log.Error(string.Format(ERROR_UPDATE, typeof(BugPoco), dto.Id), e);
                return null;
            }
        }
    }
}
