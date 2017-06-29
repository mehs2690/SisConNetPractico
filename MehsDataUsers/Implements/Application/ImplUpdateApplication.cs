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
    public class ImplUpdateApplication : AbsCrud<DtoApplication, ApplicationPoco, UserDataContext>, IUpdateApplication
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(ImplUpdateApplication));

        public ImplUpdateApplication()
        {

        }

        protected override void MappingProps(ref ApplicationPoco poco, DtoApplication dto)
        {
            poco.Activate = dto.Activate;
            poco.Description = dto.Description;
            poco.Estatus = dto.Estatus;
            poco.Name = dto.Name;
            poco.Url = dto.Url;
        }

        private DtoApplication UpdateApplication(DtoApplication dto)
        {
            var bd = (from a in contexto.Applications
                      where a.Id.Equals(dto.Id)
                      select a).SingleOrDefault();
            MappingProps(ref bd, dto);
            contexto.SaveChanges();
            return CastInverse(bd);
        }

        public DtoApplication UpdateEntity(DtoApplication dto)
        {
            try
            {
                if (contexto == null)
                {
                    using (contexto = new UserDataContext())
                    {
                        return UpdateApplication(dto);
                    }
                }
                else
                {
                    return UpdateApplication(dto);
                }
            }
            catch (Exception e)
            {
                log.Error(string.Format(ERROR_UPDATE, typeof(ApplicationPoco), dto.Id), e);
                return null;
            }
        }
    }
}
