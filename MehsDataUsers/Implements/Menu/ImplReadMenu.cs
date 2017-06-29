using log4net;
using MehsCoreCommon.Data.Core;
using MehsCoreCommon.Data.Interfaces.MenuCrud;
using MehsCoreCommon.Dtos.Menu;
using MehsDataUsers.Orm;
using MehsDataUsers.Pocos;
using System;
using System.Linq;

namespace MehsDataUsers.Implements.Menu
{
    public class ImplReadMenu : AbsCrud<DtoMenu, MenuPoco, UserDataContext>, IReadMenu
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(ImplReadMenu));

        public ImplReadMenu()
        {

        }

        private DtoMenu Select(int read)
        {
            var bd = (from m in contexto.Options
                      where m.Id == read
                      select m).SingleOrDefault();
            if (bd != null)
            {
                return CastInverse(bd);
            }
            else
            {
                return null;
            }
        }

        public DtoMenu ReadEntity(int read)
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
                log.Error(string.Format(ERROR_READ_BY_ID, typeof(MenuPoco), read), e);
                return null;
            }
        }
    }
}
