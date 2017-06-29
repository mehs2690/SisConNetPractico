using MehsCoreCommon.Rules.Interfaces.RulesApplication;
using System;
using System.Collections.Generic;
using MehsCoreCommon.Dtos.Applications;
using Microsoft.Practices.Unity;
using MehsCoreCommon.Data.Interfaces.ApplicationCrud;

namespace MehsRulesUsers.Implements
{
    public class ImplRuleApplication : IRepositoryApplication
    {
        private ICreateApplication create;
        private IReadApplication read;
        private IReadFilterApplication filter;
        private IUpdateApplication update;
        private IDeleteApplication delete;

        [Dependency("DeleteApp")]
        public IDeleteApplication Delete
        {
            get { return delete; }
            set { delete = value; }
        }

        [Dependency("UpdateApp")]
        public IUpdateApplication Udpate
        {
            get { return update; }
            set { update = value; }
        }

        [Dependency("FilterApp")]
        public IReadFilterApplication Filter
        {
            get { return filter; }
            set { filter = value; }
        }

        [Dependency("ReadApp")]
        public IReadApplication Read
        {
            get { return read; }
            set { read = value; }
        }

        [Dependency("CreateApp")]
        public ICreateApplication Create
        {
            get { return create; }
            set { create = value; }
        }


        public ImplRuleApplication()
        {

        }

        public DtoApplication CreateRecord(DtoApplication dto)
        {
            return create.CreateEntity(dto);
        }

        public DtoApplication DeleteRecord(Guid id)
        {
            return delete.DeleteEntity(id);
        }

        public List<DtoApplication> ReadAll(string by)
        {
            return filter.ReadAll(by);
        }

        public DtoApplication ReadRecord(Guid id)
        {
            return read.ReadEntity(id);
        }

        public DtoApplication UpdateRecord(DtoApplication dto)
        {
            return update.UpdateEntity(dto);
        }
    }
}
