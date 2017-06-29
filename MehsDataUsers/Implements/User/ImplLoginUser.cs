using MehsCoreCommon.Data.Core;
using MehsCoreCommon.Security.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MehsCoreCommon.Dtos.Users;
using MehsDataUsers.Orm;
using MehsDataUsers.Pocos;
using log4net;

namespace MehsDataUsers.Implements.User
{
    public class ImplLoginUser : AbsCrud<DtoUser, UserPoco, UserDataContext>, ILoginUser
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(ImplLoginUser));

        public ImplLoginUser()
        {

        }

        public DtoUser Login(string username, string password)
        {
            try
            {
                using (contexto=new UserDataContext())
                {
                    var poco = (from u in contexto.Users
                                where u.Password.Equals(password)
                                && (u.Email.Equals(username) || u.UserName.Equals(username))
                                select u).SingleOrDefault();
                    if (poco != null)
                    {
                        return CastInverse(poco);
                    }
                    return null;
                }
            }
            catch (Exception e)
            {
                log.Error("Error al iniciar sesión", e);
                return null;
            }
        }
    }
}
