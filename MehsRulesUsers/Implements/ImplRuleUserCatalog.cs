using MehsCoreCommon.Rules.Interfaces.RulesUserCatalog;
using System.Collections.Generic;
using MehsCoreCommon.Dtos.UserCatalog;
using Microsoft.Practices.Unity;
using MehsCoreCommon.Data.Interfaces.UserCatalogCrud;

namespace MehsRulesUsers.Implements
{
    public class ImplRuleUserCatalog : IRepositoryUserCatalog
    {
        private ICreateUserCatalog create;
        private IReadUserCatalog read;
        private IReadFilterUserCatalog filter;
        private IUpdateUserCatalog update;
        private IDeleteUserCatalog delete;

        [Dependency("DeleteUsertype")]
        public IDeleteUserCatalog Delete
        {
            get { return delete; }
            set { delete = value; }
        }

        [Dependency("UpdateUsertype")]
        public IUpdateUserCatalog Update
        {
            get { return update; }
            set { update = value; }
        }

        [Dependency("FilterUsertype")]
        public IReadFilterUserCatalog Filter
        {
            get { return filter; }
            set { filter = value; }
        }

        [Dependency("ReadUsertype")]
        public IReadUserCatalog Read
        {
            get { return read; }
            set { read = value; }
        }

        [Dependency("CreateUsertype")]
        public ICreateUserCatalog Create
        {
            get { return create; }
            set { create = value; }
        }


        public ImplRuleUserCatalog()
        {

        }

        public DtoUserCatalog CreateRecord(DtoUserCatalog dto)
        {
            return create.CreateEntity(dto);
        }

        public DtoUserCatalog DeleteRecord(int id)
        {
            return delete.DeleteEntity(id);
        }

        public List<DtoUserCatalog> ReadAll(string by)
        {
            return filter.ReadAll(by);
        }

        public DtoUserCatalog ReadRecord(int id)
        {
            return read.ReadEntity(id);
        }

        public DtoUserCatalog UpdateRecord(DtoUserCatalog dto)
        {
            return update.UpdateEntity(dto);
        }
    }
}
