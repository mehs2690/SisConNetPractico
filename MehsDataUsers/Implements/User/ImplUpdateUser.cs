using log4net;
using MehsCoreCommon.Data.Core;
using MehsCoreCommon.Data.Interfaces.UserCrud;
using MehsCoreCommon.Dtos.Users;
using MehsDataUsers.Orm;
using MehsDataUsers.Pocos;
using System;
using System.Linq;

namespace MehsDataUsers.Implements.User
{
    public class ImplUpdateUser : AbsCrud<DtoUser, UserPoco, UserDataContext>, IUpdateUser
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(ImplUpdateUser));

        public ImplUpdateUser()
        {

        }

        protected override void MappingProps(ref UserPoco poco, DtoUser dto)
        {
            poco.Email = dto.Email;
            poco.Estatus = dto.Estatus;
            poco.Password = dto.Password;
            poco.Type = dto.Type;
            poco.UserName = dto.UserName;
        }


        public DtoUser UpdateEntity(DtoUser dto)
        {
            try
            {
                if (contexto == null)
                {
                    using (contexto = new UserDataContext())
                    {
                        return UpdateUser(dto);
                    }
                }
                else
                {
                    return UpdateUser(dto);
                }
            }
            catch (Exception e)
            {
                log.Error(string.Format(ERROR_UPDATE, typeof(UserPoco), dto.Id), e);
                return null;
            }
        }

        private DtoUser UpdateUser(DtoUser dto)
        {
            var bd = (from u in contexto.Users
                      where u.Id.Equals(dto.Id)
                      select u).SingleOrDefault();
            MappingProps(ref bd, dto);
            contexto.SaveChanges();
            return CastInverse(bd);
        }
    }
}
