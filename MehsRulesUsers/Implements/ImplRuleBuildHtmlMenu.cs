using MehsCoreCommon.Rules.Interfaces.RulesMenu;
using System.Collections.Generic;
using MehsCoreCommon.Dtos.Menu;
using MehsCoreCommon.Serialization;
using Microsoft.Practices.Unity;
using MehsCoreCommon.Data.Interfaces.MenuCrud;

namespace MehsRulesUsers.Implements
{
    public class ImplRuleBuildHtmlMenu : IBuildHtmlMenu
    {
        private string UserType;
        private BuildMenuHtml builder;
        private IReadFilterMenu read;
        private List<DtoMenu> options;

        [Dependency("FilterMenu")]
        public IReadFilterMenu Read
        {
            get { return read; }
            set { read = value; }
        }

        public ImplRuleBuildHtmlMenu()
        {
        }

        private void GetMenuByUserType()
        {
            options = read.ReadAll(UserType);
        }

        public string BuildingMenu(string UserType)
        {
            this.UserType = UserType;
            GetMenuByUserType();
            builder = new BuildMenuHtml(options, "MEHS :: BUGS", "#");
            return builder.GetMenuBuilded();
        }
    }
}
