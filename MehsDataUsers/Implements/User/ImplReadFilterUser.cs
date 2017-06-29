using MehsCoreCommon.Data.Core;
using MehsCoreCommon.Data.Interfaces.UserCrud;
using System;
using System.Collections.Generic;
using System.Linq;
using MehsCoreCommon.Dtos.Users;
using MehsDataUsers.Orm;
using MehsDataUsers.Pocos;
using log4net;

namespace MehsDataUsers.Implements.User
{
    public class ImplReadFilterUser : AbsCrud<DtoUser, UserPoco, UserDataContext>, IReadFilterUser
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(ImplReadFilterUser));

        public ImplReadFilterUser()
        {

        }

        public List<DtoUser> ReadAll(string by)
        {
            try
            {
                if (contexto == null)
                {
                    using (contexto = new UserDataContext())
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
                log.Error("error en la consulta de filtro para usuarios", e);
                return null;
            }
        }

        private List<DtoUser> Filter(string by)
        {
            List<DtoUser> result = new List<DtoUser>();
            if (!string.IsNullOrEmpty(by))
            {

            }
            else
            {
                var bd = (from u in contexto.Users
                          select u).ToList();
                foreach (var u in bd)
                {
                    result.Add(CastInverse(u));
                }
            }
            return result;
        }
    }
}
