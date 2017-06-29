using MehsCoreCommon.Data.Core;
using System;
using System.Linq;
using MehsCoreCommon.Dtos.Menu;
using MehsDataUsers.Orm;
using MehsDataUsers.Pocos;
using log4net;
using MehsCoreCommon.Data.Interfaces.MenuCrud;

namespace MehsDataUsers.Implements.Menu
{
    public class ImplDeleteMenu : AbsCrud<DtoMenu, MenuPoco, UserDataContext>, IDeleteMenu
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(ImplDeleteMenu));

        public ImplDeleteMenu()
        {

        }

        public DtoMenu DeleteEntity(int delete)
        {
            try
            {
                if (contexto == null)
                {
                    using (contexto = new UserDataContext())
                    {
                        return DeleteOption(delete);
                    }
                }
                else
                {
                    return DeleteOption(delete);
                }
            }
            catch (Exception e)
            {
                log.Error(string.Format(ERROR_DELETE, typeof(MenuPoco), delete), e);
                return null;
            }
        }

        private DtoMenu DeleteOption(int delete)
        {
            var bd = (from m in contexto.Options
                      where m.Id == delete
                      select m).SingleOrDefault();
            DtoMenu dto = CastInverse(bd);
            contexto.Options.Remove(bd);
            contexto.SaveChanges();
            return dto;
        }
    }
}
