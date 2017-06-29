using log4net;
using MehsCoreCommon.Data.Core;
using MehsCoreCommon.Data.Interfaces.UserCrud;
using MehsCoreCommon.Dtos.Users;
using MehsDataUsers.Orm;
using MehsDataUsers.Pocos;
using System;

namespace MehsDataUsers.Implements.User
{
    public class ImplCreateUser : AbsCrud<DtoUser, UserPoco, UserDataContext>, ICreateUser
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(ImplCreateUser));

        public ImplCreateUser()
        {

        }

        public DtoUser CreateEntity(DtoUser dto)
        {
            try
            {
                if (contexto == null)
                {
                    using (contexto = new UserDataContext())
                    {
                        return CreateUser(dto);
                    }
                }
                else
                {
                    return CreateUser(dto);
                }
            }
            catch (Exception e)
            {
                log.Error(string.Format(ERROR_CREATE, typeof(UserPoco)), e);
                return null;
            }
        }

        private DtoUser CreateUser(DtoUser dto)
        {
            UserPoco poco = Cast(dto);
            contexto.Users.Add(poco);
            contexto.SaveChanges();
            return CastInverse(poco);
        }
    }
}
