using MehsCoreCommon.Rules.Interfaces.RulesBug;
using System;
using System.Collections.Generic;
using MehsCoreCommon.Dtos.Bugs;
using Microsoft.Practices.Unity;
using MehsCoreCommon.Data.Interfaces.BugCrud;

namespace MehsRulesBugs.Implements
{
    public class ImplRuleBug : IRepositoryBug
    {
        private ICreateBug create;
        private IReadBug read;
        private IUpdateBug update;
        private IDeleteBug delete;
        private IReadFilterBug filter;

        [Dependency("FilterBug")]
        public IReadFilterBug Filter
        {
            get { return filter; }
            set { filter = value; }
        }

        [Dependency("DeleteBug")]
        public IDeleteBug Delete
        {
            get { return delete; }
            set { delete = value; }
        }

        [Dependency("UpdateBug")]
        public IUpdateBug Update
        {
            get { return update; }
            set { update = value; }
        }

        [Dependency("ReadBug")]
        public IReadBug Read
        {
            get { return read; }
            set { read = value; }
        }

        [Dependency("CreateBug")]
        public ICreateBug Create
        {
            get { return create; }
            set { create = value; }
        }

        public ImplRuleBug()
        {

        }

        public DtoBug CreateRecord(DtoBug dto)
        {
            return create.CreateEntity(dto);
        }

        public DtoBug DeleteRecord(Guid id)
        {
            return delete.DeleteEntity(id);
        }

        public DtoBug ReadRecord(Guid id)
        {
            return read.ReadEntity(id);
        }

        public List<DtoBug> ReadAll(string by)
        {
            return filter.ReadAll(by);
        }

        public DtoBug UpdateRecord(DtoBug dto)
        {
            return update.UpdateEntity(dto);
        }
    }
}
