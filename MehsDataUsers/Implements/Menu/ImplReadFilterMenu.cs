using log4net;
using MehsCoreCommon.Data.Core;
using MehsCoreCommon.Data.Interfaces.MenuCrud;
using MehsCoreCommon.Dtos.Menu;
using MehsDataUsers.Orm;
using MehsDataUsers.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MehsDataUsers.Implements.Menu
{
    public class ImplReadFilterMenu : AbsCrud<DtoMenu, MenuPoco, UserDataContext>, IReadFilterMenu
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(ImplReadFilterMenu));

        public ImplReadFilterMenu()
        {

        }

        public List<DtoMenu> ReadAll(string by)
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
                log.Error("Error al consultar las opciones menú ", e);
                return null;
            }
        }

        private List<DtoMenu> Filter(string by)
        {
            List<DtoMenu> result = new List<DtoMenu>();
            if (!string.IsNullOrEmpty(by))
            {
                string o = by;
                int iduser = (from ut in contexto.UserTypes
                              where ut.Description.Equals(o)
                              select ut.Id).SingleOrDefault();

                var bd = (from m in contexto.Options
                          where m.UserTypeRefId == iduser
                          select m).ToList();
                foreach (var m in bd)
                {
                    result.Add(CastInverse(m));
                }
            }
            else
            {
                var bd = (from m in contexto.Options
                          select m).ToList();
                foreach (var m in bd)
                {
                    result.Add(CastInverse(m));
                }
            }
            return result;
        }
    }
}
