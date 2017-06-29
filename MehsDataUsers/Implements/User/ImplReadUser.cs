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
    public class ImplReadUser : AbsCrud<DtoUser, UserPoco, UserDataContext>, IReadUser
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(ImplReadUser));

        public ImplReadUser()
        {

        }

        public DtoUser ReadEntity(Guid read)
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
                log.Error(string.Format(ERROR_READ_BY_ID, typeof(UserPoco), read), e);
                return null;
            }
        }

        private DtoUser Select(Guid read)
        {
            var bd = (from u in contexto.Users
                      where u.Id.Equals(read)
                      select u).SingleOrDefault();
            if (bd != null)
            {
                return CastInverse(bd);
            }
            else
            {
                return null;
            }
        }
    }
}
