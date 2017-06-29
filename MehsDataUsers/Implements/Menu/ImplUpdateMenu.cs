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
    public class ImplUpdateMenu : AbsCrud<DtoMenu, MenuPoco, UserDataContext>, IUpdateMenu
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(ImplUpdateMenu));

        public ImplUpdateMenu()
        {

        }

        protected override void MappingProps(ref MenuPoco poco, DtoMenu dto)
        {
            poco.Alt = dto.Alt;
            poco.Description = dto.Description;
            poco.Estatus = dto.Estatus;
            poco.EventOn = dto.EventOn;
            poco.Icon = dto.Icon;
            poco.ImageUrl = dto.ImageUrl;
            poco.OptionType = dto.OptionType;
            poco.Order = dto.Order;
            poco.ParentRefId = dto.ParentId;
            poco.StyleClass = dto.StyleClass;
            poco.UserTypeRefId = dto.UserTypeRefId;
        }

        private DtoMenu UpdateMenu(DtoMenu dto)
        {
            var bd = (from m in contexto.Options
                      where m.Id.Equals(dto.Id)
                      select m).SingleOrDefault();
            MappingProps(ref bd, dto);
            contexto.SaveChanges();
            return CastInverse(bd);
        }

        public DtoMenu UpdateEntity(DtoMenu dto)
        {
            try
            {
                if (contexto == null)
                {
                    using (contexto = new UserDataContext())
                    {
                        return UpdateMenu(dto);
                    }
                }
                else
                {
                    return UpdateMenu(dto);
                }

            }
            catch (Exception e)
            {
                log.Error(string.Format(ERROR_UPDATE, typeof(MenuPoco), dto.Id), e);
                return null;
            }
        }
    }
}
