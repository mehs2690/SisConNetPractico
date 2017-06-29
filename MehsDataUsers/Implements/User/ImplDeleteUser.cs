using MehsCoreCommon.Data.Core;
using MehsCoreCommon.Data.Interfaces.UserCrud;
using System;
using System.Linq;
using MehsCoreCommon.Dtos.Users;
using MehsDataUsers.Orm;
using MehsDataUsers.Pocos;
using log4net;

namespace MehsDataUsers.Implements.User
{
    public class ImplDeleteUser : AbsCrud<DtoUser, UserPoco, UserDataContext>, IDeleteUser
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(ImplDeleteUser));

        public ImplDeleteUser()
        {

        }

        public DtoUser DeleteEntity(Guid delete)
        {
            try
            {
                if (contexto == null)
                {
                    using (contexto = new UserDataContext())
                    {
                        return DeleteUser(delete);
                    }
                }
                else
                {
                    return DeleteUser(delete);
                }
            }
            catch (Exception e)
            {
                log.Error(string.Format(ERROR_DELETE, typeof(UserPoco), delete), e);
                return null;
            }
        }

        private DtoUser DeleteUser(Guid delete)
        {
            var bd = (from u in contexto.Users
                      where u.Id.Equals(delete)
                      select u).SingleOrDefault();
            DtoUser dto = CastInverse(bd);
            contexto.Users.Remove(bd);
            contexto.SaveChanges();
            return dto;
        }
    }
}
