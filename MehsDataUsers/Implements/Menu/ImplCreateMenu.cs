using log4net;
using MehsCoreCommon.Data.Core;
using MehsCoreCommon.Data.Interfaces.MenuCrud;
using MehsCoreCommon.Dtos.Menu;
using MehsDataUsers.Orm;
using MehsDataUsers.Pocos;
using System;

namespace MehsDataUsers.Implements.Menu
{
    public class ImplCreateMenu : AbsCrud<DtoMenu, MenuPoco, UserDataContext>, ICreateMenu
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(ImplUpdateMenu));

        public ImplCreateMenu()
        {

        }

        private DtoMenu CreateOption(DtoMenu dto)
        {
            MenuPoco poco = Cast(dto);
            contexto.Options.Add(poco);
            contexto.SaveChanges();
            return CastInverse(poco);
        }
        public DtoMenu CreateEntity(DtoMenu dto)
        {
            try
            {
                if (contexto == null)
                {
                    using (contexto = new UserDataContext())
                    {
                        return CreateOption(dto);
                    }
                }
                else
                {
                    return CreateOption(dto);
                }
            }
            catch (Exception e)
            {
                log.Error(string.Format(ERROR_CREATE, typeof(MenuPoco)), e);
                return null;
            }
        }
    }
}
