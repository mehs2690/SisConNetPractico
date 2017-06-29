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
    public class ImplUpdateUserCatalog : AbsCrud<DtoUserCatalog, UserCatalogPoco, UserDataContext>, IUpdateUserCatalog
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(ImplUpdateUserCatalog));

        public ImplUpdateUserCatalog()
        {

        }

        protected override void MappingProps(ref UserCatalogPoco poco, DtoUserCatalog dto)
        {
            poco.Description = dto.Description;
            poco.Status = dto.Status;
        }

        public DtoUserCatalog UpdateEntity(DtoUserCatalog dto)
        {
            try
            {
                if (contexto == null)
                {
                    using (contexto = new UserDataContext())
                    {
                        return UpdateUserCatalog(dto);
                    }
                }
                else
                {
                    return UpdateUserCatalog(dto);
                }
            }
            catch (Exception e)
            {
                log.Error(string.Format(ERROR_UPDATE, typeof(UserCatalogPoco), dto.Id), e);
                return null;
            }
        }

        private DtoUserCatalog UpdateUserCatalog(DtoUserCatalog dto)
        {
            var bd = (from uc in contexto.UserTypes
                      where uc.Id == dto.Id
                      select uc).SingleOrDefault();
            MappingProps(ref bd, dto);
            contexto.SaveChanges();
            return CastInverse(bd);
        }
    }
}
