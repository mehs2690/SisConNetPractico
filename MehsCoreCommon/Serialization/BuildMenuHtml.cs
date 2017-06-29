using MehsCoreCommon.Dtos.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MehsCoreCommon.Serialization
{
    public class BuildMenuHtml
    {
        private List<DtoMenu> menu;
        private string applicationName, applicationLink;
        private string SIDEBAR_BRAND_MODEL = "<li class=\"sidebar-brand\"><a href=\"{0}\">{1}</a></li>";

        private const string TOKEN_APP_LINK = "{AppLink}",
                             TOKEN_APP_NAME = "{AppName}",
                             OPEN_OPTION_STERILE = "<li >",
                             OPEN_OPTION_FATHER = "<li class=\"dropdown\" >",
                             CLOSE_OPTION_BOTH = "</li>",
                             OPTION_CHILDREN_MODEL = "<a data-modulo=\"{0}\" onclick=\"{1}\"><i class=\"fa fa-fw {2}\"></i> {3}</a>",
                             OPTION_FATHER_MODEL = "<a href=\"#\" class=\"dropdown-toggle\" data-toggle=\"dropdown\"><i class=\"fa fa-fw {0}\"></i> {1} <span class=\"caret\"></span></a>",
                             FOR_SUBMENU = "<ul class=\"dropdown-menu\" role=\"menu\">",
                             CLOSE_FOR_SUBMENU = "</ul>";


        public BuildMenuHtml(List<DtoMenu> menu, string applicationName, string applicationLink)
        {
            this.menu = menu;
            this.applicationName = applicationName;
            this.applicationLink = applicationLink;
        }

        private List<DtoMenu> GetChildrens(int idParent)
        {
            return menu.Select(x => x).Where(m => m.ParentId == idParent).OrderBy(o => o.Order).ToList();
        }

        private string Building(DtoMenu option)
        {
            StringBuilder sb = new StringBuilder();
            List<DtoMenu> childrens = GetChildrens(option.Id);
            if (childrens != null)
            {
                if (childrens.Count > 0)
                {
                    sb.Append(OPEN_OPTION_FATHER);
                    sb.AppendFormat(OPTION_FATHER_MODEL, option.Icon, option.Description);
                    sb.Append(FOR_SUBMENU);
                    foreach (var o in childrens)
                    {
                        sb.Append(Building(o));
                    }
                    sb.Append(CLOSE_FOR_SUBMENU);
                    sb.Append(CLOSE_OPTION_BOTH);
                }
                else
                {
                    sb.Append(OPEN_OPTION_STERILE);
                    sb.AppendFormat(OPTION_CHILDREN_MODEL, option.Description, option.StyleClass, option.Icon, option.Description);
                    sb.Append(CLOSE_OPTION_BOTH);
                }
            }
            else
            {
                sb.Append(OPEN_OPTION_STERILE);
                sb.AppendFormat(OPTION_CHILDREN_MODEL, option.Description, option.StyleClass, option.Icon, option.Description);
                sb.Append(CLOSE_OPTION_BOTH);
            }
            return sb.ToString();
        }

        public string GetMenuBuilded()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(SIDEBAR_BRAND_MODEL, applicationLink, applicationName);
            var padres = menu.Where(p => p.ParentId == null).OrderBy(x => x.Id).ToList();
            foreach (var padre in padres)
            {
                sb.Append(Building(padre));
            }
            return sb.ToString();
        }
    }
}
