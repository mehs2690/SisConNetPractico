using MehsCoreCommon.Rules.Interfaces.RulesMenu;
using System.Collections.Generic;
using MehsCoreCommon.Dtos.Menu;
using Microsoft.Practices.Unity;
using MehsCoreCommon.Data.Interfaces.MenuCrud;

namespace MehsRulesUsers.Implements
{
    public class ImplRuleMenu : IRepositoryMenu
    {
        private ICreateMenu create;
        private IReadMenu read;
        private IReadFilterMenu filter;
        private IUpdateMenu update;
        private IDeleteMenu delete;

        [Dependency("DeleteMenu")]
        public IDeleteMenu Delete
        {
            get { return delete; }
            set { delete = value; }
        }

        [Dependency("UpdateMenu")]
        public IUpdateMenu Update
        {
            get { return update; }
            set { update = value; }
        }

        [Dependency("FilterMenu")]
        public IReadFilterMenu Filter
        {
            get { return filter; }
            set { filter = value; }
        }

        [Dependency("ReadMenu")]
        public IReadMenu Read
        {
            get { return read; }
            set { read = value; }
        }

        [Dependency("CreateMenu")]
        public ICreateMenu Create
        {
            get { return create; }
            set { create = value; }
        }


        public ImplRuleMenu()
        {

        }

        public DtoMenu CreateRecord(DtoMenu dto)
        {
            return create.CreateEntity(dto);
        }

        public DtoMenu DeleteRecord(int id)
        {
            return delete.DeleteEntity(id);
        }

        public List<DtoMenu> ReadAll(string by)
        {
            return filter.ReadAll(by);
        }

        public DtoMenu ReadRecord(int id)
        {
            return read.ReadEntity(id);
        }

        public DtoMenu UpdateRecord(DtoMenu dto)
        {
            return update.UpdateEntity(dto);
        }
    }
}
