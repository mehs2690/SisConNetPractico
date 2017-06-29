using MehsCoreCommon.Rules.Interfaces.RulesUser;
using System;
using System.Collections.Generic;
using MehsCoreCommon.Dtos.Users;
using Microsoft.Practices.Unity;
using MehsCoreCommon.Data.Interfaces.UserCrud;

namespace MehsRulesUsers.Implements
{
    public class ImplRuleUser : IRepositoryUser
    {
        private ICreateUser create;
        private IReadUser read;
        private IReadFilterUser filter;
        private IUpdateUser update;
        private IDeleteUser delete;

        [Dependency("DeleteUser")]
        public IDeleteUser Delete
        {
            get { return delete; }
            set { delete = value; }
        }

        [Dependency("UpdateUser")]
        public IUpdateUser Update
        {
            get { return update; }
            set { update = value; }
        }

        [Dependency("FilterUser")]
        public IReadFilterUser Filter
        {
            get { return filter; }
            set { filter = value; }
        }

        [Dependency("ReadUser")]
        public IReadUser Read
        {
            get { return read; }
            set { read = value; }
        }

        [Dependency("CreateUser")]
        public ICreateUser Create
        {
            get { return create; }
            set { create = value; }
        }


        public ImplRuleUser()
        {

        }
        public DtoUser CreateRecord(DtoUser dto)
        {
            return create.CreateEntity(dto);
        }

        public DtoUser DeleteRecord(Guid id)
        {
            return delete.DeleteEntity(id);
        }

        public List<DtoUser> ReadAll(string by)
        {
            return filter.ReadAll(by);
        }

        public DtoUser ReadRecord(Guid id)
        {
            return read.ReadEntity(id);
        }

        public DtoUser UpdateRecord(DtoUser dto)
        {
            return update.UpdateEntity(dto);
        }
    }
}
